using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	
	static complex gamma(complex x){
		///single precision gamma function (Gergo Nemes, from Wikipedia)
        if(cmath.abs(x)<0)return PI/cmath.sin(PI*x)/gamma(1-x);
		if(cmath.abs(x)<9)return gamma(x+1)/x;
		complex lngamma=x*cmath.log(x+1/(12*x-1/x/10))-x+cmath.log(2*PI/x)/2;
		return cmath.exp(lngamma);
	}
	public static void Main(){
	
		for(double x = -5; x <= 5; x += 1.0/2){
			for(double y = -5; y<=5; y += 1.0/2){
                if(Double.IsNaN(cmath.abs(gamma(new complex(x,y)))))
				WriteLine($"");
                else
                WriteLine($"{x} {y} {cmath.abs(gamma(new complex(x,y)))}");
            }
		}
	}
}
