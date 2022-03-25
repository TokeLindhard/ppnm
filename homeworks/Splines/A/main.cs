using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class main{
    public static void Main(){
        double[] a = new double[] {1,2,3,4,5,6,7}; //2nd degree polynomial
        double[] b = new double[] {1,4,9,16,25,36,49};
        interpolation.interpol linterp(10,a,b,5);
        //interpolationinterpol.linterp(10,x,y,5);
        //WriteLine(string.Join("\n", x));
        //WriteLine(string.Join("\n",y));
        //linterp(10,x,y,)
    }
}