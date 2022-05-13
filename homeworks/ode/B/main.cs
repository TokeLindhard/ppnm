using System;
using static System.Math;
using System.Collections.Generic;


class main{

    public static void Main(){
        //First testing if driver works on the simple function: cos, which has the property that u''=-u
        double step = 1.0/16;

        Func<double, vector, vector> osc = delegate(double t, vector y){
			return new vector(y[1], -y[0]);
		};

        double a = 0;
        double b = 2*PI;

        List<double> xs = new List<double>();
        List<vector> ys = new List<vector>();
        List<double> xxs = new List<double>();
        List<vector> yys = new List<vector>();

        double[] initcos = new double[] {0.0, 1.0};
		vector yacos = new vector(initcos);
		using(var outfile = new System.IO.StreamWriter("testsolv.txt")){
			int steps = ode.driver(osc, a, yacos, b, step, xs, ys);
            for(int i = 0; i < xs.Count; i++){
				outfile.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
			}	
		}

        //Now we can move on to the dampened oscillator

        double c = 0.25; //using c and d instead, because a and b are used. 
        double d = 5.0;
        double e = 0; //limits for pendulum
        double f = 10;

        Func<double, vector, vector> pend = delegate(double t, vector y){
            double theta = y[0];
            double omega = y[1];
            return new vector (omega, -c*omega - d*Sin(theta));
        };

        double[] initconds = new double[] {PI - 0.1, 0.0};
        vector yapend = new vector(initconds);
        using(var outfile = new System.IO.StreamWriter("damposc.txt")){
			int steps = ode.driver(pend, e, yapend, f, step, xxs, yys);
            for(int i = 0; i < xxs.Count; i++){
				outfile.WriteLine($"{xxs[i]} {yys[i][0]} {yys[i][1]}");
			}	
		}

	}
}