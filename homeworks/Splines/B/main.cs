using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class main{
    public static void Main(){
        //test 1 with y_i=1
        double[] xs1 = new double[] {1.0,2.0,3.0,4.0,5.0}; 
        double[] ys1 = new double[xs1.Length];
        for(int i =0; i<xs1.Length; i++){
            ys1[i] = 1;
        }
        double[] c1 = new double[]{0,0,0,0};
	    double[] b1 = new double[]{0,0,0,0};

        //test 2 with y_i=x_i
        double[] xs2 = new double[] {1.0,2.0,3.0,4.0,5.0}; 
        double[] ys2 = new double[xs2.Length];
        for(int i =0; i<xs2.Length; i++){
            ys2[i] = xs2[i];
        }
        double[] c2 = new double[]{0,0,0,0};
	    double[] b2 = new double[]{1,1,1,1};

        //test 3 with y_i=x_i^2
        double[] xs3 = new double[] {1.0,2.0,3.0,4.0,5.0}; 
        double[] ys3 = new double[xs3.Length];
        for(int i =0; i<xs3.Length; i++){
            ys3[i] = Pow(xs3[i],2);
        }
        double[] c3 = new double[]{1,1,1,1};
	    double[] b3 = new double[]{2,4,6,8};

        qspline q1 = new qspline(xs1,ys1);
        qspline q2 = new qspline(xs2,ys2);
        qspline q3 = new qspline(xs3,ys3);
        WriteLine("Test1");
        WriteLine("Calculated c's vs. spline c's");
        for(int i = 0; i<c1.Length;i++){
            WriteLine($"{c1[i]} {q1.c[i]}");
        }
        WriteLine("Calculated b's vs. spline b's");
        for(int i = 0; i<b1.Length;i++){
            WriteLine($"{b1[i]} {q1.b[i]}");
        }

        WriteLine();
        WriteLine();

        WriteLine("Test2");
        WriteLine("Calculated c's vs. spline c's");
        for(int i = 0; i<c2.Length;i++){
            WriteLine($"{c2[i]} {q2.c[i]}");
        }
        WriteLine("Calculated b's vs. spline b's");
        for(int i = 0; i<b2.Length;i++){
            WriteLine($"{b2[i]} {q2.b[i]}");
        }

        WriteLine();
        WriteLine();

        WriteLine("Test3");
        WriteLine("Calculated c's vs. spline c's");
        for(int i = 0; i<c3.Length;i++){
            WriteLine($"{c3[i]} {q3.c[i]}");
        }
        WriteLine("Calculated b's vs. spline b's");
        for(int i = 0; i<b3.Length;i++){
            WriteLine($"{b3[i]} {q3.b[i]}");
        }

        //Testing integration and derivative using test 3
        using(var outfile = new System.IO.StreamWriter("qspline.txt")){
            for(int i =0; i<xs3.Length; i++){
                outfile.WriteLine($"{xs3[i]} {ys3[i]}");
            }

            outfile.WriteLine();
            outfile.WriteLine();

            for(double z=0; z<10;z+=1.0/64){
                outfile.WriteLine($"{z} {q3.spline(z)} {q3.derivative(z)} {q3.integral(z)}");
            }
        }
    }
}