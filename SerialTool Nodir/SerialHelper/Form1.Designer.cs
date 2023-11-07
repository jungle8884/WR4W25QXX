namespace SerialHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearReceive = new System.Windows.Forms.Button();
            this.btn_Read_Data = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.button_File = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_DIY = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReceiveMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbReceiveCoding = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSendMode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSendCoding = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(643, 596);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(635, 393);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tbReceive, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(627, 364);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tbReceive
            // 
            this.tbReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReceive.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbReceive.Location = new System.Drawing.Point(4, 4);
            this.tbReceive.Margin = new System.Windows.Forms.Padding(4);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceive.Size = new System.Drawing.Size(619, 314);
            this.tbReceive.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClearReceive);
            this.flowLayoutPanel1.Controls.Add(this.btn_Read_Data);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 322);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(627, 42);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnClearReceive
            // 
            this.btnClearReceive.Location = new System.Drawing.Point(511, 4);
            this.btnClearReceive.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearReceive.Name = "btnClearReceive";
            this.btnClearReceive.Size = new System.Drawing.Size(112, 34);
            this.btnClearReceive.TabIndex = 0;
            this.btnClearReceive.Text = "清空接收区";
            this.btnClearReceive.UseVisualStyleBackColor = true;
            this.btnClearReceive.Click += new System.EventHandler(this.btnClearReceive_Click);
            // 
            // btn_Read_Data
            // 
            this.btn_Read_Data.Location = new System.Drawing.Point(391, 4);
            this.btn_Read_Data.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Read_Data.Name = "btn_Read_Data";
            this.btn_Read_Data.Size = new System.Drawing.Size(112, 34);
            this.btn_Read_Data.TabIndex = 1;
            this.btn_Read_Data.Text = "读入发送区";
            this.btn_Read_Data.UseVisualStyleBackColor = true;
            this.btn_Read_Data.Click += new System.EventHandler(this.btn_Read_Data_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 405);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(635, 187);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoScroll = true;
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.tbSend, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(627, 158);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tbSend
            // 
            this.tbSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbSend.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSend.Location = new System.Drawing.Point(4, 4);
            this.tbSend.Margin = new System.Windows.Forms.Padding(4);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSend.Size = new System.Drawing.Size(619, 108);
            this.tbSend.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClearSend);
            this.flowLayoutPanel2.Controls.Add(this.btnSend);
            this.flowLayoutPanel2.Controls.Add(this.button_File);
            this.flowLayoutPanel2.Controls.Add(this.button_Save);
            this.flowLayoutPanel2.Controls.Add(this.button_DIY);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 116);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(627, 42);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(4, 4);
            this.btnClearSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(112, 34);
            this.btnClearSend.TabIndex = 0;
            this.btnClearSend.Text = "清空发送区";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(124, 4);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(112, 34);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // button_File
            // 
            this.button_File.Enabled = false;
            this.button_File.Location = new System.Drawing.Point(243, 3);
            this.button_File.Name = "button_File";
            this.button_File.Size = new System.Drawing.Size(112, 34);
            this.button_File.TabIndex = 7;
            this.button_File.Text = "发送文件";
            this.button_File.UseVisualStyleBackColor = true;
            this.button_File.Click += new System.EventHandler(this.button_File_Click);
            // 
            // button_Save
            // 
            this.button_Save.Enabled = false;
            this.button_Save.Location = new System.Drawing.Point(361, 3);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(112, 34);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "数据保存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_DIY
            // 
            this.button_DIY.Enabled = false;
            this.button_DIY.Location = new System.Drawing.Point(479, 3);
            this.button_DIY.Name = "button_DIY";
            this.button_DIY.Size = new System.Drawing.Size(112, 34);
            this.button_DIY.TabIndex = 9;
            this.button_DIY.Text = "文件拆分";
            this.button_DIY.UseVisualStyleBackColor = true;
            this.button_DIY.Click += new System.EventHandler(this.button_DIY_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(655, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 596);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(284, 304);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbPortName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.cbBaudRate, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbDataBits, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.cbStopBits, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.cbParity, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.btnOpen, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(276, 268);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "串口号";
            // 
            // cbPortName
            // 
            this.cbPortName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(94, 9);
            this.cbPortName.Margin = new System.Windows.Forms.Padding(4);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(172, 26);
            this.cbPortName.TabIndex = 1;
            this.cbPortName.DropDown += new System.EventHandler(this.cbPortName_DropDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "波特率";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "数据位";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 148);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "停止位";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 193);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "校验位";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 238);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "操作";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "38400",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(94, 54);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(172, 26);
            this.cbBaudRate.TabIndex = 7;
            // 
            // cbDataBits
            // 
            this.cbDataBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(94, 99);
            this.cbDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(172, 26);
            this.cbDataBits.TabIndex = 8;
            // 
            // cbStopBits
            // 
            this.cbStopBits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(94, 144);
            this.cbStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(172, 26);
            this.cbStopBits.TabIndex = 9;
            // 
            // cbParity
            // 
            this.cbParity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cbParity.Location = new System.Drawing.Point(94, 189);
            this.cbParity.Margin = new System.Windows.Forms.Padding(4);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(172, 26);
            this.cbParity.TabIndex = 10;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpen.Location = new System.Drawing.Point(94, 229);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(178, 37);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(4, 316);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(284, 128);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收区配置";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cbReceiveMode, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.cbReceiveCoding, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(276, 93);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "接收模式";
            // 
            // cbReceiveMode
            // 
            this.cbReceiveMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbReceiveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiveMode.FormattingEnabled = true;
            this.cbReceiveMode.Items.AddRange(new object[] {
            "HEX模式",
            "文本模式"});
            this.cbReceiveMode.Location = new System.Drawing.Point(94, 9);
            this.cbReceiveMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiveMode.Name = "cbReceiveMode";
            this.cbReceiveMode.Size = new System.Drawing.Size(172, 26);
            this.cbReceiveMode.TabIndex = 1;
            this.cbReceiveMode.SelectedIndexChanged += new System.EventHandler(this.cbReceiveMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "文本编码";
            // 
            // cbReceiveCoding
            // 
            this.cbReceiveCoding.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbReceiveCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiveCoding.FormattingEnabled = true;
            this.cbReceiveCoding.Items.AddRange(new object[] {
            "UTF-8",
            "GBK"});
            this.cbReceiveCoding.Location = new System.Drawing.Point(94, 56);
            this.cbReceiveCoding.Margin = new System.Windows.Forms.Padding(4);
            this.cbReceiveCoding.Name = "cbReceiveCoding";
            this.cbReceiveCoding.Size = new System.Drawing.Size(172, 26);
            this.cbReceiveCoding.TabIndex = 7;
            this.cbReceiveCoding.SelectedIndexChanged += new System.EventHandler(this.cbReceiveCoding_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel8);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(4, 452);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(284, 128);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送区配置";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbSendMode, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSendCoding, 1, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(4, 25);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(276, 93);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "发送模式";
            // 
            // cbSendMode
            // 
            this.cbSendMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSendMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSendMode.FormattingEnabled = true;
            this.cbSendMode.Items.AddRange(new object[] {
            "HEX模式",
            "文本模式"});
            this.cbSendMode.Location = new System.Drawing.Point(94, 9);
            this.cbSendMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbSendMode.Name = "cbSendMode";
            this.cbSendMode.Size = new System.Drawing.Size(172, 26);
            this.cbSendMode.TabIndex = 1;
            this.cbSendMode.SelectedIndexChanged += new System.EventHandler(this.cbSendMode_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "文本编码";
            // 
            // cbSendCoding
            // 
            this.cbSendCoding.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSendCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSendCoding.FormattingEnabled = true;
            this.cbSendCoding.Items.AddRange(new object[] {
            "UTF-8",
            "GBK"});
            this.cbSendCoding.Location = new System.Drawing.Point(94, 56);
            this.cbSendCoding.Margin = new System.Windows.Forms.Padding(4);
            this.cbSendCoding.Name = "cbSendCoding";
            this.cbSendCoding.Size = new System.Drawing.Size(172, 26);
            this.cbSendCoding.TabIndex = 7;
            this.cbSendCoding.SelectedIndexChanged += new System.EventHandler(this.cbSendCoding_SelectedIndexChanged);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SerialHelper V1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClearReceive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbReceiveMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReceiveCoding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSendMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSendCoding;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button button_File;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_DIY;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Read_Data;
    }
}

