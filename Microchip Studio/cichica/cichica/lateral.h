#ifndef _LATERAL_H
#define _LATERAL_H

/******************************************************************************
* Include files
******************************************************************************/
#include <inttypes.h>

/******************************************************************************
* Types
******************************************************************************/


/******************************************************************************
* Constants
******************************************************************************/


/******************************************************************************
* Macros
******************************************************************************/

/******************************************************************************
* Global Function Declarations
******************************************************************************/
void update_lateral(double *x, double *y, double *theta, double v, double delta, double L, double dt, uint8_t *sign, double *delta_x, double *delta_y, double *delta_theta);
#endif