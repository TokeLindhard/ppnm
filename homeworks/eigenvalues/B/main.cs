using System;
using static System.Console;

class main{
    public static void Main(){ 
        matrix H = makeH();
        (matrix D, matrix V) = Jacobi.cyclic(H);

    }

    public static matrix makeH(){
        double rmax=10,dr=0.3;
        int npoints = (int)(rmax/dr)-1;
        vector r = new vector(npoints);

        for(int i=0;i<npoints;i++){
            r[i]=dr*(i+1);
        }

        matrix H = new matrix(npoints,npoints);

        for(int i=0;i<npoints-1;i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,npoints-1,npoints-1,-2);
        H*=-0.5/dr/dr;

        for(int i=0;i<npoints;i++){
            H[i,i]+=-1/r[i];
        }
        return H;
    }
}