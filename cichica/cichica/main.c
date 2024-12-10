/******************************************************************************
 * Created: 2024/2025/1
 * Author : Nyerges Zsolt
******************************************************************************/
 /******************************************************************************
* Include files
******************************************************************************/
#include <avr/io.h>
#include <inttypes.h>
#include <avr/interrupt.h>
#define F_CPU 16000000UL
#include <avr/delay.h>
#include <stdio.h>
#include "lcd.h"
#include "uart.h"
#include "can.h"
#include "longitudinal.h"
#include "lateral.h"
#include "ubxprotocol.h"

/******************************************************************************
* Macros
******************************************************************************/
#define PD0_ENA_DELAY 80
#define TRUE 1
#define FALSE 0

/******************************************************************************
* Constants
******************************************************************************/

/******************************************************************************
* Global Variables
******************************************************************************/
uint16_t timer_cnt=0;
uint8_t timer_task_10ms=0, timer_task_100ms=0, timer_task_500ms=0, timer_task_1s=0;
uint8_t PB0_pushed = 0, PD0_re_enable_cnt = 0;
uint16_t ad_value =0;
uint8_t PE2_lenyomva, PE7_lenyomva =0;

uint8_t can_rx_data[5];
uint32_t can_rx_id = 0x00000011;
uint8_t can_rx_extended_id = FALSE;
uint8_t can_rx_length;
uint8_t can_msg_received=FALSE;

uint8_t adat = 0;
uint8_t received_data = FALSE;
uint8_t sign = FALSE;
uint8_t can_tx_data[8];
double steering_angle = 0;
uint16_t throttle = 0;
uint16_t brake = 0;
uint8_t kickdown = 0;
double v = 0;
double delta_x = 0;
double delta_y = 0;
double delta_theta = 0;

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
* Function:         int main(void)
* Description:      main function
* Input:            
* Output:
* Notes:            
******************************************************************************/
int main(void)
{
	port_init();
	timer_init();
	external_int_init();
	ad_init();
	lcd_init();
	uart_0_init(BAUD9600);
	can_init();
	sei();
	
	double x, y, theta = 0;
	int accel=7, delta=5, L=6;
	double dt=0.01;
	
	//Endless loop
	while(1)
	{
		can_MOb0_init(can_rx_id);	
// 		if (received_data)
// 		{
// 			uart_0_transmit(adat);
// 			received_data = FALSE;
// 		}	
		
		if(can_msg_received)
		{
 			double steering_deg = 80;
/*			double steering_deg = (can_rx_data[1] << 8 | can_rx_data[0])*0.04;*/
 			steering_angle = steering_deg*M_PI / 180.0;
// 			throttle = (can_rx_data[3] & 0x03) << 8 | can_rx_data[2];
// 			brake = (can_rx_data[4] & 0x0F) << 6 | can_rx_data[3] >> 2;
// 			kickdown = (can_rx_data[4] & 0x10) >> 4;
			
			if (kickdown == TRUE)
			{
				throttle = 1000;
				brake = 0;
			}
			
			throttle = 500;
			brake = 0;
 			
						
			v = update_longitudinal(throttle,brake,dt);
			
			update_lateral(&x,&y,&theta,v,steering_angle,4,dt,&sign,&delta_x,&delta_y,&delta_theta);
			
			
			//ubx_prot_arraymake(&x,&y,&sign,&theta);
			
			
			
			can_msg_received=0;
		}



		if(timer_task_10ms)
		{
			
			
			uint8_t tx_hossz = 8;
			uint8_t can_tx_data[tx_hossz];
			
			uint16_t temp_x = (uint16_t)(x*10000);
			uint16_t temp_y = (uint16_t)(y*10000);
			uint8_t temp_theta = (uint8_t)(theta*100000);
			uint16_t temp_v = (uint16_t)(v*1000);
			
			can_tx_data[0] = temp_x >> 4;
			can_tx_data[1] = temp_x << 4 | temp_y >> 8;
			can_tx_data[2] = temp_y;
			can_tx_data[3] = temp_v;
			can_tx_data[4] = temp_v >> 8;
			can_tx_data[5] = temp_theta >> 14;
			can_tx_data[6] = temp_theta >> 6;
			can_tx_data[7] = temp_theta << 2;
			
			CAN_SendMob(1,0x00000022,FALSE,tx_hossz,&can_tx_data);

			if((PINE & (1<<PE2)) == 0) PE2_lenyomva = 1;
			if (PE2_lenyomva == 1 && (PINE & (1<<PE2)) !=0)
			{
				PORTA ^= (1<<PA1);
				x = 0;
				y = 0;
				theta = 0;
				PE2_lenyomva = 0;
			}
			
			if((PINE & (1<<PE7)) == 0) PE7_lenyomva = 1;
			if (PE7_lenyomva == 1 && (PINE & (1<<PE7)) !=0)
			{
				PORTA ^= (1<<PA4);
				can_msg_received = TRUE;
				
				PE7_lenyomva = 0;
			}
			
			
			timer_task_10ms = 0;
		}
		
		if(timer_task_100ms)
		{
			PORTA ^= (1<<PA0);
// 			CAN_SendMob(1,0x000007FF,TRUE,2,can_tx_data);
			
			ubx_prot_arraymake(&x,&y,&sign,&theta,&delta_x,&delta_y,&delta_theta);

			char write_string[50];
			sprintf(write_string,"x=%4d, y=%4d", (uint16_t)x, (uint16_t)y);
			lcd_set_cursor_position(0);
			lcd_write_string(write_string);
			sprintf(write_string,"deg=%3d", (uint8_t)(theta));
			lcd_set_cursor_position(50);
			lcd_write_string(write_string);
			
			timer_task_100ms =0;
			
		}
		if (timer_task_1s)
		{
			
		}
		
	

	}
}
/******************************************************************************
* Interrupt Routines
******************************************************************************/
ISR(TIMER0_COMP_vect) //timer megszakítás
{
	timer_cnt++;
	if((timer_cnt % 1) == 0) timer_task_10ms=1;
	if((timer_cnt % 10) == 0) timer_task_100ms=1;
	if((timer_cnt % 50) == 0) timer_task_500ms=1;
	if((timer_cnt % 100) == 0) timer_task_1s=1;
}

ISR(INT0_vect) //external interrupt
{
	if(PD0_re_enable_cnt == PD0_ENA_DELAY) //pergésmentesítés logika
	{
		PORTA ^=0x02;
		PD0_re_enable_cnt=0;
	}
	
}

ISR(ADC_vect) //AD megszakítás
{
	ad_value = ADC;
}

ISR(USART0_RX_vect) //UART adat fogadás megszakítás
{
	adat = UDR0;
	received_data = TRUE;
	
// 	char c = UDR0;
// 	if(c == 0x7F)
// 		lcd_clear_display();
// 	else
// 		lcd_write_char(c);
}

ISR(CANIT_vect) //CAN megszakítás
{
	uint8_t i, dlc = 0;
	
	CANPAGE = 0;	// select MOb0, reset FIFO index
	
	//uart_0_transmit(88);

	if ( (CANSTMOB & (1<<RXOK)) != FALSE)	// Receive Complete
	{
		
		dlc = CANCDMOB & 0x0F;
		
		for (i=0; i<dlc; i++) can_rx_data[i] = CANMSG;
		
		CANSTMOB &= ~(1<<RXOK);	// clear RXOK flag
		CAN_ReceiveEnableMob(0, can_rx_id, can_rx_extended_id, 8);	// enable next reception  on mob 0
	}
	can_rx_length=dlc;
	can_msg_received=1;
	PORTA = PORTA ^ (1<<PA7);
}