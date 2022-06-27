using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main(){
		WriteLine("___________The implementation is testing on different integrals___________");
	
		int ncalls1 = 0;
		int ncalls2 = 0;

		Func<double, double> InvSqrtx = x => {ncalls1++; return 1/(Sqrt(x));};
		Func<double, double> LnSqrt = x => {ncalls2++; return Log(x)/Sqrt(x);};
	
		// The limits of the integrals
		double a = 0.0;
		double b = 1.0;
		double delta = 1e-6;
		double epsilon = 1e-6;	
	
		// The intgrals
		double integral2 = Integator.integrate(InvSqrtx, a, b, delta, epsilon);
		double integral4 = Integator.integrate(LnSqrt, a, b, delta, epsilon);
		WriteLine();
		WriteLine();		
		WriteLine("_____________Calculations without the transformation:_____________");

		WriteLine($"Integral of 1/sqrt(x) gives: {integral2}. The number of evaluations: {ncalls1}.");

		WriteLine($"Integral of ln(x)/sqrt(x) is given as: {integral4}. The number of evaluations is: {ncalls2}. ");
		
		// Resetting the amount of calls before using them for the transformation
		ncalls1 = 0;
		ncalls2 = 0;


		double transformation1 = Integator.CC_var_trans(InvSqrtx, a, b, delta, epsilon);
		double transformation2 = Integator.CC_var_trans(LnSqrt, a, b, delta, epsilon);
		
		WriteLine();
		WriteLine();
		WriteLine($"____________Calculating with the transoformation________________");

		WriteLine($"Integral of 1/sqrt(x) gives: {transformation1} by using {ncalls1} calls.");
		WriteLine($"Integral of ln(x)/sqrt(x) gives: {transformation2} by using {ncalls2} calls.");

	WriteLine("Preforming the same integrals in python yields");

	WriteLine($"1/sqrt(x) gives: 1.9999999999999993 after 231 calls");
	        WriteLine($"log(x)/sqrt(x) gives -3.9999999999999827 after 315 calls");

	} // afslutter Main

	

} // afslutter main
