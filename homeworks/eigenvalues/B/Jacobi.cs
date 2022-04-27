using System;
using static System.Math;

public class Jacobi{
    public static void timesJ(matrix A, int p, int q, double theta){
	    double c=Cos(theta),s=Sin(theta);
    	for(int i=0;i<A.size1;i++){
		    double aip=A[i,p],aiq=A[i,q];
		    A[i,p]=c*aip-s*aiq;
		    A[i,q]=s*aip+c*aiq;
		}
    }

    public static void Jtimes(matrix A, int p, int q, double theta){
	    double c=Cos(theta),s=Sin(theta);
	    for(int j=0;j<A.size1;j++){
		    double apj=A[p,j],aqj=A[q,j];
		    A[p,j]= c*apj+s*aqj;
		    A[q,j]=-s*apj+c*aqj;
		}
    }

    public static (matrix, matrix) cyclic(matrix A){
		matrix D = A.copy(); //creating diagonal matrix. Will become diagonal over time.
		int n = A.size1; //specifying the size of A, since we can't draw it directly from the main file creating A.
		matrix V = matrix.id(n); //making identity matrix the same size as A, will contain eigenvectors later on.
		bool changed; //makes bool that checks if there's been a change in the last sweep

		do{
			changed=false; //sets as false until we find out if another sweep is needed. Goes to true again if we do.
			for(int p=0;p<n-1;p++){
				for(int q=p+1;q<n;q++){
					double apq=matrix.get(D,p,q);
					double app=matrix.get(D,p,p);
					double aqq=matrix.get(D,q,q);
					double theta=0.5*Atan2(2*apq,aqq-app);
					double c=Cos(theta),s=Sin(theta);
					double new_app=c*c*app-2*s*c*apq+s*s*aqq;
					double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
					if(new_app!=app || new_aqq!=aqq){ // do rotation
						changed=true; //sets true as long as we need to do a rotation.
						timesJ(D,p,q, theta);
						Jtimes(D,p,q,-theta); // A←J^T*A*J 
						timesJ(V,p,q, theta); // V←V*J
					}
				}
			}
		}
		while(changed); //keeps the loop running as long as a change has happened. Will stop when a sweep no 
		//longer changes anything.
		return(D,V);
	}
}