#include "stm32f10x.h"  
#include "Delay.h"
#include "OLED.h"
#include "W25Q64.h"
#include "Serial.h"

#define READ_SIZE_PER					4096

uint32_t rAddress = 0x000000;
uint32_t finalAddress = 0x1FFFFF;		//2M


// 断电读取数据: 读取以4K为单位
void ReadData(uint16_t size) 
{
	uint32_t start = 0;
	uint32_t end = (READ_SIZE_PER * size) -1;
	
	OLED_ShowHexNum(1, 1, start, 6);
	OLED_ShowHexNum(1, 8, end, 6);
	
	OLED_ShowString(2, 1, "size:");
	OLED_ShowNum(2, 6, size, 4);

	uint16_t i;
	for(i = 0; i < size; i++)
	{
		OLED_ShowString(3, 1, "i:");
		OLED_ShowNum(3, 3, i, 4);
			
		W25Q64_ReadData(start, Serial_TxPacket, READ_SIZE_PER);
		Serial_SendPacket();
		start+=0x001000;
			
		OLED_ShowString(4, 1, "addr:");
		OLED_ShowHexNum(4, 7, start, 6);
		
		Delay_s(1);
		if(start > end) {return;}
	}
	
	
}


int main(void)
{
	Delay_s(3);
	
	OLED_Init();
	Serial_Init();
	W25Q64_Init();
	
	// 断电读取数据
	uint16_t time4K = 10;
	ReadData(time4K);
	
	
	while (1)
	{
		
	}

}
