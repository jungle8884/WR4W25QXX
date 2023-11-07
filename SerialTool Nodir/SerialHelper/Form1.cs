using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MessagePack;
using System.Linq;
using Nito.Collections;

namespace SerialHelper
{
    public partial class Form1 : Form
    {

        string receiveMode = "HEX模式";
        string receiveCoding = "UTF-8";
        string sendMode = "HEX模式";
        string sendCoding = "UTF-8";

        long sectorSize = 4096; //4KB 单位byte
        int COUNT = 0; // 发送计数器

        static string currentDirectory = Directory.GetCurrentDirectory();
        static string sendDir = currentDirectory + "\\send";
        static string readDir = currentDirectory + "\\read";
        static string saveDir = currentDirectory + "\\save";
        static long actualSize = 0;
        static string fileName = "";
        static string fileFullName = "";

        List<byte> byteBuffer = new List<byte>();       //接收字节缓存区
        List<string> fileFullNameList = new List<string>(); //拆分文件列表
        List<string> fileFullNameOldList = new List<string>(); //拆分原文件列表

        private string BytesToText(byte[] bytes, string encoding)       //字节流转文本
        {
            List<byte> byteDecode = new List<byte>();   //需要转码的缓存区
            byteBuffer.AddRange(bytes);     //接收字节流到接收字节缓存区
            if (encoding == "GBK")
            {
                int count = byteBuffer.Count;
                for (int i = 0; i < count; i++)
                {
                    if (byteBuffer.Count == 0)
                    {
                        break;
                    }
                    if (byteBuffer[0] < 0x80)       //1字节字符
                    {
                        byteDecode.Add(byteBuffer[0]);
                        byteBuffer.RemoveAt(0);
                    }
                    else       //2字节字符
                    {
                        if (byteBuffer.Count >= 2)
                        {
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                        }
                    }
                }
            }
            else if (encoding == "UTF-8")
            {
                int count = byteBuffer.Count;
                for (int i = 0; i < count; i++)
                {
                    if (byteBuffer.Count == 0)
                    {
                        break;
                    }
                    if ((byteBuffer[0] & 0x80) == 0x00)     //1字节字符
                    {
                        byteDecode.Add(byteBuffer[0]);
                        byteBuffer.RemoveAt(0);
                    }
                    else if ((byteBuffer[0] & 0xE0) == 0xC0)     //2字节字符
                    {
                        if (byteBuffer.Count >= 2)
                        {
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                        }
                    }
                    else if ((byteBuffer[0] & 0xF0) == 0xE0)     //3字节字符
                    {
                        if (byteBuffer.Count >= 3)
                        {
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                        }
                    }
                    else if ((byteBuffer[0] & 0xF8) == 0xF0)     //4字节字符
                    {
                        if (byteBuffer.Count >= 4)
                        {
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                            byteDecode.Add(byteBuffer[0]);
                            byteBuffer.RemoveAt(0);
                        }
                    }
                    else        //其他
                    {
                        byteDecode.Add(byteBuffer[0]);
                        byteBuffer.RemoveAt(0);
                    }
                }
            }
            return Encoding.GetEncoding(encoding).GetString(byteDecode.ToArray());
        }

        private string BytesToHex(byte[] bytes)     //字节流转HEX
        {
            string hex = "";
            foreach (byte b in bytes)
            {
                hex += b.ToString("X2") + " ";
            }
            return hex;
        }

        /*
         * 根据指定编码将文本转字节流
         * **/
        private byte[] TextToBytes(string str, string encoding)     //文本转字节流
        {
            return Encoding.GetEncoding(encoding).GetBytes(str);
        }

        /**目录转字节流，固定编码*/
        private byte[] DirectorToBytes(string str)    
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string RemoveTrailingFF(string inputString)
        {
            // 移除末尾的 "FF" 子字符串
            while (inputString.EndsWith("FF"))
            {
                inputString = inputString.Substring(0, inputString.Length - 2);
            }

            return inputString;
        }



        /*
         * 十六进制文本转化为对应的二进制数字
         * **/
        private byte[] HexToBytes(string str)       //HEX转字节流
        {
            /* 这行代码的作用是将字符串 str 中的所有不是十六进制字符（A 到 F、a 到 f 和 0 到 9）的字符删除，只保留十六进制字符。
             * 这通常用于数据预处理，以确保字符串中只包含有效的十六进制数据。
             * "[^A-F^a-f^0-9]" 是一个正则表达式模式，用于匹配不在范围 A 到 F（大写或小写字母）和 0 到 9 的字符。
             * 这个正则表达式的含义是排除（^）所有不在这个范围内的字符。
             * Regex.Replace 是一个用于正则表达式替换的方法。
             * 在这里，它用于将 str 中不匹配正则模式的字符替换为空字符串，也就是从字符串中删除它们。
             * **/
            string str1 = Regex.Replace(str, "[^A-F^a-f^0-9]", "");     //清除非法字符

            double i = str1.Length;     //将字符两两拆分
            int len = 2;
            string[] strList = new string[int.Parse(Math.Ceiling(i / len).ToString())];
            for (int j = 0; j < strList.Length; j++)
            {
                len = len <= str1.Length ? len : str1.Length;
                strList[j] = str1.Substring(0, len);
                str1 = str1.Substring(len, str1.Length - len);
            }

            int count = strList.Length;     //将拆分后的字符依次转换为字节
            byte[] bytes = new byte[count];
            for (int j = 0; j < count; j++)
            {
                // NumberStyles.HexNumber 是一个枚举值，指示解析的字符串是十六进制数字。
                bytes[j] = byte.Parse(strList[j], NumberStyles.HexNumber);
            }

            return bytes;
        }

        private void OpenSerialPort()       //打开串口
        {
            try
            {
                serialPort.PortName = cbPortName.Text;
                serialPort.BaudRate = Convert.ToInt32(cbBaudRate.Text);
                serialPort.DataBits = Convert.ToInt32(cbDataBits.Text);
                StopBits[] sb = { StopBits.One, StopBits.OnePointFive, StopBits.Two };
                serialPort.StopBits = sb[cbStopBits.SelectedIndex];
                Parity[] pt = { Parity.None, Parity.Odd, Parity.Even };
                serialPort.Parity = pt[cbParity.SelectedIndex];
                serialPort.Open();

                btnOpen.BackColor = Color.Pink;
                btnOpen.Text = "关闭串口";
                btnSend.Enabled = true;
                button_File.Enabled = true;
                button_Save.Enabled = true;
                btn_Read_Data.Enabled = true;
                cbPortName.Enabled = false;
                cbBaudRate.Enabled = false;
                cbDataBits.Enabled = false;
                cbStopBits.Enabled = false;
                cbParity.Enabled = false;

            }
            catch
            {
                MessageBox.Show("串口打开失败", "提示");
            }
        }

        private void CloseSerialPort()      //关闭串口
        {
            serialPort.Close();

            btnOpen.BackColor = SystemColors.ControlLight;
            btnOpen.Text = "打开串口";
            btnSend.Enabled = false;
            button_File.Enabled = false;
            button_Save.Enabled = false;
            btn_Read_Data.Enabled = false;
            cbPortName.Enabled = true;
            cbBaudRate.Enabled = true;
            cbDataBits.Enabled = true;
            cbStopBits.Enabled = true;
            cbParity.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)        //窗口加载事件
        {
            cbBaudRate.SelectedIndex = 1;       //控件状态初始化
            cbDataBits.SelectedIndex = 3;
            cbStopBits.SelectedIndex = 0;
            cbParity.SelectedIndex = 0;
            cbReceiveMode.SelectedIndex = 0;
            cbReceiveCoding.SelectedIndex = 0;
            cbSendMode.SelectedIndex = 0;
            cbSendCoding.SelectedIndex = 0;
            btnSend.Enabled = false;
            btn_Read_Data.Enabled = false;
            cbPortName.Enabled = true;
            cbBaudRate.Enabled = true;
            cbDataBits.Enabled = true;
            cbStopBits.Enabled = true;
            cbParity.Enabled = true;
            button_DIY.Enabled = true;
        }

        private void cbPortName_DropDown(object sender, EventArgs e)        //串口号下拉事件
        {
            string currentName = cbPortName.Text;
            string[] names = SerialPort.GetPortNames();       //搜索可用串口号并添加到下拉列表
            cbPortName.Items.Clear();
            cbPortName.Items.AddRange(names);
            cbPortName.Text = currentName;
        }

        private void btnOpen_Click(object sender, EventArgs e)      //打开串口点击事件
        {
            if (btnOpen.Text == "打开串口")
            {
                OpenSerialPort();
            }
            else if (btnOpen.Text == "关闭串口")
            {
                CloseSerialPort();
            }

        }

        protected override void DefWndProc(ref Message m)       //USB拔出事件
        {

            if (m.Msg == 0x0219)        //WM_DEVICECHANGE
            {
                if (m.WParam.ToInt32() == 0x8004)
                {
                    if (btnOpen.Text == "关闭串口" && serialPort.IsOpen == false)
                    {
                        CloseSerialPort();      //USB异常拔出，关闭串口
                    }
                }
            }
            base.DefWndProc(ref m);
        }

        private void btnSend_Click(object sender, EventArgs e)      //发送点击事件
        {
            if (serialPort.IsOpen)
            {
                // 将数据塞入tbSend.Tex

                if (sendMode == "HEX模式")
                {
                    byte[] dataSend = HexToBytes(tbSend.Text);      //HEX转字节流
                    int count = dataSend.Length;
                    serialPort.Write(dataSend, 0, count);       //串口发送
                }
                else if (sendMode == "文本模式")
                {
                    byte[] dataSend = TextToBytes(tbSend.Text, sendCoding);      //文本转字节流
                    int count = dataSend.Length;
                    serialPort.Write(dataSend, 0, count);       //串口发送
                }
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)      //串口接收数据事件
        {
            // 目录保存位置
            if (!Directory.Exists(readDir))
            {
                Directory.CreateDirectory(readDir);
            }

            if (serialPort.IsOpen)
            {
                int count = serialPort.BytesToRead; // 这一行获取当前串口接收缓冲区中待读取的字节数量
                byte[] dataReceive = new byte[count];
                serialPort.Read(dataReceive, 0, count);     //串口接收
  
                /* BeginInvoke方法用于确保UI更新操作在主线程中执行，以避免多线程问题。
                     * (delegate { ... }) 这是一个匿名委托，其中包含要在UI线程上执行的代码块。
                     * 在这个代码块中，根据接收模式的不同，数据被附加到文本框tbReceive中。
                     * 这个匿名委托是一个用于执行UI更新操作的代码块，它将被异步调度到UI线程上执行，而不会阻塞当前线程。
                     * **/
                this.BeginInvoke((EventHandler)(delegate
                {
                    if (receiveMode == "HEX模式")
                    {
                        tbReceive.AppendText(BytesToHex(dataReceive));  //字节流转HEX
                    }
                    else if (receiveMode == "文本模式")
                    {
                        tbReceive.AppendText(BytesToText(dataReceive, receiveCoding));       //字节流转文本
                    }

                    // 追加写入一个文件中
                    string appendFilePath = readDir + "\\" + "read.bin";
                    using (BinaryWriter writer = new BinaryWriter(File.Open(appendFilePath, FileMode.Append)))
                    {
                        writer.Write(dataReceive, 0, count);
                        Console.WriteLine(( "->追加写入数据：" + count + "byte"));
                    }

                }));
            }

        }

        private void btnClearReceive_Click(object sender, EventArgs e)      //清空接收区点击事件
        {
            tbReceive.Clear();
        }

        private void btnClearSend_Click(object sender, EventArgs e)      //清空发送区点击事件
        {
            tbSend.Clear();
        }

        private void cbReceiveMode_SelectedIndexChanged(object sender, EventArgs e)     //接收模式选择事件
        {
            if (cbReceiveMode.Text == "HEX模式")
            {
                cbReceiveCoding.Enabled = false;
                receiveMode = "HEX模式";
            }
            else if (cbReceiveMode.Text == "文本模式")
            {
                cbReceiveCoding.Enabled = true;
                receiveMode = "文本模式";
            }
            byteBuffer.Clear();
        }

        private void cbReceiveCoding_SelectedIndexChanged(object sender, EventArgs e)     //接收编码选择事件
        {
            if (cbReceiveCoding.Text == "GBK")
            {
                receiveCoding = "GBK";
            }
            else if (cbReceiveCoding.Text == "UTF-8")
            {
                receiveCoding = "UTF-8";
            }
            byteBuffer.Clear();
        }

        private void cbSendMode_SelectedIndexChanged(object sender, EventArgs e)     //发送模式选择事件
        {
            if (cbSendMode.Text == "HEX模式")
            {
                cbSendCoding.Enabled = false;
                sendMode = "HEX模式";
            }
            else if (cbSendMode.Text == "文本模式")
            {
                cbSendCoding.Enabled = true;
                sendMode = "文本模式";
            }
        }

        private void cbSendCoding_SelectedIndexChanged(object sender, EventArgs e)     //发送编码选择事件
        {
            if (cbSendCoding.Text == "GBK")
            {
                sendCoding = "GBK";
            }
            else if (cbSendCoding.Text == "UTF-8")
            {
                sendCoding = "UTF-8";
            }
        }

        /*
         * 以4K为单位发送数据，不足4K按4K算*
         */
        private void sendData(byte[] buffer)
        {
            byte[] dataSendSector = new byte[sectorSize];
            // 数据对齐
            for (int i = 0; i < sectorSize; i++)
            {
                dataSendSector[i] = 0xFF;
            }

            // 数据缓存
            for (int i = 0; i < buffer.Length; i++)
            {
                dataSendSector[i] = buffer[i];
            }
            COUNT++; 
            Console.WriteLine(COUNT + "-写入实际数据大小：" + buffer.Length);
            Console.WriteLine(COUNT + "发送数据对齐后大小：" + dataSendSector.Length);
            // 数据发送
            serialPort.Write(dataSendSector, 0, dataSendSector.Length);
        }


        private void button_File_Click(object sender, EventArgs e)
        {
            int sendTime = (8 * (int)sectorSize) / serialPort.BaudRate + 8;
            int sleepTime = sendTime * 2;

            // 目录保存位置
            if (!Directory.Exists(sendDir))
            {
                Directory.CreateDirectory(sendDir);
            }

            openFileDialog1.Title = "选择文件";
            openFileDialog1.Filter = "所有文件 (*.*)|*.*";
            // 显示文件对话框并处理用户的选择
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 用户选择了一个文件
                string selectedFile = openFileDialog1.FileName;
                //MessageBox.Show($"您选择的文件是: {selectedFile}");

                #region 先拆分

                if (File.Exists(selectedFile))
                {
                    FileInfo fileInfo = new FileInfo(selectedFile); 
                    fileFullName = fileInfo.FullName;
                    fileName = fileInfo.Name;
                    Console.WriteLine("文件路径:" + fileFullName);
                    using (FileStream fileStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
                    {
                        actualSize = fileStream.Length;
                        byte[] dataSend = new byte[sectorSize];
                        byte[] buffer = new byte[actualSize];
                        //向上取整算法： 对sectorSize向上取整
                        int num = (int)((buffer.Length + sectorSize - 1) / sectorSize);
                        Console.WriteLine("写入文件有 " + num + " 个4K");
                        Console.WriteLine("实际写入文件大小 " + (int)actualSize + " Byte");
                        // 读取文件
                        int bytesRead = fileStream.Read(buffer, 0, (int)actualSize);
                        // 读取成功
                        if (bytesRead == buffer.Length)
                        {
                            // 有num个sector
                            if (num > 1)
                            {
                                // 前 num-1 个 【完整的sector】
                                for (int i = 0; i < num - 1; i++)
                                {
                                    for (int j = 0; j < sectorSize; j++)
                                    {
                                        dataSend[j] = buffer[i * sectorSize + j];
                                    }
                                    Console.WriteLine(i + ": " + (i * sectorSize).ToString("X") + "--> " + (i * sectorSize + sectorSize - 1).ToString("X"));
                                    // 保存文件
                                    string sFilePath = sendDir + "\\" + i + fileName;
                                    fileFullNameList.Add(sFilePath);
                                    try
                                    {
                                        using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePath, FileMode.Create)))
                                        {
                                            writer.Write(dataSend, 0, (int)sectorSize);
                                            Console.WriteLine("Binary data has been successfully written to " + sFilePath);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error: " + ex.Message);
                                    }
                                }
                                // 最后一个 【可能完整也可能不完整】
                               
                                // 保存文件
                                long k = 0;
                                long resj = (num - 1) * sectorSize;
                                do
                                {
                                    dataSend[k] = buffer[resj];
                                    k++;
                                    resj++;
                                } while (resj < actualSize);
                                string sFilePathFinal = sendDir + "\\" + (num - 1) + fileName;
                                fileFullNameList.Add(sFilePathFinal);
                                try
                                {
                                    using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePathFinal, FileMode.Create)))
                                    {
                                        writer.Write(dataSend, 0, (int)k);
                                        Console.WriteLine("Binary data has been successfully written to " + sFilePathFinal);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error: " + ex.Message);
                                }
                            }
                            else  // num = 1
                            {
                                Console.WriteLine(0 + ": " + (0).ToString("X") + "--> " + (sectorSize - 1).ToString("X"));
                                string sFilePathOnlyOne = sendDir + "\\" + 0 + fileName;
                                fileFullNameList.Add(sFilePathOnlyOne);
                                try
                                {
                                    using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePathOnlyOne, FileMode.Create)))
                                    {
                                        writer.Write(buffer, 0, (int)actualSize);
                                        Console.WriteLine("Binary data has been successfully written to " + sFilePathOnlyOne);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error: " + ex.Message);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 后发送
                foreach (var fileFullName in fileFullNameList)
                {
                    using (FileStream fileStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[fileStream.Length];
                        int bytesRead = fileStream.Read(buffer, 0, (int)fileStream.Length);
                        Thread.Sleep(sleepTime * 1000);
                        sendData(buffer);
                    }
                }

                #endregion
            }

            #region 文件形式实现
            //folderBrowserDialog1.Description = "请选择文件夹";
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            //folderBrowserDialog1.ShowNewFolderButton = true;
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    //  获取文件目录路径
            //    string folderPath = folderBrowserDialog1.SelectedPath;

            //    #region 先拆分

            //    if (Directory.Exists(folderPath))
            //    {
            //        FileInfo fileInfo = new FileInfo(Directory.GetFiles(folderPath)[0]); //只会有一个二进制文件
            //        fileFullName = fileInfo.FullName;
            //        fileName = fileInfo.Name;
            //        Console.WriteLine("文件路径:" + fileFullName);
            //        using (FileStream fileStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
            //        {
            //            actualSize = fileStream.Length;
            //            byte[] dataSend = new byte[sectorSize];
            //            byte[] buffer = new byte[actualSize];
            //            //向上取整算法： 对sectorSize向上取整
            //            int num = (int)((buffer.Length + sectorSize - 1) / sectorSize);
            //            Console.WriteLine("写入文件有 " + num + " 个4K");
            //            Console.WriteLine("实际写入文件大小 " + (int)actualSize + " Byte");
            //            // 读取文件
            //            int bytesRead = fileStream.Read(buffer, 0, (int)actualSize);
            //            // 读取成功
            //            if (bytesRead == buffer.Length)
            //            {
            //                // 有num个sector
            //                if (num > 1)
            //                {
            //                    // 前 num-1 个 【完整的sector】
            //                    for (int i = 0; i < num - 1; i++)
            //                    {
            //                        for (int j = 0; j < sectorSize; j++)
            //                        {
            //                            dataSend[j] = buffer[i * sectorSize + j];
            //                        }
            //                        Console.WriteLine(i + ": " + (i * sectorSize).ToString("X") + "--> " + (i * sectorSize + sectorSize - 1).ToString("X"));
            //                        // 保存文件
            //                        string sFilePath = sendDir + "\\" + i + fileName;
            //                        fileFullNameList.Add(sFilePath);
            //                        try
            //                        {
            //                            using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePath, FileMode.Create)))
            //                            {
            //                                writer.Write(dataSend, 0, (int)sectorSize);
            //                                Console.WriteLine("Binary data has been successfully written to " + sFilePath);
            //                            }
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            Console.WriteLine("Error: " + ex.Message);
            //                        }
            //                    }
            //                    // 最后一个 【可能完整也可能不完整】
            //                    long k = 0;
            //                    long resj = (num - 1) * sectorSize;
            //                    do
            //                    {
            //                        dataSend[k] = buffer[resj];
            //                        k++;
            //                        resj++;
            //                    } while (resj < actualSize);
            //                    // 保存文件
            //                    string sFilePathFinal = sendDir + "\\" + (num - 1) + fileName;
            //                    fileFullNameList.Add(sFilePathFinal);
            //                    try
            //                    {
            //                        using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePathFinal, FileMode.Create)))
            //                        {
            //                            writer.Write(dataSend, 0, (int)k);
            //                            Console.WriteLine("Binary data has been successfully written to " + sFilePathFinal);
            //                        }
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        Console.WriteLine("Error: " + ex.Message);
            //                    }
            //                }
                            
            //            }
            //        }
            //    }
            //    #endregion

            //    #region 后发送
            //    foreach (var fileFullName in fileFullNameList)
            //    {
            //        using (FileStream fileStream = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
            //        {
            //            byte[] buffer = new byte[fileStream.Length];
            //            int bytesRead = fileStream.Read(buffer, 0, (int)fileStream.Length);
            //            Thread.Sleep(sleepTime * 1000);
            //            sendData(buffer);
            //        }
            //    }
                
            //    #endregion

            //}
            #endregion

        }

        /*
         * 返回文件夹下的文件列表
         * **/
        private string[] getFiles() 
        {
            folderBrowserDialog1.Description = "请选择文件夹";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                if (Directory.Exists(folderPath))
                {
                    return Directory.GetFiles(folderPath);
                }
            }

            return new string[0];
        }

        /*
        * 返回文件名全路径
        * **/
        private string getFile()
        {
            // 设置文件对话框的属性
            openFileDialog1.Title = "选择文件";
            openFileDialog1.Filter = "所有文件 (*.*)|*.*";

            string selectedFile = "空路径";
            // 显示文件对话框并处理用户的选择
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 用户选择了一个文件
                selectedFile = openFileDialog1.FileName;
                //MessageBox.Show($"您选择的文件是: {selectedFile}");
            }

            return selectedFile;
        }

        /*
         * 拆分文件，每个为4k
         * 要求：文件全路径为：C:\Users\Jungle\Desktop\SerialTool Nodir\SerialHelper\bin\Debug\test\random_data2M.bin 
         * 要有后缀名
         * **/
        private List<string> FileSplitTo4KBin(string fileName)
        {
            List<string> splitFileNameList = new List<string>();

            string sFileDirectory = "";
            string sFileName = "";
            string[] sFileArray = fileName.Split('\\');
            if (sFileArray.Length == 1)
            {
                sFileName = sFileArray[0];
                sFileDirectory = sFileName.Split('.')[0] + "_split" + "\\";
            }
            else 
            {
                // 将 sFileArray 的元素连接成文件路径
                sFileName = sFileArray[sFileArray.Length - 1];
                sFileDirectory = string.Join("\\", sFileArray, 0, sFileArray.Length - 1) + "\\" + sFileName.Split('.')[0] + "_split" + "\\";
            }

            if (!Directory.Exists(sFileDirectory))
            {
                Directory.CreateDirectory(sFileDirectory);
            }
            
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                long len = fileStream.Length;
                byte[] dataSend = new byte[sectorSize];
                byte[] buffer = new byte[len];

                int num = (int)((fileStream.Length + sectorSize-1) / sectorSize);
                Console.WriteLine("拆分文件有 " + num + " 个4K");
                Console.WriteLine("拆分文件大小 " + len + " Byte");

                // 读取文件
                int bytesRead = fileStream.Read(buffer, 0, (int)len);
                // 读取成功
                if (bytesRead == buffer.Length)
                {
                    if (num > 1)
                    {
                        for (int i = 0; i < num-1; i++)
                        {
                            for (int j = 0; j < sectorSize; j++)
                            {
                                dataSend[j] = buffer[i * sectorSize + j];
                            }
                            Console.WriteLine(i + ": " + (i * sectorSize).ToString("X2") + "--> " + (i * sectorSize + sectorSize - 1).ToString("X2"));
                            string sFilePath = sFileDirectory + "split_" + i + "_" + sFileName;
                            splitFileNameList.Add(sFilePath);
                            try
                            {
                                using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePath, FileMode.Create)))
                                {
                                    writer.Write(dataSend, 0, (int)sectorSize);
                                    Console.WriteLine("Binary data has been successfully written to " + sFilePath);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        // 最后一个 【可能完整也可能不完整】
                        long k = 0;
                        long resj = (num - 1) * sectorSize;
                        do
                        {
                            dataSend[k] = buffer[resj];
                            k++;
                            resj++;
                        } while (resj < len);
                        // 保存文件
                        Console.WriteLine((num - 1) + ": " + ((num - 1) * sectorSize).ToString("X2") + "--> " + (len).ToString("X2"));
                        string sFilePathFinal = sFileDirectory + "split_" + (num - 1) + "_" + sFileName;
                        splitFileNameList.Add(sFilePathFinal);
                        try
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePathFinal, FileMode.Create)))
                            {
                                writer.Write(dataSend, 0, (int)k);
                                Console.WriteLine("Binary data has been successfully written to " + sFilePathFinal);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    else  // num = 1
                    {
                        Console.WriteLine(0 + ": " + (0).ToString("X") + "--> " + (sectorSize - 1).ToString("X"));
                        string sFilePathOnlyOne = sFileDirectory + "split_" + 0 + "_" + sFileName;
                        splitFileNameList.Add(sFilePathOnlyOne);
                        try
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(sFilePathOnlyOne, FileMode.Create)))
                            {
                                writer.Write(buffer, 0, (int)len);
                                Console.WriteLine("Binary data has been successfully written to " + sFilePathOnlyOne);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }

                }

                return splitFileNameList;
            } 
        }

        /*
         * 保存接收区数据
         * **/
        private void button_Save_Click(object sender, EventArgs e)
        {
            // 目录保存位置
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            // 接收文本
            string saveText = tbReceive.Text;
            if (!string.IsNullOrEmpty(saveText))
            {
                int len = saveText.Length;
                int perSize = (int)(sectorSize * 3);
                int num = (len + perSize - 3) / perSize;
                for (int i = 0; i < num - 1; i++)
                {
                    string sectorText = saveText.Substring(i * perSize, perSize);
                    byte[] fileBinaryData = HexToBytes(sectorText);
                    Console.WriteLine("接收 " + fileBinaryData.Length + "Byte");
                    string saveFilePath = saveDir + "\\" + i + "_save.bin";
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFilePath, FileMode.Create)))
                    {
                        writer.Write(fileBinaryData, 0, fileBinaryData.Length);
                    }
                }
                // 最后一个 
                string rejText = saveText.Substring((num - 1) * perSize);
                byte[] fileFinalBinaryData = HexToBytes(rejText);
                Console.WriteLine("接收 " + fileFinalBinaryData.Length + "Byte");
                string saveFileFinalPath = saveDir + "\\" + (num - 1) + "_save.bin";
                using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileFinalPath, FileMode.Create)))
                {
                    writer.Write(fileFinalBinaryData, 0, fileFinalBinaryData.Length);
                }
            }
            else 
            {
                MessageBox.Show("文件为空, 不需要保存!");
            }

        }

        /*
         * 拆分文件 4k为一个单位
         * **/
        private void button_DIY_Click(object sender, EventArgs e)
        {
            #region
            string selectedFile = getFile();
            if (!selectedFile.Equals("空路径"))
            {
                FileSplitTo4KBin(selectedFile);
            }
            #endregion
        }

        /*
         * 将二进制文件读入接收区
         * **/
        private void btn_Read_Data_Click(object sender, EventArgs e)
        {
            string filePath = getFile();
            if (!filePath.Equals("空路径")) 
            {
                this.BeginInvoke((EventHandler)(delegate
                {
                    List<string> filePaths = FileSplitTo4KBin(filePath);
                    Console.WriteLine("读入文件数: "+ filePaths.Count);
                    foreach (var fp in filePaths)
                    {
                        Console.WriteLine("当前路径:" + fp);
                        using (FileStream fileStream = new FileStream(fp, FileMode.Open, FileAccess.Read))
                        {
                            long len = fileStream.Length;
                            Console.WriteLine("len: " + len);
                            byte[] buffer = new byte[len];
                            // 读取文件
                            int bytesRead = fileStream.Read(buffer, 0, (int)len);
                            Console.WriteLine("读入" + bytesRead + "byte");
                            // 读取成功
                            if (bytesRead == buffer.Length)
                            {
                                tbSend.AppendText(BytesToHex(buffer));  //字节流转HEX
                            }
                        }
                    }
                }));
                
                
            }
        }
    }
}

