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
		int n = R.size1;
		matrix invA = new matrix(n,n);
		for(int i=0; i<n; i++){
			vector ei = matrix.id(n)[i];
			invA[i] = solve(ei);
		}
		return invA;
	}//inverse
}