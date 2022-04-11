using System;
using static System.Console;
using static System.Math;
public static class lsfit{
        public static (vector,matrix,vector) lsfitting(Func<double,double>[] fs, vector x, vector y, vector dy){
            int n = x.size; int m = fs.Length;
            var A = new matrix(n,m);
            var b = new vector(n);
            for(int i =0; i<n; i++){ //filling up both b and A with numbers from the data in main
                b[i] = y[i]/dy[i];
                for (int j=0; j<m;j++){
                    A[i,j] = fs[j](x[i])/dy[i]; 
                }
            }
            var qra = new qrgs(A);
            vector c = qra.solve(b); //This vector contains all our coefficients to the least squares fit.
            var ATA = A.transpose()*A;
            qrgs invATA = new qrgs(ATA);
            var S = invATA.inverse(); //calculating covariance matrix (formula 10 in least_squares notes)
            WriteLine("hej");
            
            vector err = new vector(m);
            for(int i=0; i<m; i++){
                err[i] = Sqrt(S[i][i]); //variances are the diagonal elements of the covariance matrix, so taking
                //the sqrt gives us the errors. 
            }
            return (c,S,err); 
        }
    }