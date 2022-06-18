using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Func<double,double> f1 = x => Sqrt(x); //test functions
        Func<double,double> f2 = x => 1/Sqrt(x);
        Func<double,double> f3 = x => 4*Sqrt(1-Pow(x,2));
        Func<double,double> f4 = x => Log(x)/Sqrt(x);
        double a = 0.0; //integration limits
        double b = 1.0; 

        double int1 = quad.integrate(f1,a,b);
        double int2 = quad.integrate(f2,a,b);
        double int3 = quad.integrate(f3,a,b);
        double int4 = quad.integrate(f4,a,b);

        WriteLine($"integral of sqrt(x) from 0 to 1 is {int1}, which analytically is 2/3");
        WriteLine($"integral of 1/sqrt(x) from 0 to 1 is {int2}, which analytically is 2");
        WriteLine($"integral of 4*sqrt(1-x^2) from 0 to 1 is {int3}, which analytically is pi");
        WriteLine($"integral of Log(x)/sqrt(x) from 0 to 1 is {int4}, which analytically is -4");

        //Now integrating the error function, taking points from 0 to 10 as the upper limit
        Func<double,double> erf = x => 2/(Sqrt(PI))*Exp(-Pow(x,2)); 

        using(var outfile = new System.IO.StreamWriter("erf.txt")){
        for(double z=-3;z<4;z+=1.0/16.0){
            outfile.WriteLine($"{z} {quad.integrate(erf,a,z)}"); //integrating erf(z) at several z values.
        }
        outfile.WriteLine();
        outfile.WriteLine();
        outfile.WriteLine($"{-3} {-0.99998}");
        outfile.WriteLine($"{-2} {-0.99532}");
        outfile.WriteLine($"{-1} {-0.84270}");
        outfile.WriteLine($"{0} {0}");
        outfile.WriteLine($"{1} {0.84270}");
        outfile.WriteLine($"{2} {0.99532}");
        outfile.WriteLine($"{3} {0.99998}");
        }
        //double erfint = quad.integrate(erf,a,10.0);
        //WriteLine($"integral of erf(10) is {erfint}, which analytically is 0.9999...");
    }
}