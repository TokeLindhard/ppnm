using System;

class main{
	static void Main(){
		double sqrt2=Math.Sqrt(2.0);
		double epi=Math.Exp(Math.PI);
		double pie=Math.Pow(Math.PI,Math.E);

		Console.WriteLine($"sqrt(2) = {sqrt2}");
		Console.WriteLine($"sqrt(2)*sqrt(2) = {sqrt2*sqrt2}");
		Console.WriteLine($"epi = {epi}");
		Console.WriteLine($"log(epi) = {Math.Log(epi)}");
		Console.WriteLine($"pie = {pie}");
		Console.WriteLine($"How to do log_pi(pie)??");
	}
}
