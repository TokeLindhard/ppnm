using System;
using static System.Math;


public static class InIt{

	public static (double, vector) inverse_iteration(matrix A, double s, vector b, double acc){
		matrix B = new matrix(A.size1, A.size2);
		matrix ID = matrix.id(A.size1);
						
		for(int i = 0; i<A.size1; i++){
			for(int j = 0; j < A.size1; j++){
				B[i,j] = A[i,j] - s*ID[i,j];  // A - sI 
	
			}
		}
		
		// QR decompsition
		qrgs decomp = new qrgs(B);
		vector xnew  = decomp.solve(b);

		// Define λ_new - eigenvalue	
		double lambdanew = s + ((xnew.dot(b))/(xnew.dot(xnew)));

		do{
			vector xold = xnew.copy(); // x_old takes the value of x_new 
			double lambdaold = lambdanew; // λ_old is defined as the value of λ_new
			
			xnew = decomp.solve(xold); // a new value for x_new is calcuated using QR-decomposition
			lambdanew = s + (xnew.dot(xold))/(xnew.dot(xnew)); // calculates new value for λ_new 
			
			if(Abs(lambdanew - lambdaold)<acc){	
				break;
			}

			double norm=xnew.norm();
			xnew/=norm;

		}while(true);
		return (lambdanew, xnew);
		


	}	
		


}


