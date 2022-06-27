using System;
using static System.Math;


public static class InIt{

	public static (double, vector) inverse_iteration(matrix A, double s, vector b, double acc){
		matrix B = new matrix(A.size1, A.size2);
		matrix ID = matrix.id(A.size1);
						
		for(int i = 0; i<A.size1; i++){
			for(int j = 0; j < A.size1; j++){
				B[i,j] = A[i,j] - s*ID[i,j];
	
			}
		}
		
		qrgs decomp = new qrgs(B);
		vector xnew  = decomp.solve(b);

		double lambdanew = s + ((xnew.dot(b))/(xnew.dot(xnew)));

		do{
			vector xold = xnew.copy();
			double lambdaold = lambdanew;
			
			xnew = decomp.solve(xold);
			lambdanew = s + (xnew.dot(xold))/(xnew.dot(xnew));
			Console.WriteLine($"lambdanew={lambdanew}");

			if(Abs(lambdanew - lambdaold)<acc){	
				break;
			}

			double norm=xnew.norm();
			xnew/=norm;

		}while(true);
		return (lambdanew, xnew);
		


	}	
		


}


