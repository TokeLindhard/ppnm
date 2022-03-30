using System;
using static System.Math;
using static System.Console;

class main{
    public static void Main(){
       qrdecomp(); 
       solution();
    }
    public static void qrdecomp(){
    int n = 4; int m=3;
        matrix A = new matrix(n,m); //created empty matrix
        Random rnd = new Random(); //Next few lines creates random numbers and fill them into A, x is random variable
        for (int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                A[i,j] = rnd.Next(10);
            }
        }
        WriteLine($"The matrix A looks like:");
        A.print();
        var qra = new qrgs(A);
        WriteLine("Q is");
        qra.Q.print();
        WriteLine("R is");
        qra.R.print();

        WriteLine("Testing if R is upper triangular");
        for(int i=0; i<qra.R.size1; i++){
            for(int j=0; j<i; j++){ //checking if R is upper triangular
            WriteLine($"{matrix.approx(qra.R[j][i],0)}"); 
                // if(qra.R[j][i]!=0) WriteLine($"R is NOT upper triangular {qra.R[j][i]}"); //yes this is weird, but it works!
                // else WriteLine("R is upper triangular");
            }
        }

        var QT = qra.Q.transpose(); //transposing Q
        WriteLine($"transposing Q yields");
        QT.print();

        var QTQ = QT*qra.Q; //calculating Q^T*Q and checking if it's equal to 1
        WriteLine("Q^T*Q =");
        QTQ.print();
        WriteLine("Testing if QTQ=1");
        for(int i=0; i<QTQ.size1; i++){ //QTQ is square, so which size we choose doesn't matter.
            WriteLine($"{matrix.approx(QTQ[i][i],1)}");
        }

        var QRmul = qra.Q*qra.R; //calculating Q*R and seeing if it's equal to A
        WriteLine("Q*R =");
        QRmul.print();
        WriteLine("Testing if QR=A");
        for(int i=0; i<QRmul.size2; i++){
            for(int j=0; j<QRmul.size1; j++){ //checking if each element is the same in QR as in A
                WriteLine($"{matrix.approx(QRmul[i][j],A[i][j])}");
                // if(QRmul[i][j] != A[i][j]) WriteLine($"QR is not equal to A");
                // else WriteLine($"QR[{i}][{j}] = A[{i}][{j}]");
            }
        }
    }
    public static void solution(){
    //Now testing and finding solutions with a square matrix instead.

        int nn = 4;
        matrix B = new matrix(nn,nn); //created empty square matrix
        Random rand = new Random(); //Next few lines creates random numbers and fill them into A, x is random variable
        for (int i=0; i<nn; i++){                
            for(int j=0; j<nn; j++){
                B[i,j] = rand.Next(10);
            }
        }
        WriteLine($"The matrix B looks like:");
        B.print();
        var qra = new qrgs(B);

        var b=new vector(nn); //creating vector as solutions to the equation Bx=b
        for(int i=0;i<b.size;i++){
            b[i]=rand.NextDouble();
        }            
        b.print("random vector b:\n");
        var x=qra.solve(b);
        WriteLine("the solution x is:");
        x.print();
        //var C = qra.Q*qra.R; //The matrix B written with Q*R - still doesn't work! :((((
        vector Bx = B*x; //replace B with C if you want qra.Q*qra.R
        WriteLine("and B*x is");
        Bx.print();
        WriteLine("Checking if this is approx equal to b");
        //for(int i=0; i<Bx.size; i++){
        WriteLine($"{(Bx).approx(b)}");
        //}

        //     var Bx=B*x;
        //     Bx.print("check: B*x (should be equal b):\n");
        //     if(vector.approx(Bx,b)) WriteLine("test passed");
        //     else WriteLine("test failed");
    }
}