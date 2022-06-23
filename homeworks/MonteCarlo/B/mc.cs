using System;
using static System.Math;
public class mc{
     public static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size;
        double V=1; 
        for(int i=0;i<dim;i++){
            V*=b[i]-a[i];
        }
        double sum=0;
        double sum2=0;
        var x=new vector(dim);
        Random rnd = new Random();
        for(int i=0;i<N;i++){
            for(int k=0;k<dim;k++){
                x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
            }
            double fx=f(x);
            sum+=fx;
            sum2+=fx*fx;
        }
        double mean=sum/N;
        double sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
    } 

    public static (double,double) quasimc(Func<vector,double> f, vector a, vector b, int N){
        int dim=a.size;
        double V=1; 
        for(int i=0;i<dim;i++){
            V*=b[i]-a[i];
        }
        double sum=0;
        double sum2=0;
        var x=new vector(dim);
        var x2=new vector(dim);

        for(int i=0;i<N;i++){
            var h = halton(i,dim);
            var h2 = halton(i,dim,true);

            for(int k=0;k<dim;k++){
                x[k] = a[k] + h[k]*(b[k]-a[k]);
                x2[k] = a[k] +h2[k]*(b[k]-a[k]);
            }
            double fx = f(x);
            double fx2 = f(x2);
            sum+=fx;
            sum2+=fx2;
        }
        double mean=sum/N;
        double mean2 = sum2/N;
        var result=(mean*V,Abs(mean-mean2)*V);
        return result;
    }

    public static double corput(int n, int b){
        double q = 0;
        double bk = 1.0/b;
        while(n>0){
            q+=(n%b)*bk;
            n /= b;
            bk /= b;
        }
        return q;
    }

    public static vector halton(int n, int dim, bool reverse=false){
        int[] b = new int[] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
        int maxdim = b.Length;
        if(dim>maxdim){
            throw new System.Exception("Dimension is too large!");
        }
        var x = new vector(dim);
        if(reverse){
            Array.Reverse(b);
        }
        for(int i=0;i<dim;i++){
            x[i] = corput(n,b[i]);
        }
        return x;
    }
}
