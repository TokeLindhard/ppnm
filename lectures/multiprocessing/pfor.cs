using System;
using System.Threading;
using System.Threading.Tasks; //makes parallel for-loops
using static System.Console;
class main{
    public static void Main(string[] args){
        int N = (int)1e6;
        double[] a = new double[N];
        if(args.Length>0) N = (int)double.Parse(args[0]);
        WriteLine($"N={(float)N}");
        double sum=0;
        Parallel.For(1,N+1,async i => a[i]=Math.Sin(i)*Math.Cos(i));
        WriteLine($"job done"); 
        
        //This gives the wrong result because all threads write to the same sum
        //this also takes longer time because they queue to write into the sum.
        //Whichever thread writes last will be the one to write into sum. (this was written, when this process still
        //calculated a sum)
    }
}