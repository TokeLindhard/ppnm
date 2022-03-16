using System;
using static System.Console;
using static System.Math;

class main{

    public static double erf(double z){
        Func<double,double> f = x => Exp(-x*x);
        return integrate.quad(f,0,z)*2/Sqrt(PI);
    }
    public static void Main(){
        Func<double,double> f = delegate(double x){return Log(x)/Sqrt(x);};
        double result1 = integrate.quad(f,0,1);
        WriteLine($"result1 is {result1}");

        //result for error function
        double result2 = erf(2);
        WriteLine($"result2 is {result2}");
    }
}