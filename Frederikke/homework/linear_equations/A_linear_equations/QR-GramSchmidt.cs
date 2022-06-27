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
			vector b=r.copy();
			for(int q=0;q<QR.size2;q++){
				for(int p=q+1;p<QR.size1;p++){
					double theta = QR[p,q];
					double c=Cos(theta),s=Sin(theta);
					double xq=b[q], xp=b[p];
					b[q]=+xq*c+xp*s;
					b[p]=-xq*s+xp*c;
				}
			}
		vector x = new vector(QR.size2);
		for(int i=QR.size2-1;i>=0;i--){
			double s=0; for(int k=i+1;k<QR.size2;k++) s+=QR[i,k]*x[k];
			x[i]=(b[i]-s)/QR[i,i];
		}
		return x;
	}//solve

	public matrix inverse(){
		int m=QR.size2;
		var B=new matrix(m,m);
		var e=new vector(m);
		for(int i=0;i<m;i++){
			e[i]=1;
			B[i]=solve(e);
			e[i]=0;
		}
		return B;
	}//inverse
}
