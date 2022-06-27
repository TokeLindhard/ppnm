using System;
using static System.Console;
public class main{

public static int Main(string[] args){
int n=10,N=100,i;
var x = new double[n];
var y = new double[n];
var rnd = new Random();

Write("#m=0, S=16\n");
double z=-4.5;
for(i=0; i<n; i++){
	x[i]=z;
//	y[i]=1.0/(1.0+x[i]*x[i]);
//	y[i]=x[i]>0?0.7:-0.7;
	y[i]=rnd.NextDouble();
	WriteLine($"{x[i]} {y[i]}");
	z+=1.0;
	}

double step= (x[n-1]-x[0]) / (N-1);

Write("#m=5, S=0\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	WriteLine($"{z} {interp.linear(x,y,z)}");
	}

/*
printf("#m=6, S=0\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	printf("%g %g\n",z,polinterp(n,x,y,z));
	}

cubic_spline* C = cubic_spline_alloc(n,x,y);
printf("#m=8, S=0\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	printf("%g %g\n",z,cubic_spline_eval(C,z));
	}
cubic_spline_free(C);

qspline* Q = qspline_alloc(n,x,y);
printf("#m=9, S=0\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	printf("%g %g\n",z,qspline_eval(Q,z));
	}
qspline_free(Q);

akima_spline* A = akima_spline_alloc(n,x,y);
printf("#m=10, S=0\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	printf("%g %g\n",z,akima_spline_eval(A,z));
	}
akima_spline_free(A);

printf("#m=0, S=4\n");
for(z=x[0], i=0; i<N; i++, z=x[0]+i*step){
	printf("%g %g\n",z,berrut(n,x,y,z));
	}
*/


return 0;
}//Main

}//class main

