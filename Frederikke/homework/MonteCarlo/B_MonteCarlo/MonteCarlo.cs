using System;
using static System.Console;
using static System.Math;

public static class MonteCarlo{
	public static (double, double) plain_integration (Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;

		double V = 1;
		for (int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		
		double sum1 = 0;
		double sum2 = 0;
		var rand = new Random();

		var x = new vector(dim);
		for (int i=0; i<N; i++){
			for (int k=0; k<dim; k++){
				x[k] = a[k] + rand.NextDouble()*(b[k] - a[k]);
			}		
			double fx = f(x);
			sum1 += fx;
			sum2 += fx*fx;
		}
	
		double mean = sum1/N;
		double sigma = Sqrt(sum2/N-mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;

	} // afslutter plainmc

	public static (double, double) quasi_rand_seq(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1;
		for (int i=0; i<dim; i++){
			V *= b[i] - a[i];
		}
		
		double sum1 = 0;
		double sum2 = 0;

		var x1 = new vector(dim);
		var x2 = new vector(dim);

		for (int i=0; i<N; i++){
			var hal1 = halton(i, dim);
			var hal2 = halton(i, dim, true);
			for (int k=0; k < dim; k++){
				x1[k] = a[k] + hal1[k]*(b[k] - a[k]);
				x2[k] = a[k] + hal2[k]*(b[k] - a[k]);
			}		
			double fx1 = f(x1);
			double fx2 = f(x2);
			sum1 += fx1;
			sum2 += fx2;
		}
	
		double mean1 = sum1/N;
		double mean2 = sum2/N;
		var result = (mean1*V, Abs(mean1 - mean2)*V);
		return result;

	} // afslutter quasimc


	public static double van_der_corput(int n, int bas){
		double q = 0;
		double bk = 1.0/bas;
		while(n>0){
			q += (n % bas) * bk;
			n /= bas;
			bk /= bas;
		}
		return q;
	} //afslutter corput


	public static vector halton(int n, int dim, bool reverse = false){
		int[] bas = new int[] {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
		if(dim>bas.Length){
			throw new System.Exception("Dimension too large!");
		}

		var x = new vector(dim);

		if(reverse) Array.Reverse(bas);

		for(int i=0; i<dim; i++){
			x[i] = van_der_corput(n, bas[i]);
		}

		return x;	
	
	} // afslutter halton



} // afslutter MonteCarlo

