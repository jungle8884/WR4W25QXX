# WR4W25QXX

该项目主要是对W25Q64系列进行读写
包含：
  1，Keil5 Flash读写程序
  2，Winform 串口助手
  注：该串口助手由 【江协科技代码升级而来，进行魔改，配合Flash读写程序进行使用】【来源：https://jiangxiekeji.com/download.html】
Flash读写程序由C语言完成，以4K为单位进行读写，串口助手每次发送数据也会以4K为单位进行发送，不足4K会对齐。
