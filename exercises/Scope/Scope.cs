using System;
using static System.Console;

public static class math{
	public static int n=7;
	public static double pi=3.1415927;
	public static double e=2.71828;
}

public static class main{
	static string s="main\n";
	static void hello(){
		string s="hello\n";
		Write(s);
		{	string s="block\n";
			Write(s);
		}
		}
	static int Main{
		double x;
		x=math.pi;
		y=math.e;
		Write("x={0} y={1}\n",x,y);
		Write($"x={x} y={y}\n"); #gives same result as previous line
	return 0;
	} 
}
