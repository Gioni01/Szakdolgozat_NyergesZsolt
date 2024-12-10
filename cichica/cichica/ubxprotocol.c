/******************************************************************************
* Include files
******************************************************************************/

#include <avr/io.h>
#include <inttypes.h>
#include <avr/interrupt.h>

#include <avr/delay.h>
#include <stdio.h>
/******************************************************************************
* Macros
******************************************************************************/


/******************************************************************************
* Constants
******************************************************************************/


/******************************************************************************
* Global Variables
******************************************************************************/


/******************************************************************************
* External Variables
******************************************************************************/


/******************************************************************************
* Local Function Declarations
******************************************************************************/


/******************************************************************************
* Local Function Definitions
******************************************************************************/


/******************************************************************************
* Global Function Definitions
******************************************************************************/
/******************************************************************************
* Function:         void update_lateral(double *x, double *y, double *theta, double v, double delta, double L, double dt)
* Description:		oldalirányú jármûdinamika
* Input:
* Output:
* Notes:
******************************************************************************/
void ubx_prot_arraymake(double *x, double *y, uint8_t *sign, double *theta, double *delta_x, double *delta_y, double *delta_theta)
{
	*x = *x + *delta_x;
	*y = *y + *delta_y;
	*theta = *theta + *delta_theta;
	
	if (*x < 0)
	{
		*sign |= (1 << 2);
	}
	if (*y < 0)
	{
		*sign |= (1 << 1);
	}
	if (*theta < 0)
	{
		*sign |= (1 << 0);
	}
	
	
	//bináris tömbbé
	uint16_t hossz=20;
	uint8_t ubx_array[hossz];
	
	ubx_array[0] = 0xb5;
	ubx_array[1] = 0x62;
	ubx_array[2] = 0x01;
	ubx_array[3] = hossz >> 8;
	ubx_array[4] = hossz;
	
	uint32_t temp_x = (uint32_t)(*x*10000);
	uint32_t temp_y = (uint32_t)(*y*10000);
	uint32_t temp_theta = (uint32_t)(*theta*100000);
	
	//5-8: x; 9-12: y; 13-16: theta
	ubx_array[5] = temp_x >> 24;
	ubx_array[6] = temp_x >> 16;
	ubx_array[7] = temp_x >> 8;
	ubx_array[8] = temp_x;
	ubx_array[9] = temp_y >> 24;
	ubx_array[10] = temp_y >> 16;
	ubx_array[11] = temp_y >> 8;
	ubx_array[12] = temp_y;
	ubx_array[13] = temp_theta >> 24;
	ubx_array[14] = temp_theta >> 16;
	ubx_array[15] = temp_theta >> 8;
	ubx_array[16] = temp_theta;
	
	uint8_t verysign=*sign;
	
	ubx_array[17] = verysign;
	
	//checksum kiszámítása
	
	uint8_t CK_A = 0;
	uint8_t CK_B = 0;

	for (int i = 0; i < 12; i++)
	{
		CK_A += ubx_array[2+i];
		CK_B += CK_A;
	}
	
	ubx_array[18] = CK_A;
	ubx_array[19] = CK_B;
	
	for (uint8_t i = 0; i < 20; i++)
	{
		uart_0_transmit(ubx_array[i]);
	}
	*sign = 0;
}


/******************************************************************************
* Interrupt Routines
******************************************************************************/






