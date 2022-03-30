using System;
using static System.Math;
using static System.Console;

class main{
    public static void Main(){
        inv();
    }

    public static void inv(){
        int n = 4;
        matrix A = new matrix(n,n); //created empty square matrix
        Random rand = new Random(); //Next few lines creates random numbers and fill them into A, x is random variable
        for (int i=0; i<n; i++){                
            for(int j=0; j<n; j++){
                A[i,j] = rand.Next(10);
            }
        }
        WriteLine($"The matrix A looks like:");
        A.print();
        var qra = new qrgs(A);
        matrix invA = qra.inverse();
        WriteLine("The inverse of A is");
        invA.print();
        WriteLine("Testing if A*A^(-1)=I (approks)");
        matrix AinvA = A*invA;
        AinvA.print();
        WriteLine($"{(A*invA).approx(matrix.id(n))}");
    }

}