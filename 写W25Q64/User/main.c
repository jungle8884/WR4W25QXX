#include "stm32f10x.h" 
#include <stdio.h>
#include <string.h>
#include "Delay.h"
#include "OLED.h"
#include "W25Q64.h"
#include "Serial.h"


#define WRITE_SIZE_PER		 4096

uint32_t wAddress = 0x000000;
uint32_t finalAddress = 0x1FFFFF;
uint8_t MID;
uint16_t DID;

int main(void)
{
	W25Q64_RELEASE_POWER_DOWN();
	Delay_s(1);
	
	OLED_Init();
	Serial_Init();
	W25Q64_Init();
	
	OLED_Clear();
	OLED_ShowString(1, 1, "MID:   DID:");
	Delay_s(1);
	W25Q64_ReadID(&MID, &DID);
	OLED_ShowHexNum(1, 5, MID, 2);
	OLED_ShowHexNum(1, 12, DID, 4);
	
	OLED_ShowString(2, 1, "Erase Start...");
	OLED_ShowString(3, 1, "Erasing...");
//	W25Q64_ChipErase();
	W25Q64_SectorErase(wAddress);
	OLED_ShowString(4, 1, "Erase Over...");
	
	
	uint32_t cnt = 0;
	while (1)
	{
		if (Serial_GetRxFlag() == 1)
		{		
			OLED_Clear();
			OLED_ShowString(1, 1, "Writing...");
			OLED_ShowString(2, 1, "Addr:");
			OLED_ShowHexNum(2, 6, wAddress, 6);
			
			//memcpy(destinationArray, sourceArray, size);
			memcpy(Serial_TxPacket, Serial_RxPacket, WRITE_SIZE_PER);
			
			//写入 WRITE_SIZE_PER
			W25Q64_SectorProgram(wAddress, Serial_RxPacket, WRITE_SIZE_PER);
			wAddress+=WRITE_SIZE_PER;
			W25Q64_SectorErase(wAddress);
			
			OLED_ShowString(3, 1, "-->");
			OLED_ShowNum(3, 4, ++cnt, 4);  // 最多2M=512*4KB
			OLED_ShowString(3, 8, " * 4096");
			OLED_ShowHexNum(4, 5, wAddress-1, 6);
			
//			Serial_SendPacket(); //可以检测接收是否正确
			if(wAddress >= finalAddress){return 0;}
		} 
	}

}
