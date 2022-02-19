using System;
using static System.Console;

class main{

public static Func<double> make_fa(){
	double a=0;
	Func<double> fa = delegate(){a++;return a;};
	return fa;
}
	
public delegate double fun_of_3_doubles(double x, double y, double z);
	
public static void Main(){
	System.Func<double> fun = delegate(){return 7;};
	Func<double,double> square = delegate(double x){return x*x;};
	Action hello = delegate(){ WriteLine("hello");};
	fun_of_3_doubles f3 = delegate(double x, double y, double z){return 9;};
	Func<double,double,double,double> f4
	=delegate(double x, double y, double z){return 4;}; /*last input in Func is type */
	hello();
	WriteLine($"fun()={fun()} should be equal 7");
	WriteLine($"square(2)={square(2)} should be equal to 4");
	WriteLine($"f3(1,2,3)={f3(1,2,3)} should be equal to 9");
	WriteLine($"f4(1,2,3)={f4(1,2,3)} should be equal to 4");

	double a=0;
	Action fa = delegate(){a++;};
	fa();
	WriteLine($"a={a} should be equal to 1");
	fa();
	WriteLine($"a={a} should be equal to 2");
	fa();
	WriteLine($"a={a} should be equal to 3");

	Func<double> fb = make_fa();
	WriteLine($"fb()={fb()} should be 1");
	WriteLine($"fb()={fb()} should be 2");
	WriteLine($"fb()={fb()} should be 3");

	Func<double> fc = make_fa();
	WriteLine($"fc()={fc()} should be 1 or 3");	

}


}
