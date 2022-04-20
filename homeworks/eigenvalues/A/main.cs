using System;
using static System.Console;

class main{
    public static void Main(){ 
        int n = 4; int m=4;
        matrix A = new matrix(n,m); //created empty matrix
        Random rnd = new Random(); //Next few lines creates random numbers and fill them into A, x is random variable
        for (int i=0; i<n; i++){
            for(int j=0; j<i; j++){ //to make it symmetric we only fill in half the elements, and then aji=aij
                A[i,j] = rnd.Next(10);
                A[j,i] = A[i,j]; //making it symmetric
            }
        }
        WriteLine("The matrix A looks like:");
        A.print();
        matrix D; //creating empty matrices D and V to use for the jacobi cyclic
        matrix V;
        (D,V) = Jacobi.cyclic(A); //doing the cyclic on the matrix A
        WriteLine("After sweep our diagonalized matrix looks like:");
        D.print(); //eigenvalues will be on the diagonal.
        WriteLine();

        WriteLine("The matrix V containing the eigenvectors looks like");
        V.print(); //each coluououmnm is a eigenvector.

        WriteLine("Now performing tests");
        WriteLine();

        WriteLine("Checking if V^TAV==D");
        matrix VTAV = V.transpose()*A*V;
        WriteLine($"{(VTAV).approx(D)}");
        WriteLine();

        WriteLine("Checking if VDV^T==A");
        matrix VDVT = V*D*V.transpose();
        WriteLine($"{(VDVT).approx(A)}");
        WriteLine();

        WriteLine("Checking if V^TV==I");
        matrix VTV = V.transpose()*V;
        int a = V.size1; //taking size of V, so I can make id-matrix of same size
        WriteLine($"{(VTV).approx(matrix.id(a))}");
        WriteLine();

        WriteLine("Checking if VV^T==I");
        matrix VVT = V*V.transpose();
        WriteLine($"{(VVT).approx(matrix.id(a))}"); //just using the a from before.
        WriteLine();

    }
}