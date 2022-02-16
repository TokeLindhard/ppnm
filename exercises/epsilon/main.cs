using System;
using static System.Console;
using static System.Math;

public static class main{
	static void integers(){
		int i = 1;
		while(i+1>i){
			i++;
		}
		WriteLine("my max int = {0}",i);
		
		while(i-1<i){
			i--;
		}
		WriteLine("my min int = {0}",i);

	}
	static void MachEpsilon(){
		double x = 1;
		while(1+x != 1){x/=2;}
		x*=2;
		float y = 1F;
		while((float)(1F+y) != 1F){y/=2F;}
		y*=2F;
		WriteLine($"epsilon for double: {x}");
		WriteLine($"and should be {Pow(2,-52)}");;
		WriteLine($"epsilon for float: {y}");
		WriteLine($"and should be {Pow(2,-23)}");
	}

	static void Tiny(){
		int n = (int)1e6;
		double epsilon = Pow(2,-52);
		double tiny = epsilon/2;
		double sumA=0, sumB=0;

		sumA+=1; for(int i=0;i<n;i++){sumA+=tiny;}
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

		for(int i=0; i<n; i++){sumB+=tiny;} sumB+=1;
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
		WriteLine("Assuming what happens is that when adding a tiny number to 1, it will neglect that difference, and thus it will keep on being 1, whereas addding small numbers together will eventually give one, which we then add one to, giving roughly 2.");	
	}

	static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
		WriteLine($"Abs(a-b): {Abs(a-b)}");
		WriteLine($"Abs(a-b)/(Abs(a)+Abs(b))): {(Abs(a-b)/(Abs(a)+Abs(b)))}");
		return (Abs(a-b)<tau) || (Abs(a-b)/(Abs(a)+Abs(b))<epsilon);
		}
	
	static void Approx(){
		double a = 1;
		double b = a - 1e-9;
		WriteLine($"approx(1,1+1e-9) = {approx(a,b)} hopefully True");

		b = 2;
		WriteLine($"approx(1,2) = {approx(a,b)} hopefully False");
	}




	public static void Main(){
		integers();
		WriteLine();
		
		MachEpsilon();
		WriteLine();

		Tiny();
		WriteLine();

		Approx();
		WriteLine();
	}
}
