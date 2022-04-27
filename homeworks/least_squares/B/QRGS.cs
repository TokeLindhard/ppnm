using static System.Math;
public class qrgs{

	public matrix Q,R;
	public matrix QR;

		public qrgs(matrix A){
		Q = A.copy();
		int m = A.size2;
		R = new matrix(m,m);
		for(int i=0; i<m; i++){
			R[i,i] = Q[i].norm();
			Q[i] /= R[i,i];
			for(int j=i+1; j<m; j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j]-=Q[i]*R[i,j];
			}
		}
	}
	public vector solve(vector r){
		var QT = Q.transpose();
		vector x = QT*r;
		vector y = backsub(R,x);
		return y;
	}//solve using backsub

	public static vector backsub(matrix U, vector c){	
		vector y = new vector(c.size);
		for(int i = c.size-1; i>=0; i--){
			double sum=0;
			for(int k = i+1; k<c.size; k++){
				sum+=U[i,k]*y[k];
			}
			y[i]=(c[i]-sum)/U[i,i];
		}
		return y;
	}
	public matrix inverse(){
		int m = R.size1;
		matrix B = new matrix(m,m);
		vector e = new vector(m);
		for(int i=0;i<m;i++){
			e[i]=1;
			B[i]=solve(e);
			e[i]=0;
		}
		return B;
	}//inverse
}