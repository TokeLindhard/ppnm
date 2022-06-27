using System;
using static System.Math;
using static System.Console;

public class main{

	public static void Main(){

		WriteLine("__________I will test the procedure on integrals with known solutions_____________________");
		int interval = 1000000;		

		//Eksempel 1
		WriteLine("___________________I will calculate the integral x^2 + y^2. Here, I will use the limits [0, 10] for x and [3,8] for y._________________");
		Func<vector, double> f1 = xy => xy[0]*xy[0] + xy[1]*xy[1];
		vector a1 = new double[] {0,3};
		vector b1 = new double[] {10,8};
		var resultA1 = MonteCarlo.plain_integration(f1, a1, b1, interval);
		var resultA2 = MonteCarlo.quasi_rand_seq(f1, a1, b1, interval);
		WriteLine($"By using the plain integration the result gives {resultA1.Item1} with uncertainty {resultA1.Item2}");
		WriteLine($"By using quasi random sequences the result gives {resultA2.Item1} with uncertainty {resultA2.Item2}"); 
		WriteLine();
		WriteLine("The correct answer is: 3283");		
		WriteLine();
		WriteLine("The errors in the quasi random sequences are smaller, and the result more accurate");	

		//Eksempel 2
		WriteLine("________________I will calculate the integral x/y^2. For x I will use the limits [0,39], and for y I will use [42,69]._____________");
		Func<vector,double> f2 = xy => xy[0]/(xy[1]*xy[1]);
		vector a2 = new double[] {0,42};
		vector b2 = new double[] {39,69};
		var resultB1 = MonteCarlo.plain_integration(f2, a2, b2, interval);
		var resultB2 = MonteCarlo.quasi_rand_seq(f2, a2, b2, interval);
		WriteLine($"By using plain integration the resultat gives {resultB1.Item1} with uncertainty {resultB1.Item2}");
		WriteLine($"When using quasi random sequences the resultatet becomes {resultB2.Item1} with uncertainty {resultB2.Item2}");
		WriteLine();
		WriteLine("The correct answer is: 7");
		WriteLine();
		WriteLine("Once again the error for the quasi random sequence is smaller");
	

		WriteLine("_____________ Calculating ∫0π  dx/π ∫0π  dy/π ∫0π  dz/π [1-cos(x)cos(y)cos(z)]-1_______________ ");
		Func<vector,double> f3 = xyz => 1.0/(Pow(PI,3)*(1.0 - Cos(xyz[0])*Cos(xyz[1])*Cos(xyz[2])));
		vector a3 = new double[] {0,0,0};
		vector b3 = new double[] {PI,PI,PI};
		var resultC1 = MonteCarlo.plain_integration(f3, a3, b3, N:10000000);
		var resultC2 = MonteCarlo.quasi_rand_seq(f3, a3, b3, N:10000000);		
		WriteLine($"The resultat gives {resultC1.Item1} when plain integration is used. The uncertainty is {resultC1.Item2}");
		WriteLine($"When quasi random sequences is used the resultat is {resultC2.Item1} with uncertainty {resultC2.Item2}");
		WriteLine();
		WriteLine("The correct answer is: 1.39");
		Write("Here, the integral divergives for the quasi random sequence, and the uncertainty gives NaN.");

	} // afslutter Main

} // afslutter main

