using static System.Console;
using static System.math;
static class math{
	static void test(){
		double x=Sin(9),y=cos(9);
		Writeline($"Sin²+cos²={x*x+y*y+Power(y,2)}"); #it is faster to write x*x than Power(x,2), since x*x is multiplication that runs faster than Power.
	}
}
