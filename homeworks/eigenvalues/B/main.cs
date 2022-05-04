using System;
using static System.Console;
using System.IO;

class main{
    static double rmax = 10; //max integration value
    static int N = 100; //number of points in grid
    static double dr = rmax/(N+1); //stepsize
    static vector r = new vector(N);
    public static void Main(){ 
        matrix H = makeH();
        //(matrix D, matrix V) = Jacobi.cyclic(H);
        //D.print();
        //WriteLine();
        //WriteLine();
        //V.print();
        rmaxConvergence();
        drConvergence();
    }

    public static matrix makeH(){
        for(int i=0;i<N;i++){
            r[i]=dr*(i+1);
        }

        matrix H = new matrix(N,N);

        for(int i=0;i<N-1;i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,N-1,N-1,-2);
        H*=-0.5/dr/dr;

        for(int i=0;i<N;i++){
            H[i,i]+=-1/r[i];
        }
        return H;
    }

    public static void rmaxConvergence(){
        WriteLine("As expected for higher rmax-values the result converges");
        using(var outfile = new StreamWriter("rmaxConvergence.txt")){
            double dr = 0.5;
            for(int varyrmax=2; varyrmax<50;varyrmax++){ //getting the eigenvalues out at different rmax values. Going up to a max
                int N = (int)(varyrmax/dr-1);
                vector r = new vector(N);
                for(int i=0;i<N;i++){
                    r[i]=dr*(i+1);
                }

                matrix H = new matrix(N,N);

                for(int i=0;i<N-1;i++){
                    matrix.set(H,i,i,-2);
                    matrix.set(H,i,i+1,1);
                    matrix.set(H,i+1,i,1);
                }
                matrix.set(H,N-1,N-1,-2);
                H*=-0.5/dr/dr;

                for(int i=0;i<N;i++){
                    H[i,i]+=-1/r[i];
                }
                (matrix D, matrix V) = Jacobi.cyclic(H);
                outfile.WriteLine($"{varyrmax} {D[0][0]} {D[1][1]} {D[2][2]}"); //D matrix is stupidly huge, but
                //since the eigenvalues are ordered with the numerically largest first, we focus on the first 3.
            }
        }
    }

    public static void drConvergence(){
        WriteLine("As expected dr converges for low dr, but goes far from result for higher dr");
        using(var outfile = new StreamWriter("drConvergence.txt")){
            double rmax = 35;
            for(double varydr=0.1; varydr<6;varydr+=0.1){ //getting the eigenvalues out at different dr values. Going up to a max
                int N = (int)(rmax/varydr-1);
                vector r = new vector(N);
                for(int i=0;i<N;i++){
                    r[i]=dr*(i+1);
                }

                matrix H = new matrix(N,N);

                for(int i=0;i<N-1;i++){
                    matrix.set(H,i,i,-2);
                    matrix.set(H,i,i+1,1);
                    matrix.set(H,i+1,i,1);
                }
                matrix.set(H,N-1,N-1,-2);
                H*=-0.5/varydr/varydr;

                for(int i=0;i<N;i++){
                    H[i,i]+=-1/r[i];
                }
                (matrix D, matrix V) = Jacobi.cyclic(H);
                outfile.WriteLine($"{varydr} {D[0][0]} {D[1][1]} {D[2][2]}"); //D matrix is stupidly huge, but
                //since the eigenvalues are ordered with the numerically largest first, we focus on the first 3.
            }
        }
    }
}