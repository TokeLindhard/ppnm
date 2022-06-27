using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(){
		int n = 5;
		int m = 5;
	
		matrix A = new matrix(n,m);
		Random ran = new Random();

		for(int i=0; i<n; i++){
			for(int j=0; j<=i; j++){
				A[i,j] = ran.Next(15);
				A[j,i] = A[i,j]; 

			}//afslutter for

		}//afslutter for		

		//Printer matrix A
		WriteLine("___This is matrix A; it is a randomly generated symmetric matrix:___");
		A.print();
		WriteLine();

		//Printer matrix D
		WriteLine("___This is matrix D; it is a randomly generated diagonalised matrix:___");
		matrix D;
		matrix V;
		(D,V) = JacobiDia.cyclic(A);
		D.print();
		WriteLine();
		
		WriteLine("___This is a matrix consisting of eigenvectors:___");
		V.print();
		WriteLine();

		matrix VtAV = (V.transpose())*A*V;
		matrix VDVt = V*D*(V.transpose());
		matrix VtV = (V.transpose())*V;
		matrix VVt = V*(V.transpose());

		//Jeg printer beregningerne, og tjekker at jeg får de rigtige svar
		WriteLine("__________I will check my answers, and see if they are correct__________");
		

		WriteLine("This is V^TAV:");		
		VtAV.print();
		WriteLine("This is D:");
		D.print();		
		WriteLine($"V^TAV = D: {VtAV.approx(D)}");
		if(VtAV.approx(D)) WriteLine("It is correct");	
		else WriteLine("It is not correct");
		
		WriteLine("This is VDV^T:");		
		VDVt.print();
		WriteLine("This is A:");
		A.print();		
		WriteLine($"VDV^T = A: {VDVt.approx(A)}");
		if(VDVt.approx(A)) WriteLine("It is correct");	
		else WriteLine("It is not correct");

		WriteLine("This is VtV:");		
		VtV.print();	
		WriteLine($"VtV = 1: {VtV.approx(matrix.id(n))}");
		if(VtV.approx(matrix.id(n))) WriteLine("It is correct");	
		else WriteLine("It is not correct");

		WriteLine("This is VVt:");		
		VVt.print();		
		WriteLine($"VVt = 1: {VVt.approx(matrix.id(n))}");
		if(VVt.approx(matrix.id(n))) WriteLine("It is correct");	
		else WriteLine("It is not correct");

	}//slutter Main


}//slutter main
