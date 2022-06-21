using System;
using static System.Console;
using static System.Math;

class main{
    public static int ncalls = 0; //tracking how many calls, i.e. iterations, the adapter is using.
    public static void Main(){
        WriteLine("           EXAM PROJECT 18 - ADAPTIVE INTEGRATION OF COMPLEX-VALUED FUNCTIONS");
        WriteLine("                   Toke Marstrand Pontoppidan Lindhard");
        WriteLine("                             Study number: 201906464");
        WriteLine("--------------------------------------------------------------------------------------------------");
        WriteLine();
        WriteLine("First we will test the integrator using simple functions.");
        WriteLine("While doing these, we keep track of the amount of iterations each integral takes.");
        WriteLine("All integrations are done with absolute and relative accuracy goal of 1e-6.");
        testfuncs();
        WriteLine("--------------------------------------------------------------------------------------------------");
        WriteLine("Now we can compare the amount of iterations used, when we use the Clenshaw-Curtis variable transformation");
        WriteLine("We both use the implementation for the limits [-1,1], but also the general [a,b].");
        CCtest();
        WriteLine("As can be seen, the CC transformation is much faster in some cases, but also slower in specific cases.");
        WriteLine("Lastly, we wish to test this on the Bessel function J_n(x) of first kind.");
        WriteLine("--------------------------------------------------------------------------------------------------");
        WriteLine("We calculate the Bessel function of first kind using the cosine integral representation from Wikipedia");
        WriteLine("The first five (n=0,1,2,3,4) functions are calculated.");
        Besselfunctions();
        WriteLine("The results can be seen in the figure Bessel.pyxplot.png");
    }

    public static void testfuncs(){
        //First we test the integrator on simple functions
        Func<complex,complex> f1 = x => {ncalls++; return 1/cmath.sqrt(x);}; //function to be integrated
        complex a1 = 0.0; //integration limits
        complex b1 = 1.0;
        complex intf1 = adaptint.adapter(f1,a1,b1);
        WriteLine($"Integral of 1/sqrt(x) from 0 to 1 is {intf1} and analytically is 2. This took {ncalls} iterations");
        ncalls = 0; //resetting amount of calls after each function is evaluated.

        Func<complex,complex> f2 = x => {ncalls++; return cmath.log(x)/cmath.sqrt(x);};
        complex a2 = 3+2*complex.I; //illustrating complex limits
        complex b2 = 10+5*complex.I;
        complex intf2 = adaptint.adapter(f2,a2,b2);
        WriteLine($"Integral of log(x)/sqrt(x) from 3+2i to 10+5i is {intf2} and analytically a big expression which rounded off yields 5.24+2.31i");
        WriteLine($"This took {ncalls} iterations.");
        ncalls = 0;

        Func<complex,complex> f3 = x => {ncalls++; return 4*cmath.sqrt(1-cmath.pow(x,2.0));};
        complex a3 = -1; //This function is useful later, so we can compare results when doing Clenshaw-Curtis later.
        complex b3 = 1;
        complex intf3 = adaptint.adapter(f3,a3,b3);
        WriteLine($"Integral of 4sqrt(1-x^2) from -1 to 1 is {intf3}. This took {ncalls} iterations.");
        ncalls = 0;
    }

    public static void CCtest(){
        //Now we test if we can reduce the amount of iterations by using the Clenshaw-Curtis variable transformation.
        Func<complex,complex> f1cc = x => {ncalls++; return 1/cmath.sqrt(x);};
        complex a1cc = 0.0; //illustrating complex limits
        complex b1cc = 1.0;
        complex intf1cc = adaptint.CCtransformation(f1cc,a1cc,b1cc);
        WriteLine($"Using the CC transformation, the integral of 1/sqrt(x) from 0 to 1 is {intf1cc}, which took {ncalls} iterations, a lot less than before.");
        ncalls = 0;

        Func<complex,complex> f2cc = x => {ncalls++; return cmath.log(x)/cmath.sqrt(x);};
        complex a2cc = 3+2*complex.I; //illustrating complex limits
        complex b2cc = 10+5*complex.I;
        complex intf2cc = adaptint.CCtransformation(f2cc,a2cc,b2cc);
        WriteLine($"Using the CC transformation, the integral of log(x)/sqrt(x) from 3+2i to 10+5i is {intf2cc}, which took {ncalls} iterations, which is more than before.");

        Func<complex,complex> f3cc = x => {ncalls++; return 4*cmath.sqrt(1-cmath.pow(x,2.0));};
        complex a3cc = -1; //illustrating complex limits
        complex b3cc = 1;
        complex intf3cc = adaptint.CCtransformation(f3cc,a3cc,b3cc);
        WriteLine($"Using the CC transformation, the integral of 4*sqrt(1-x^2) from -1 to 1 is {intf3cc}, which took {ncalls} iterations, which is slighty less than before.");
    }

    public static void Besselfunctions(){
        /*For the real test: the Bessel function. We test (and plot) up to n=4. Using the cosinus integral 
        definition from Wikipedia: https://en.wikipedia.org/wiki/Bessel_function */
        complex ll = 0; //lower limit
        complex ul = PI; //upper limit

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
            ncalls = 0;
        }
    }
}