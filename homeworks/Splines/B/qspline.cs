using System;
using static System.Math;

public class qspline{
    public double[] x,y,b,c; 
    public qspline(double[] xs, double[] ys){
        this.x = xs;
        this.y = ys;
        this.b = new double[x.Length-1];
        this.c = new double[x.Length-1];

        //to calculate b and c, we must first calculate p_i using eq. 6

        double[] p = new double[x.Length-1];
        for(int i =0; i<x.Length-1; i++){
             p[i] = (y[i+1]-y[i])/(x[i+1]-x[i]);
        }

        //now we can calculate b and c using eq. 13 and eq. 15
        c[0] = 0; //one coefficient can be choosen freely. Can be done more accurately using foward and backward recursion
        for(int i = 0; i<x.Length-2; i++){
            c[i+1] = (1/(x[i+2]-x[i+1]))*(p[i+1]-p[i]-c[i]*(x[i+1]-x[i]));
        }

        for(int i=0; i<x.Length-1;i++){
          b[i] = p[i] - c[i]*(x[i+1]-x[i]);
        }


        
    }
    public double spline(double z){
        /* evaluate the spline */
        int i = binsearch(x,z);
        return y[i] + b[i]*(z-x[i]) + c[i]*Pow(z-x[i],2);
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
	public double derivative(double z){
        /* evaluate the derivative by taking analytical derivative of eq. 15 */
        int i = binsearch(x,z);
        return b[i]+2*c[i]*(z-x[i]);
    }
	public double integral(double z){
        /* evaluate the integral */
        double integral = 0;
		int idx = binsearch(x,z);
		for(int i=0; i<idx;i++){
			integral += y[i]*(x[i+1]-x[i]) + b[i]*Pow(x[i+1]-x[i],2)/2 + c[i]*Pow(x[i+1]-x[i],3)/3;
		}
		integral += y[idx]*(z-x[idx]) + b[idx]*Pow(z-x[idx],2)/2 + c[idx]*Pow(z-x[idx],3)/3; //integral of eq. 15
		return integral;
    }
}