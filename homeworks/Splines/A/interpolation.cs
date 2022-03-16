using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

public static class interpol{
	static double linterp(int n, double[]x, double[]y, double z){
        Debug.Assert(n>1 && z>=x[0] && z<=x[n-1]); //makes sure our n and z aren't running rampant
        double dy=y[i+1]-y[i], dx=x[i+1]-x[i]; Debug.Assert(dx>0); //makes sure stepsize is actually positive
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
}