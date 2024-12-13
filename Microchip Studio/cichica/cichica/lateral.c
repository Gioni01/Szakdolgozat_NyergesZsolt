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
* Description:		oldalir�ny� j�rm�dinamika
* Input:
* Output:
* Notes:
******************************************************************************/
void update_lateral(double *x, double *y,  double *theta, double v, double delta, double L, double dt, uint8_t *sign, double *delta_x, double *delta_y, double *delta_theta)
 {
	
	*delta_x = v * cos(*theta) * dt;
	double new_x = *x + *delta_x;
	//double new_x = *x + v * cos(*theta) * dt;
	//double new_y = *y + v * sin(*theta) * dt;
	*delta_y = v * sin(*theta) * dt;
	double new_y = *y + *delta_y;
	//double new_theta = *theta + (v / L) * tan(delta) * dt;
	*delta_theta = /*(v / L) **/ tan(delta) * dt;
	double new_theta = *x + *delta_theta;  
	
	
// 	*x = new_x;
// 	*y = new_y;
// 	*theta = new_theta;
	if (new_theta < 0)
	{
		*sign = 1;
	}
	else
	{
		*sign = 0;
	}
}


/******************************************************************************
* Interrupt Routines
******************************************************************************/






