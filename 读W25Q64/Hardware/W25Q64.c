#include "stm32f10x.h"                  // Device header
#include "MySPI.h"
#include "W25Q64_Ins.h"

void W25Q64_Init(void)
{
	// ���õײ�SPI��ʼ���������Ĳ���Ҫ
	MySPI_Init();
}

void W25Q64_ReadID(uint8_t *MID, uint16_t *DID)
{
	MySPI_Start(); // SS=0
	// ��ӻ����ͽ���IDָ��
	MySPI_SwapByte(W25Q64_JEDEC_ID);
	// �����õ��������͡���һ���������ݵõ����õ����ݡ�
	*MID = MySPI_SwapByte(W25Q64_DUMMY_BYTE);
	// ��8λ��ʾ�豸����
	*DID = MySPI_SwapByte(W25Q64_DUMMY_BYTE);
	*DID <<= 8;
	// �Ͱ�λ��ʾ�豸���� �����ص���8λ���ݣ�|=���Ա����߰�λ����ͬʱ�õ��Ͱ�λ���ݡ�
	*DID |= MySPI_SwapByte(W25Q64_DUMMY_BYTE);
	MySPI_Stop(); // SS=1
}

/**
  * @brief Flash�������ģʽ
  * @param ��
  * @retval �޷���ֵ
  */
void W25Q64_PowerDown(void)
{
		MySPI_Start();
		MySPI_SwapByte(W25Q64_POWER_DOWN);
		MySPI_Stop();
}

/**
  * @brief ��Flash�ӵ���ģʽ����
  * @param ��
  * @retval �޷���ֵ
  */
void W25Q64_RELEASE_POWER_DOWN()
{
	MySPI_Start(); // SS=0
	MySPI_SwapByte(W25Q64_RELEASE_POWER_DOWN_HPM_DEVICE_ID);
	MySPI_Stop(); // SS=1
}

void W25Q64_WriteEnable(void)
{
	MySPI_Start();
	MySPI_SwapByte(W25Q64_WRITE_ENABLE);
	MySPI_Stop();
}

/**
  * @brief �ȴ�״̬�Ĵ���busy = 0��оƬ��æ
  * @param ��
  * @retval ��
  */
void W25Q64_WaitBusy(void)
{
	uint32_t Timeout = 100000;
	MySPI_Start();
	MySPI_SwapByte(W25Q64_READ_STATUS_REGISTER_1);
	// busy = 1��оƬæ
	while ((MySPI_SwapByte(W25Q64_DUMMY_BYTE) & 0x01) == 0x01)
	{
		Timeout --;
		if (Timeout == 0)
		{
			break;
		}
	}
	MySPI_Stop();
}

void W25Q64_PageProgram(uint32_t Address, uint8_t *DataArray, uint16_t Count)
{
	uint16_t i;
	W25Q64_WaitBusy();
	W25Q64_WriteEnable();
	
	MySPI_Start();
	MySPI_SwapByte(W25Q64_PAGE_PROGRAM);
	// ��ָ����ַ��eg: 0x123456
	MySPI_SwapByte(Address >> 16); // 12
	MySPI_SwapByte(Address >> 8); // 001234 ��λ������MySPI_SwapByteֻ���ݵ�8λ�� -> 34
	MySPI_SwapByte(Address); //ȡ�ڰ�λ: 56
	for (i = 0; i < Count; i ++)
	{
		MySPI_SwapByte(DataArray[i]);
	}
	MySPI_Stop();
	
	
}

void W25Q64_PageErase(uint32_t Address)
{
	W25Q64_WaitBusy();
	W25Q64_WriteEnable();
	
	MySPI_Start();
	MySPI_SwapByte(W25Q64_PAGE_PROGRAM);
	MySPI_SwapByte(Address >> 16);
	MySPI_SwapByte(Address >> 8);
	MySPI_SwapByte(Address);
	MySPI_Stop();

	W25Q64_WaitBusy();
}

void W25Q64_SectorErase(uint32_t Address)
{
	W25Q64_WaitBusy();
	W25Q64_WriteEnable();
	
	MySPI_Start();
	MySPI_SwapByte(W25Q64_SECTOR_ERASE_4KB);
	MySPI_SwapByte(Address >> 16);
	MySPI_SwapByte(Address >> 8);
	MySPI_SwapByte(Address);
	MySPI_Stop();
	
	W25Q64_WaitBusy();
}

void W25Q64_BlockErase(uint32_t Address)
{
	W25Q64_WaitBusy();
	W25Q64_WriteEnable();
	
	MySPI_Start();
	MySPI_SwapByte(W25Q64_BLOCK_ERASE_64KB);
	MySPI_SwapByte(Address >> 16);
	MySPI_SwapByte(Address >> 8);
	MySPI_SwapByte(Address);
	MySPI_Stop();
	
	W25Q64_WaitBusy();
}

void W25Q64_ChipErase(void)
{
	W25Q64_WaitBusy();
	W25Q64_WriteEnable();
	
	MySPI_Start();
	MySPI_SwapByte(W25Q64_CHIP_ERASE);
	MySPI_Stop();
	
	W25Q64_WaitBusy();
}

void W25Q64_ReadData(uint32_t Address, uint8_t *DataArray, uint32_t Count)
{
	W25Q64_WaitBusy();
	
	uint32_t i;
	MySPI_Start();
	MySPI_SwapByte(W25Q64_READ_DATA);
	MySPI_SwapByte(Address >> 16);
	MySPI_SwapByte(Address >> 8);
	MySPI_SwapByte(Address);
	for (i = 0; i < Count; i ++)
	{
		DataArray[i] = MySPI_SwapByte(W25Q64_DUMMY_BYTE);
	}
	MySPI_Stop();
	
	W25Q64_WaitBusy();
}
