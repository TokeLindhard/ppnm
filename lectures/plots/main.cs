using System;
using static System.Console;
using static System.Math;

class main{

    static double erf(double x){
        /// single precision error function (Abramowitz and Stegun, from Wikipedia)
        if(x<0) return -erf(-x);
        double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
        double t=1/(1+0.3275911*x);
        double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
        return 1-sum*Exp(-x*x);
    } 

    static double gamma(double y){
        ///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(y<0)return PI/Sin(PI*y)/gamma(1-y);
        if(y<9)return gamma(y+1)/y;
        double lngamma=y*Log(y+1/(12*y-1/y/10))-y+Log(2*PI/y)/2;
        return Exp(lngamma);
    }   
    public static void Main(){
        for(double x=-2;x<=2;x+=1.0/8){
            WriteLine($"{x} {erf(x)}");
        }
        for(double y=-2;y<=2;y+=1.0/8){
            WriteLine($"{y} {gamma(y)}");
        }
    }
}