using System;
using static System.Math;
using System.Collections.Generic;

public class ode{
    public static (vector,vector) rkstep12(
        Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
        double x,   /* the current value of the variable */
        vector y,   /* the current value y(x) of the sought function */
        double h    /* the step to be taken */
    ){ // Runge-Kutta Euler/Midpoint method (probably not the most effective)
        vector k0 = f(x,y); /* embedded lower order formula (Euler) */
        vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
        vector yh = y+k1*h;     /* y(x+h) estimate */
        vector er = (k1-k0)*h;  /* error estimate */
        return (yh,er);
    }

    public static int driver(
        Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
        double a,                     /* the start-point a */
        vector ya,                    /* y(a) */
        double b,                     /* the end-point of the integration */
        double h,                  /* initial step-size */
        List<double> xs,
        List<vector> ys,
        double acc=0.01,              /* absolute accuracy goal */
        double eps=0.01               /* relative accuracy goal */
    ){
    if(a>b) throw new Exception("driver: a>b");
    double x=a; vector y=ya;
    int steps = 0; int max_steps = 690;
//    List<double> xs = new List<double>();
//    List<vector> ys = new List<vector>();
    xs.Add(x);
    ys.Add(y);
    while(steps < max_steps){
        bool ok =true;
        steps++;
        if(x>=b){break;}    /* job done */
        if(x+h>b){h=b-x;}   /* last step should end at b */
        var (yh,erv) = rkstep12(f,x,y,h);
        vector tol = new vector(erv.size);
        for(int i = 0; i<tol.size; i++){
            tol[i] = Max(acc, Abs(yh[i]*eps)*Sqrt(h/(b-a)));
            ok = ok && erv[i]<tol[i];
        }

        if(ok){ //if we accept the step
            x+=h;
            y=yh;
            xs.Add(x);
            ys.Add(y);
        }
        double factor = tol[0]/Abs(erv[0]);
        for(int i = 1; i<tol.size; i++){
            factor = Min(factor, tol[i]/Abs(erv[i]));
        }
        h *= Min( Pow(factor,0.25)*0.95 , 2); // readjust stepsize
        //if(err<=tol){ 
         //   x+=h; y=yh;
         //   xs.Add(x);
         //   ys.Add(y);
        //} // accept step
    }
    return steps;
    }//driver
}