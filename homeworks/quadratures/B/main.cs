using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        int ncalls1 = 0;
        int ncalls2 = 0;
        Func<double,double> f1 = x => {ncalls1++; return 1/Sqrt(x);}; //functions to integrate
        Func<double,double> f2 = x => {ncalls2++; return Log(x)/Sqrt(x);};

        double a = 0.0; //integration limits
        double b = 1.0; 
        
        double int1 = quad.integrate(f1,a,b, delta:1e-6,epsilon:1e-6);
        double int2 = quad.integrate(f2,a,b, delta:1e-6,epsilon:1e-6);
        WriteLine($"Without transforming 1/sqrt(x) yields {int1} using {ncalls1} calls");
        WriteLine($"Without transforming log(x)/sqrt(x) yields {int2} using {ncalls2} calls");

        ncalls1 = 0; //resetting the amount of calls, before calling them again with transformation
        ncalls2 = 0;

        double trans1 = quad.CCtransformation(f1,a,b, delta:1e-6,epsilon:1e-6);
        double trans2 = quad.CCtransformation(f2,a,b,delta:1e-6,epsilon:1e-6);

        WriteLine($"With the transformation 1/sqrt(x) yields {trans1} using {ncalls1} calls");
        WriteLine($"With the transformation log(x)/sqrt(x) yields {trans2} using {ncalls2} calls");

        WriteLine($"Python integrating 1/sqrt(x) yields 1.9999999999999993 after 231 calls");
        WriteLine($"Python integrating log(x)/sqrt(x) yields -3.9999999999999827 after 315 calls");

    }
}