using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        //calculating sqrt(-1)
        complex z = new complex(-1);
        complex sqrtz = cmath.sqrt(z);
        sqrtz.print("sqrt(-1) = ");

        //calculating sqrt(i)
        complex sqrti = cmath.sqrt(cmath.I);
        sqrti.print("sqrt(i) = "); 

        //calculating e^i
        complex ei = cmath.exp(cmath.I);
        ei.print("e^i = ");

        //calculating e^pi*i
        complex epii = cmath.exp(System.Math.PI*cmath.I);
        epii.print("e^(pi*i) = ");

        //calculating i^i
        complex ii = cmath.pow(cmath.I,cmath.I);
        ii.print("i^i = ");

        //calculating ln(i)
        complex lni = cmath.log(cmath.I);
        lni.print("ln(i) = ");

        //calculating sin(ipi)
        complex sinipi = cmath.sin(cmath.I*System.Math.PI);
        sinipi.print("sin(i*pi) = ");
    }
}