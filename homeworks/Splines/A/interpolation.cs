using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

public static class interpol{
	public static double linterp(double[]x, double[]y, double z){
			int i=binsearch(x,z);
        	double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        	double dy=y[i+1]-y[i];
        	return y[i]+dy/dx*(z-x[i]);
    }
	public static int binsearch(double[] x, double z){// locates the interval for z by bisection 
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; 
			else j=mid;
		}
		return i;
	}

	public static double linterpInteg(double[] x, double[] y, double z){
		double integral = 0;
		int idx = binsearch(x,z);
		for(int i=0; i<idx;i++){
			double dx = x[i+1]-x[i];	
			double dy = y[i+1]-y[i];
			double pi = dy/dx; //eq 6 from notes
			integral += y[i]*(x[i+1]-x[i])+pi*Pow(x[i+1]-x[i],2)/2; //eq. 8
		}
		double p = (y[idx+1]-y[idx])/(x[idx+1]-x[idx]);
		integral += y[idx]*(z-x[idx])+p*Pow(z-x[idx],2)/2;
		return integral;
	}
}

