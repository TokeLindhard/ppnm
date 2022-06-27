using System;
using static System.Math;
using static System.Console;

public class main{

	public static void Main(){
		WriteLine("Jeg vil teste min fremgangsmetode på integraler med kendte løsninger:");
		int interval = 1000000;		

		//Eksempel 1
		WriteLine("Jeg regner integralet x^2 + y^2. For a vil jeg bruge grænserne [0, 10], og for y vil jeg bruge [3,8].");
		Func<vector, double> f1 = xy => xy[0]*xy[0] + xy[1]*xy[1];
		vector a1 = new double[] {0,3};
		vector b1 = new double[] {10,8};
		var result1 = MonteCarlo.plainmc(f1, a1, b1, interval);
		WriteLine($"Resultatet giver {result1.Item1} med usikkerhed {result1.Item2}");
		WriteLine("Det rigtige svar er: 3283");		

		//Eksempel 2
		WriteLine("Jeg regner integralet x/y^2. For at a vil jeg bruge grænserne [0,39], og for y vil jeg bruge [42,69].");
		Func<vector,double> f2 = xy => xy[0]/(xy[1]*xy[1]);
		vector a2 = new double[] {0,42};
		vector b2 = new double[] {39,69};
		var result2 = MonteCarlo.plainmc(f2, a2, b2, interval);
		WriteLine($"Resultatet giver {result2.Item1} med usikkerhed {result2.Item2}");
		WriteLine("Det rigtige svar er: 7");

		WriteLine(" ----------Jeg løser opgaven---------- ");
		Func<vector,double> f3 = xyz => 1.0/(Pow(PI,3)*(1.0 - Cos(xyz[0])*Cos(xyz[1])*Cos(xyz[2])));
		vector a3 = new double[] {0,0,0};
		vector b3 = new double[] {PI,PI,PI};
		var result3 = MonteCarlo.plainmc(f3, a3, b3, interval);
		WriteLine($" Resultatet giver {result3.Item1} med usikkerhed {result3.Item2}");
		WriteLine("Det rigtige svar er: 1.39");

	} // afslutter Main



} // afslutter main
