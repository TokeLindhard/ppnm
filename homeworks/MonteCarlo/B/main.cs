using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        int N = 100000; //Number of points in mc
        WriteLine("We test the implementation of Monte-Carlo by a few simple two-dimensional integrals");
        WriteLine("We calculate both using plain MC, but also using quasi-random sampling and mark the differences.");
        WriteLine($"All runs are done with N={N}");
        WriteLine();
        Func<vector,double> f1 = v => {return v[0]*v[1];}; //x*y. v is the vector v=(x,y)^T
        vector a1 = new double[] {5,7}; //lower limits for integrals (first is x-integral lower limit, 2nd is for y)
        vector b1 = new double[] {10,12}; //upper limits for integrals (first is x-integral upper limit, 2nd is for y)
        var intf1 = mc.plainmc(f1,a1,b1,N); //first item it returns is the value of the integral, 2nd item is the error
        var intf1quasi = mc.quasimc(f1,a1,b1,N);
        WriteLine("First, the integral of x*y with lower limits [5,7] and upper limits [10,12]");
        WriteLine($"The integral yields {intf1.Item1} with error {intf1.Item2}");
        WriteLine($"With quasi-random sampling the integral is {intf1quasi.Item1} with error {intf1quasi.Item2}");
        WriteLine($"The analytical result is 7125/4=1781.25");
        WriteLine();

        Func<vector, double> f2 = v => {return v[0]*v[0]+v[1]*v[1];};
        vector a2 = new double[] {5,3};
        vector b2 = new double[] {10,7};
        var intf2 = mc.plainmc(f2,a2,b2,N);
        var intf2quasi = mc.quasimc(f2,a2,b2,N);
        WriteLine("Next, we test the integral of x^2+y^2 with lower limits [5,3] and upper limits [10,7]");
        WriteLine($"The integral yields {intf2.Item1} with error {intf2.Item2}");
        WriteLine($"With quasi-random sampling the integral is {intf2quasi.Item1} with error {intf2quasi.Item2}");
        WriteLine("The analytical result is 5080/3=1693.33....");
        WriteLine();

        Func<vector, double> f3 = v => {return Log(v[0])/Sqrt(v[1]);};
        vector a3 = new double[] {0,0};
        vector b3 = new double[] {1,1};
        var intf3 = mc.plainmc(f3,a3,b3,N);
        var intf3quasi = mc.quasimc(f3,a3,b3,N);
        WriteLine("Lastly, we test the integral of x^2+y^2 with lower limits [5,3] and upper limits [10,7]");
        WriteLine($"The integral yields {intf3.Item1} with error {intf3.Item2}");
        WriteLine($"With quasi-random sampling the integral is {intf3quasi.Item1} with error {intf3quasi.Item2}");
        WriteLine("The analytical result is -2"); 
        WriteLine();

        WriteLine("Now we are ready to test the 3D-integral of 1/pi^3*int dx*int dy*int dz [1-cos(x)cos(y)cos(z)]^-1");
        WriteLine("With limits xlim=ylim=zlim=[0,pi]");
        Func<vector, double> f4 = v => {return 1/(Pow(PI,3))*1/(1-Cos(v[0])*Cos(v[1])*Cos(v[2]));};
        vector a4 = new double[] {0,0,0};
        vector b4 = new double[] {PI,PI,PI};
        var intf4 = mc.plainmc(f4,a4,b4,N);
        var intf4quasi = mc.quasimc(f4,a4,b4,N);
        WriteLine($"The integral yields {intf4.Item1} with error {intf4.Item2}");
        WriteLine($"With quasi-random sampling the integral is {intf4quasi.Item1} with error {intf4quasi.Item2}");
        WriteLine("The analytical result is Gamma(1/4)^4/(4pi)^3=1.3932..."); 
        WriteLine();
        WriteLine("We see that generally, using the quasi-random sampling, the error is reduced.");
        WriteLine("However, it seems that sometimes the integrals will diverge instead, giving an NaN-error.");
    }
}