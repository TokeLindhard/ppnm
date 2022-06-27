from scipy import integrate as integrate
import math;
ncalls=0;
def f(x):
	global ncalls
	ncalls+=1
	return math.log(x)/math.squrt(x)

result = scipy.integrate.quad(f,0,1)
print("result=", result, "ncalls", ncalls)
