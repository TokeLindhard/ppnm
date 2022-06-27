using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		WriteLine("_______________The implementation is testing on different integrals_________________");
	
		Func<double, double> Sqrtx = (x => Sqrt(x));
		Func<double, double> InvSqrtx = (x => 1/(Sqrt(x)));
		Func<double, double> FourSqrt = (x => 4*Sqrt(1-x*x));
		Func<double, double> LnSqrt = (x => Log(x)/Sqrt(x));
	
		// The limits of the integrals
		double a = 0.0;
		double b = 1.0;
	
		// The intgrals
		double integral1 = Integator.integrate(Sqrtx, a, b);
		double integral2 = Integator.integrate(InvSqrtx, a, b);
		double integral3 = Integator.integrate(FourSqrt, a, b);
		double integral4 = Integator.integrate(LnSqrt, a, b);
	
	
		WriteLine($"Integral of sqrt(x) from 0 to 1 is given as {integral1}, which analytically gives 2/3");
		WriteLine($"Integral of 1/sqrt(x) from 0 to 1 is given as {integral2}, which analytically gives 2");
		WriteLine($"Integral of 4*sqrt(1-x^2) from 0 to 1 is given as {integral3}, which analytically gives pi");
		WriteLine($"Integral of ln(x)/sqrt(x) from 0 to 1 is given as {integral4}, which analytically gies -4");
		
	
		using(var outfile = new System.IO.StreamWriter("errfunc.txt")){
			for(double x = -3.0; x <=4.0; x+= 1.0/8.0){
				outfile.WriteLine($"{x} {errfunc(x)}");
				}
	
		}

	} // afslutter Main

	public static double errfunc(double z){
		double a = 0.0;
		double b = z;
		
		Func<double, double> intfunc = t => Exp(-Pow(t,2));
		return 2/Sqrt(PI)*Integator.integrate(intfunc, a, b);

	} // afslutter errfunc

} // afslutter main
