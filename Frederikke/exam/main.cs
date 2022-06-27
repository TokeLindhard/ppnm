using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main {
	public static void Main(){
		QRdecomp();


	} // afslutter Main

	public static void QRdecomp(){
		int n = 7;
		int m = n;
		double acc = 1e-9;
		double s = 3.5;

		matrix A = new matrix(n,m);
		vector MyVec = new vector(n);

		Random rand = new Random();
		for(int i=0; i<n; i++){
			MyVec[i] = rand.NextDouble();
			for(int j=i; j<m; j++){
				A[i,j] = A[j,i] = rand.NextDouble();		

			} // afslutter for

		} // afslutter for
		 
		
		WriteLine($"Matrix A is given as:");
		A.print("A=");
				
		double lambda_new;
		vector vector_new;

		WriteLine("______________Calculating the eigenvector and eigenvalue with the Inverse Interation Method_____________:");
		(lambda_new, vector_new) = InIt.inverse_iteration(A, s, MyVec, acc);
		WriteLine();
		WriteLine("New eigenvalue:");
		WriteLine($" {lambda_new}");
		WriteLine();
		WriteLine("New eigenvector:");
		vector_new.print();
		
		WriteLine();
		WriteLine("I want to check my answer.");
		WriteLine("I will check that Ax = λx, by using Ax - λx = 0:");

		vector check = (A * vector_new) - (lambda_new * vector_new);
		check.print("mismatch");

		WriteLine();


	} // afslutter QRdecomp



} // afslutter main

