using System;
using System.IO;
using static System.Console;
class main{
        static public int Main(){
        var reader = new System.IO.StreamReader("input.txt");
	var writer = new System.IO.StreamWriter("outfile.txt");
	
	
	string line = reader.ReadLine();
	writer.WriteLine($"line={line}"); /* Writes the line you write in terminal I think */
	string[] words = line.Split(); /*splits everything that is not letters and returns an array of words (the [] indicates it's an array */
	foreach(string word in words){
	       	writer.WriteLine($"word={word}");
		double x = double.Parse(word);
		writer.WriteLine($"x={x})");
	}
	/*
	string line = System.Console.In.ReadLine();
	var stdin = System.Console.In;
	string s = stdin.ReadLine();
	*/
	reader.Close();
	writer.Close();
	return 0;
        }
}


