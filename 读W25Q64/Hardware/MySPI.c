#include "stm32f10x.h"                  // Device header

void MySPI_W_SS(uint8_t BitValue) //CS对应PA4
{
	GPIO_WriteBit(GPIOA, GPIO_Pin_4, (BitAction)BitValue);
}

void MySPI_W_SCK(uint8_t BitValue) // CLK对应PA5
{
	GPIO_WriteBit(GPIOA, GPIO_Pin_5, (BitAction)BitValue);
}

void MySPI_W_MOSI(uint8_t BitValue) // SI即DI对应MO-PA7
{
	GPIO_WriteBit(GPIOA, GPIO_Pin_7, (BitAction)BitValue);
}

uint8_t MySPI_R_MISO(void) // SO即DO对应MI-PA6
{
	return GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_6);
}

void MySPI_Init(void)
{
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);
	
	GPIO_InitTypeDef GPIO_InitStructure;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4 | GPIO_Pin_5 | GPIO_Pin_7;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
	// MISO: M-P6: STM62 S-DO: W25Q64 
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
	
	MySPI_W_SS(1);
	MySPI_W_SCK(0);
}

void MySPI_Start(void) //通信开始
{
	MySPI_W_SS(0);
}

void MySPI_Stop(void) //通信结束
{
	MySPI_W_SS(1);
}

// 模式0交换一个字节
//uint8_t MySPI_SwapByte(uint8_t ByteSend)
//{
//	uint8_t i, ByteReceive = 0x00;
//	
//	for (i = 0; i < 8; i ++)
//	{
//		MySPI_W_MOSI(ByteSend & (0x80 >> i));
//		MySPI_W_SCK(1);
//		if (MySPI_R_MISO() == 1){ByteReceive |= (0x80 >> i);}
//		MySPI_W_SCK(0);
//	}
//	
//	return ByteReceive;
//}

// 模式0交换一个字节【优化：移位模型】
uint8_t MySPI_SwapByte(uint8_t ByteSend)
{
	uint8_t i;
	// 向S从机发送，向M主机返回数据
	for (i = 0; i < 8; i ++)
	{
		MySPI_W_MOSI(ByteSend & 0x80); //输出最高位
		ByteSend <<= 1; //最低位自动补0
		MySPI_W_SCK(1);
		if (MySPI_R_MISO() == 1){ByteSend |= 0x01;} //如果M接收到的数据是1,就放到最低位
		MySPI_W_SCK(0);
	}
	
	return ByteSend;
}

// 模式1交换一个字节【优化：移位模型】
//uint8_t MySPI_SwapBytebyMode1(uint8_t ByteSend)
//{
//	uint8_t i;
//	
//	for (i = 0; i < 8; i ++)
//	{
//		MySPI_W_SCK(1);
//		MySPI_W_MOSI(ByteSend & 0x80); //输出最高位
//		ByteSend <<= 1; //最低位自动补0
//		MySPI_W_SCK(0);
//		if (MySPI_R_MISO() == 1){ByteSend |= 0x01;} //如果M接收到的数据是1,就放到最低位
//		
//	}
//	
//	return ByteSend;
//}

// 模式3交换一个字节【所有出现SCK的地方0变1，1变0】
//uint8_t MySPI_SwapBytebyMode1(uint8_t ByteSend)
//{
//	uint8_t i;
//	
//	for (i = 0; i < 8; i ++)
//	{
//		MySPI_W_SCK(0);
//		MySPI_W_MOSI(ByteSend & 0x80); //输出最高位
//		ByteSend <<= 1; //最低位自动补0
//		MySPI_W_SCK(1);
//		if (MySPI_R_MISO() == 1){ByteSend |= 0x01;} //如果M接收到的数据是1,就放到最低位
//		
//	}
//	
//	return ByteSend;
//}
