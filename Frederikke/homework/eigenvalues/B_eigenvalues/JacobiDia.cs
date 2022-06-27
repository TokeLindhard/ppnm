using System;
using static System.Math;


public class JacobiDia{
	public static void timesJ(matrix A, int p, int q, double theta){
		double c = Cos(theta);
		double s = Sin(theta);
		for(int i=0; i<A.size1; i++){
			double aip = A[i,p];
			double aiq = A[i,q];
			A[i,p] = c*aip - s*aiq;
			A[i,q] = s*aip + c*aiq;

		}//afslutter for

	}//afslutter timesJ

	public static void Jtimes(matrix A, int p, int q, double theta){
		double c = Cos(theta);
		double s = Sin(theta);
		for(int j=0; j<A.size1; j++){
			double apj = A[p,j];
			double aqj = A[q,j];
			A[p,j] = c*apj + s*aqj;
			A[q,j] = -s*apj + c*aqj;

		}//afslutter for
	}//afslutter Jtimes


	public static (matrix, matrix) cyclic(matrix A){
		matrix D = A.copy();
		int n = A.size1;
		matrix V = matrix.id(n);
		
		bool changed;
		do{
			changed=false;
			for(int p=0;p<n-1;p++){
				for(int q=p+1;q<n;q++){
					double Dpq=matrix.get(D,p,q);
					double Dpp=matrix.get(D,p,p);
					double Dqq=matrix.get(D,q,q);
					double theta=0.5*Atan2(2*Dpq,Dqq - Dpp);
					double c=Cos(theta);
					double s=Sin(theta);
					double new_Dpp=c*c*Dpp - 2*s*c*Dpq + s*s*Dqq;
					double new_Dqq=s*s*Dpp + 2*s*c*Dpq + c*c*Dqq;
					if(new_Dpp != Dpp || new_Dqq != Dqq){
						changed = true;
						timesJ(D,p,q, theta);
						Jtimes(D,p,q,-theta); // A←J^T*A*J 
						timesJ(V,p,q, theta); // V←V*J
					}// afslutter if
				}// afslutter for
			}// afslutter for
		}while(changed);
		return (D,V);


	}// afslutter jacobi.cyclic


}//slutter_JacobiDia

