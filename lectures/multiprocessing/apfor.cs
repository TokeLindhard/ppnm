using System;
using System.Threading;
using static System.Console;
using System.Threading.Tasks;

class main{

public static void Main(string[] args){
	int N = (int)1e6;
	double[] a = new double[N];
	if(args.Length>0) N = (int)double.Parse(args[0]);
	WriteLine($"N={(float)N}");
	Parallel.For(1,N, i => a[i]=Math.Sin(i)*Math.Cos(i) );
	WriteLine("job done");

}

}