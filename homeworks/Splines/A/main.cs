using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class main{
    public static void Main(){
        double[] xs = new double[] {1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0,6.5,7.0,7.5,8.0,8.5,9.0,9.5,10.0}; //2nd degree polynomial
        double[] ys = new double[xs.Length];
        for(int i =0; i<ys.Length; i++){ //Making 2nd degree polynomial from the x-values
            //ys[i] = Sin(xs[i]);
            ys[i] = Pow(xs[i],2);
        }
        //interpolation.interpol linterp(xs,ys,15);

        using(var outfile = new System.IO.StreamWriter("2ndpoly.txt")){
            for(int i = 0; i<ys.Length;i++){
                outfile.WriteLine($"{xs[i]} {ys[i]}");
            }
        }

        using(var outfile = new System.IO.StreamWriter("integration.txt")){
            for(double z=0; z<10;z+=1.0/64){
                outfile.WriteLine($"{z} {interpol.linterp(xs,ys,z)} {interpol.linterpInteg(xs,ys,z)}");
            }
        }


        //interpolationinterpol.linterp(10,x,y,5);
        //WriteLine(string.Join("\n", x));
        //WriteLine(string.Join("\n",y));
        //linterp(10,x,y,)
    }
}