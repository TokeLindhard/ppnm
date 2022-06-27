using System;
using static System.Math;
using static System.Double; // when we check if a double is Nan, we need to use this package

public static class Integator{

	public static double integrate( 
		Func<double,double> f,
		double a,
		double b,
		double delta = 0.001,
		double epsilon = 0.001,
		double f2 = NaN,
		double f3 = NaN)
		{
		
		double h = b - a;
		
		// first call, no points to reuse
		if(IsNaN(f2)){
			f2 = f(a + 2.0*h/6.0);
			f3 = f(a + 4.0*h/6.0);
		} // afslutter if
		
		// Assigning new points (eq. 48)
		double f1 = f(a + h/6.0);
		double f4 = f(a + 5.0*h/6.0);

		// Integral estimates with weights (eq. 49)
		double Q = (2.0*f1 + f2 + f3 + 2.0*f4)/6.0*(b - a); // higher order rule
		double q = (f1 + f2 + f3 + f4)/4.0*(b - a); // lower order rule

		double err = Abs(Q - q);

		//Recursive evalution
		if(err <= Max(delta, epsilon*Abs(Q))){ // accepts step if error is small enough. See eq. 47
				return Q;
		} // afslutter if
		// end of recursion

		else{
			return integrate(f, a, (a + b)/2.0, delta/(Sqrt(2)), epsilon, f1, f2) + integrate(f, (a + b)/2.0, b, delta/(Sqrt(2)), epsilon, f3, f4);
		} // afslutter if

	} // afslutter integrate


} //afslutter Integator
