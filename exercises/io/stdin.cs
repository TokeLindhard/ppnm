using System;
using System.IO;
using static System.Console;
class main{
        static public int Main(){
        System.Console.WriteLine("this goes to stdout");
        System.Console.Out.WriteLine("this goes to stderr");
        System.Console.Error.WriteLine("this goes to stderr");
	System.IO.TextWriter stdout = System.Console.Out;
	stdout.WriteLine("another stdout");
	
	
	string line = System.Console.ReadLine();
	WriteLine($"line = {line}"); /* Writes the line you write in terminal I think */
	string[] words = line.Split(); /*splits everything that is not letters and returns an array of words (the [] indicates it's an array */
	foreach(string word in words){
	       	WriteLine($"word={word}");
		double x = double.Parse(word);
		WriteLine($"x={x})");
	}
	/*
	string line = System.Console.In.ReadLine();
	var stdin = System.Console.In;
	string s = stdin.ReadLine();
	*/

return 0;
}
}


