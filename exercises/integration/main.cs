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
        WriteLine($"#result1 is {result1}"); //making the # comment so the pyxplot will ignore it.
        //otherwise I would have to make two seperate files, which I am too lazy to do.

        //result for error function
        double result2 = erf(2);
        WriteLine($"#result2 is {result2}");

        //For plotting the error function
        for(double x=0;x<=2;x+=1.0/8){
            WriteLine($"{x} {erf(x)}");
        }
    }
}