using System;
public static class lsfit{
        public static vector lsfitting(Func<double,double>[] fs, vector x, vector y, vector dy){
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
            //var pinvA = qra.pinverse();
            //var S = pinvA*pinvA.T;
            return (c); //also return S if these last two lines are uncommented.
        }
    }