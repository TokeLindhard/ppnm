using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main {
	public static void Main(){
		QRGSdecomp();
		matrixCalc();
	}

	public static void QRGSdecomp(){
		int n = 6;
		int m = 4;		

		matrix A = new matrix(n,m);
		Random ran = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				A[i,j] = ran.Next(15);
			}
		}

		WriteLine($"This is matrix A:");
		A.print();
		var QRA = new qrgs(A);
	
		WriteLine("Q is given as");
		QRA.Q.print();

		WriteLine("R is given as");
		QRA.R.print();

		WriteLine("Performing a check to see if R is upper triangular");
		for(int i=0; i<QRA.R.size1; i++){
			for(int j=0; j<i; j++){
			WriteLine($"{matrix.approx(QRA.R[j][i],0)}");
			}
		}
	
		//Transposing Q
		var TQ = QRA.Q.transpose();
		WriteLine($"the transpose of Q is: ");
		TQ.print();
	
		matrix QtQ = QRA.Q.transpose()*QRA.Q;
		WriteLine($"Q^T*Q is approximately I: {QtQ.approx(matrix.id(m))}");
		WriteLine($"Q*R is approximately A: {(QRA.Q*QRA.R).approx(A)}");
		WriteLine();
	}

	public static void matrixCalc(){
		WriteLine("Test of the solution to Ax=b");
		int l = 4;

		matrix A = new matrix(l,l);
		vector b = new vector(l);
		Random ran = new Random();
		for(int i=0; i<l; i++){
			b[i] = ran.Next(15);
			for(int j=0; j<l; j++){
				A[i,j] = ran.Next(15);
			}

		}

		WriteLine($"The new matrix A is calculated as:");
		A.print();
		WriteLine($"The new vector b is calculated as:");
		b.print();

		qrgs QRA = new qrgs(A);
		var x = QRA.solve(b);
		
		var Ax=A*x;
		Ax.print("I will check if Ax=b. This should be equal to b :\n");
		if(vector.approx(Ax,b)) WriteLine("It is correct!");
		else WriteLine("It is not correct :(");


	}


}
 
