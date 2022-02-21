using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Func<double,double,double> f = delegate(double x, double k){
            return Sin(k*x);
        };
        for (int i=1; i<=3; i++){
            table.make_table(x => f(x,i),1,5,1);
            WriteLine("\n");
        }
    }
}