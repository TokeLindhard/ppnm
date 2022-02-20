using static System.Math;
using static System.Console;
public class vec{
    public double x,y,z; //the class properties

    //constructor (because it's the same name as the class)
    public vec(){ 
        x=y=z=0; 
        }
    public vec(double x, double y, double z){
        this.x=x;
        this.y=y;
        this.z=z;
    }

    //print method: u.print("u=");
	public void print(string s){
		Write(s);
        WriteLine($"{x} {y} {z}");
		}
    
    //operators:
    public static vec operator*(vec v, double c){
        return new vec(c*v.x,c*v.y,c*v.z);
    }

    public static vec operator*(double c, vec v){
        return v*c;
    }

    public static vec operator+(vec u, vec v){
        return new vec(u.x+v.x,u.y+v.y,u.z+v.z);
    }

    public static vec operator-(vec u, vec v){
        return new vec(u.x-v.x,u.y-v.y,u.z-v.z);
    }

    public static vec operator-(vec u){
        return new vec(-1*u.x,-1*u.y,-1*u.z);
    }
//dot product between two vectors
    public static double dot(vec v, vec u){
        return v.x*u.x+v.y*u.y+v.z*u.z;
    }
//cross product between two vectors
    public static vec cross(vec v, vec u){
        return new vec(v.y*u.z-v.z*u.y,v.z*u.x-v.x*u.z,v.x*u.y-v.y*u.x);
    }
 //norm of vector
    public static double norm(vec u){
        return Sqrt(Pow(u.x,2)+Pow(u.y,2)+Pow(u.z,2));
    }

    public override string ToString(){
        return $"{x} {y} {z}";
    }

    static bool approx(double a,double b,double tau=1e-9,double eps=1e-9){
	if(Abs(a-b)<tau)return true;
	if(Abs(a-b)/(Abs(a)+Abs(b))<eps)return true;
	return false;
	}
    public bool approx(vec other){
	if(!approx(this.x,other.x))return false;
	if(!approx(this.y,other.y))return false;
	if(!approx(this.z,other.z))return false;
	return true;
	}
public static bool approx(vec u, vec v){
    return u.approx(v); 
    }

}