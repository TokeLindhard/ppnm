public class qrgs{
	public matrix Q,R;

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

	public vector solve(vector b){
		matrix Qt = Q.transpose();
		vector x = Qt*b;
		backsub(R, x);
		return x;	
	}

	public void backsub(matrix U, vector c){ // U is an upper-triangular matrix
		for(int i=c.size-1; i>=0; i--){
			double sum=0;
			for(int k=i+1; k<c.size; k++){
				sum += U[i,k]*c[k];
			}
			c[i] = (c[i]-sum)/U[i,i];
		}
	}


	public matrix inverse(){
		int n = R.size1;
		matrix invA = new matrix(n,n);
		for(int i=0; i<n; i++){
			vector ei = matrix.id(n)[i];
			invA[i] = solve(ei);
		}
		return invA;

	}

}
