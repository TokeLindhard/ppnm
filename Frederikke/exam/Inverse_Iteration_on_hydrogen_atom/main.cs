using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main {
	public static void Main(){
		QRdecomp();


	} // afslutter Main

	public static void QRdecomp(){

		// Building the matrix for the hydrogen atom
		double rmax = 10;
		double dr = 0.3;
		int npoints = (int)(rmax/dr) - 1;
		vector r = new vector(npoints);
		for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
			  matrix.set(H,i,i,-2);
			  matrix.set(H,i,i+1,1);
       		          matrix.set(H,i+1,i,1);
			  }
		matrix.set(H,npoints-1,npoints-1,-2);
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
	
		// Using Jacobi to find an eigenvector for the hydrogen atom		
		matrix D;
		matrix V;
		(D,V) = JacobiDia.cyclic(H);
		// V is a matrix of eigenvector. I only need one eigenvector. 
		vector EigenVecH = V[0];

		// Defining values
		double H_lambda_new;
		vector H_vector_new;
		
		double acc = 1e-9; // accuracy
		double sH = 0.8;   // shift-factor

		WriteLine("____________Calculation the eigenvector and eigenvalue for the hydrogen atom:_________________");

		(H_lambda_new, H_vector_new) = InIt.inverse_iteration(H, sH, EigenVecH, acc);
		WriteLine();
		WriteLine("New eigenvalue for hydrogen atom:");
		WriteLine($" {H_lambda_new}");
		WriteLine();
		WriteLine("New eigenvector:");
		H_vector_new.print();
	
		WriteLine("I will check that Hx = λx, by using Hx - λx = 0:");	
		WriteLine("Checking:");
		vector H_check = (H * H_vector_new) - (H_lambda_new * H_vector_new);
		H_check.print("Helium mismatch");

	} // afslutter QRdecomp



} // afslutter main

