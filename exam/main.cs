using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        //First we test the integrator on simple functions
        int ncalls = 0; //tracking how many calls, i.e. iterations the adapter is using.
        Func<complex,complex> f1 = x => {ncalls++; return 1/cmath.sqrt(x);}; //function to be integrated
        complex a = 0.0; //integration limits
        complex b = 1.0;
        complex intf1 = adaptint.adapter(f1,a,b);
        WriteLine($"Integral of 1/sqrt(x) from 0 to 1 is {intf1} and analytically is 2. This took {ncalls} iterations");
        ncalls = 0; //resetting amount of calls after each function is evaluated.

        Func<complex,complex> f3 = x => {ncalls++; return cmath.log(x)/cmath.sqrt(x);};
        complex c = 3+2*complex.I; //illustrating complex limits
        complex d = 10+5*complex.I;
        complex intf3 = adaptint.adapter(f3,c,d);
        WriteLine($"integral of log(x)/sqrt(x) from 3+2i to 10+5i is {intf3} and analytically a big expression which rounded off yields 5.24+2.31i");
        WriteLine($"This took {ncalls} iterations.");

        /*For the real test: the Bessel function. We test (and plot) up to n=4. Using the cosinus integral 
        definition from Wikipedia: https://en.wikipedia.org/wiki/Bessel_function */
        complex ll = 0; //lower limit
        complex ul = PI; //upper limit
        ncalls = 0;

        using(var outfile = new System.IO.StreamWriter("J0cos.txt")){ //making seperate output files to unclutter
            for(double x=0;x<50;x+=1.0/16.0){
                Func<complex,complex> J0cos = z => {ncalls++; return 1.0/(PI)*cmath.cos(-x*cmath.sin(z));};
                complex J0cosint = adaptint.adapter(J0cos,ll,ul);
                outfile.WriteLine($"{x} {J0cosint.Re}"); /*taking real part since complex numbers are made to
                return a+bi, even if it's a+0i, which pyxplot could not read. */
            }
            WriteLine($"Finding J0 took {ncalls} iterations."); //This will go in outfile, so it wont disturb the plot.
            ncalls = 0;
        }
        //Repeating this for n=1,2,3,4.
        using(var outfile = new System.IO.StreamWriter("J1cos.txt")){
            for(double x=0;x<50;x+=1.0/16.0){
                Func<complex,complex> J1cos = z => {ncalls++; return 1.0/(PI)*cmath.cos(1*z-x*cmath.sin(z));};
                complex J1cosint = adaptint.adapter(J1cos,ll,ul);
                outfile.WriteLine($"{x} {J1cosint.Re}");
            }
            WriteLine($"Finding J1 took {ncalls} iterations.");
            ncalls = 0;
        }

        using(var outfile = new System.IO.StreamWriter("J2cos.txt")){
            for(double x=0;x<50;x+=1.0/16.0){
                Func<complex,complex> J2cos = z => {ncalls++; return 1.0/(PI)*cmath.cos(2*z-x*cmath.sin(z));};
                complex J2cosint = adaptint.adapter(J2cos,ll,ul);
                outfile.WriteLine($"{x} {J2cosint.Re}");
            }
            WriteLine($"Finding J2 took {ncalls} iterations.");
            ncalls = 0;
        }

        using(var outfile = new System.IO.StreamWriter("J3cos.txt")){
            for(double x=0;x<50;x+=1.0/16.0){
                Func<complex,complex> J3cos = z => {ncalls++; return 1.0/(PI)*cmath.cos(3*z-x*cmath.sin(z));};
                complex J3cosint = adaptint.adapter(J3cos,ll,ul);
                outfile.WriteLine($"{x} {J3cosint.Re}");
            }
            WriteLine($"Finding J3 took {ncalls} iterations.");
            ncalls = 0;
        }

        using(var outfile = new System.IO.StreamWriter("J4cos.txt")){
            for(double x=0;x<50;x+=1.0/16.0){
                Func<complex,complex> J4cos = z => {ncalls++; return 1.0/(PI)*cmath.cos(4*z-x*cmath.sin(z));};
                complex J4cosint = adaptint.adapter(J4cos,ll,ul);
                outfile.WriteLine($"{x} {J4cosint.Re}");
            }
            WriteLine($"Finding J4 took {ncalls} iterations.");
        }
    }
}