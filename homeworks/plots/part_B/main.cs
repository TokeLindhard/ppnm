using System;
using static System.Console;
using static System.Math;

class main{

    static double gamma(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(x<0)return PI/Sin(PI*x)/gamma(1-x);
        if(x<9)return gamma(x+1)/x;
        double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return Exp(lngamma);
    }
    static double lngamma(double x){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(x<0)return Double.NaN; //You can't take the log of a negative value!
        if(x<9)return lngamma(x+1) - Log(x);
        double log=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return log;
    }
    public static void Main(){
        for(double x=0.1;x<=8;x+=1.0/8){
            WriteLine($"{x} {gamma(x)} {lngamma(x)}");
        }
    }
}