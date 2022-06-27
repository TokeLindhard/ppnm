public static partial class interp{
public static double linear(double[] x, double[] y, double z){
	int n=x.Length;
	if(z<x[0] || z>x[n-1]) return double.NaN;
	int i=0, j=n-1;
	while(j-i>1){int m=(i+j)/2; if(z>x[m]) i=m; else j=m;}
	double dy=y[i+1]-y[i], dx=x[i+1]-x[i];
	if(!(dx>0)) return double.NaN;
	return y[i]+dy/dx*(z-x[i]);
}
}

