using System;
using static System.Math;
using static System.Console;

class main{
    public static void Main(){
        double[] x = {1,2,3,4,6,9,10,13,15}; //x data (time)
        double[] y = {117,100,88,72,53,29.5,25.2,15.2,11.1}; //y data (activity)
        double[] dy = {5,5,5,5,5,5,1,1,1}; //error on measurement
        var fs = new Func<double,double>[] { z => 1.0, z => z };

        double[] logy = new double[y.Length]; //to create a linear curve we make the points on the y-axis logaritmic
        double[] dlogy = new double[dy.Length]; //same for the uncertainties

        for(int i=0;i<y.Length;i++){
            logy[i] = Log(y[i]); //Taking the log to make it linear
            dlogy[i] = dy[i]/y[i]; //errors should change accordingly when taking the log.
        }

        var coeff = lsfit.lsfitting(fs,x,logy,dlogy); //creates vector with coefficients for the solution.
        //will give two coefficients, so we can make the solution as: y(t)=a*e^(-\lambda*t)
        //WriteLine($"coefficients are");
        //coeff.print();
        //for(int i = 0;i<logy.Length;i++){ //for testing purposes.
          //  WriteLine($"{logy[i]}");
            //WriteLine($"{dlogy[i]}");
        //}
        //WriteLine("So we get the following points");
        for(double i =1; i<16; i+=1.0/4){
            WriteLine($"{i} {Exp(coeff[0])*Exp(coeff[1]*i)}"); //Gives the activity at each timestep
            //Original equation is y(t)=a*e^(-\lambda*t), but our lambda is already negative, so don't need the minus sign.
            //Moreover we take exp of the coefficient a. Otherwise it's shit. Idk why this is needed, but it works.
            //only printing out these, so they can be used by plot.
        }
        WriteLine(); //if you make two blank lines like this, pyxplot will ignore what comes next if you write the correct index
        WriteLine(); //So write index 0 for the first block, index 1 for the 2nd block and so on.
        
        WriteLine($"The half life is {-1/coeff[1]} days");
        WriteLine("Compared with a modern value of 3.6 days.");
    }
}