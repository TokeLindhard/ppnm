using System;
using static System.Math;
using static System.Double; //when we check if a double is NaN, we need to have the package

public static class quad{
    public static double integrate
    (Func<double,double> f,
    double a,
    double b,
    double delta=0.001, 
    double epsilon=0.001, 
    double f2=NaN, 
    double f3=NaN){
        double h=b-a;
        if(IsNaN(f2)){
            f2=f(a+2*h/6); 
            f3=f(a+4*h/6); 
        } // first call, no points to reuse
        double f1=f(a+h/6.0);
        double f4=f(a+5.0*h/6.0);
        double Q = (2.0*f1+f2+f3+2.0*f4)/6.0*(b-a); // higher order rule
        double q = (f1+f2+f3+f4)/4.0*(b-a); // lower order rule
        double err = Abs(Q-q);
        if (err <= delta+epsilon*Abs(Q)){ //accepts step if error is small enough. See eq. 47
            return Q;
        } 
        else{
            return integrate(f,a,(a+b)/2.0,delta/Sqrt(2.0),epsilon,f1,f2) + 
            integrate(f,(a+b)/2,b,delta/Sqrt(2.0),epsilon,f3,f4);
        }
    }
    public static double CCtransformation
    (Func<double,double> f,
    double a,
    double b,
    double delta=0.001, 
    double epsilon=0.001, 
    double f2=NaN, 
    double f3=NaN){
    
    Func<double,double> fcc; //transforming the function
        if(a==-1 && b==1){
            fcc = x => f(Cos(x))*Sin(x); //If integral limits are -1 and 1, this formula is used
        }
        else{
            fcc = x => f((a+b)/2.0 + (b-a)/2.0*Cos(x))*Sin(x)*(b-a)/2.0; //otherwise use this one
        }
    return integrate(fcc,0.0,PI); //after this, integrate, but use the limits 0 and Pi instead.
    }
}