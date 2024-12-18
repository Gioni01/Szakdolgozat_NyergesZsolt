/******************************************************************************
* Include files
******************************************************************************/
#include "peripherals.h"
#include <avr/io.h>
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
* Function:         void port_init(void)
* Description:      I/O portok inicializálása
* Input:
* Output:
* Notes:
******************************************************************************/
void port_init(void)
{
	DDRA = (1<<PA4) |(1<<PA3) | (1<<PA2) | (1<<PA1) | (1<<PA0);
	DDRE = 0x00;
	PORTE = 0xff;
}
/******************************************************************************
* Function:         void timer_init(void)
* Description:      Timer 0 inicializ?l?sa
* Input:
* Output:
* Notes:
******************************************************************************/
void timer_init(void)
{
	TCCR0A = (0<<WGM00) | (1<<WGM01) | (1<<CS02) | (0<<CS01) | (1<<CS00);
	OCR0A = 77;
	TIMSK0 = TIMSK0 | (1 << OCIE0A);
}

