using System;
using static System.Console;

public class main{
    public static void Main(){
        var list = new genlist<double[]>();
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(string line = ReadLine(); line!=null; line = ReadLine()){
            var words = line.Split(delimiters,options);
            int n = words.Length;
            var numbers = new double[n];
            for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
            list.push(numbers);
        }
        for(int i=0;i<list.size;i++){
            var numbers = list.data[i];
            foreach(var number in numbers)Write($"{number:e} ");
                WriteLine();
        }
        WriteLine();
        WriteLine($"Size of the list is {list.size}");
        WriteLine();
        WriteLine("Now we remove one element");
        list.remove(1);
        WriteLine();
        WriteLine($"The size is now {list.size}");
        WriteLine();
        
        for(int i=0;i<list.size;i++){
            var numbers = list.data[i];
            foreach(var number in numbers)Write($"{number:e} ");
            WriteLine();
        }
    }
}