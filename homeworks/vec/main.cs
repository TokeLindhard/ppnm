using System;
using static System.Console;
using static System.Math;

class main{
    static void Main(){
        vec u = new vec(1,2,3);
        u.print("u = "); //uses print function from vec.cs
        
        vec v  = new vec();
        v.print("v = ");

        vec a = new vec(4,5,6);

        (5*u).print("5u = ");
        (u*5).print("u5 = ");
        (u+a).print("u+a = ");
        (u-a).print("u-a = ");
        double d = dot(u,a);
        WriteLine($"dot product of u and a = {d}");
        (Cross(u,v)).print("cross product of u*v = ");
        double n = norm(u);
        WriteLine($"norm of vector u = {n}");
        WriteLine($"Overriding Tostring on u: u.ToString()");
    }
}