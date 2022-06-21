using System;
using static System.Math;
using static System.Double; //when we check if a double is NaN, we need to have the package

public static class adaptint{
    public static complex integrate
    (Func<complex,complex> f,
    complex a,
    complex b,
    complex f2,
    complex f3,
    double delta=1e-6, 
    double epsilon=1e-6){
        complex h=b-a;
        complex f1=f(a+h/6.0);
        complex f4=f(a+5.0*h/6.0);
        complex Q = (2.0*f1+f2+f3+2.0*f4)/6.0*(b-a); // higher order rule
        complex q = (f1+f2+f3+f4)/4.0*(b-a); // lower order rule
        double err = Abs(Q.Re-q.Re)+Abs(Q.Im-q.Im); //error
        double tol = delta+epsilon*cmath.abs(Q); //tolerance
        if (err <= tol){ //accepts step if error is small enough. See eq. 47
        return Q;
        } 
        else{
            return integrate(f,a,(a+b)/2.0,f1,f2,delta/Sqrt(2.0),epsilon) + 
            integrate(f,(a+b)/2.0,b,f3,f4,delta/Sqrt(2.0),epsilon);
        }
    }

    public static complex adapter
    (Func<complex,complex> f,
    complex a,
    complex b,
    double delta = 1e-6,
    double epsilon = 1e-6
    ){
        complex h = b-a;
        complex f2 = f(a+2*h/6.0);
        complex f3 = f(a+4*h/6.0);
        return integrate(f,a,b,f2,f3,delta,epsilon);
    }

    public static complex CCtransformation
    (Func<complex,complex> f,
    complex a,
    complex b,
    double delta=1e-6, 
    double epsilon=1e-6){
    Func<complex,complex> fcc; //transforming the function
        if(a.Re==-1 && a.Im==0 && b.Re==1 && b.Im==0){
            fcc = x => f(cmath.cos(x))*cmath.sin(x); //If integral limits are -1 and 1 of their real parts, this formula is used
        }
        else{
            fcc = x => f((a+b)/2.0 + (b-a)/2.0*cmath.cos(x))*cmath.sin(x)*(b-a)/2.0; //otherwise use this one
        }
    return adapter(fcc,0.0,PI); //after this, integrate, but use the limits 0 and Pi instead.  
    }
}