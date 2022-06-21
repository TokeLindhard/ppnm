EXAM PROJECT 18 -- ADAPTIVE INTEGRATION OF COMPLEX-VALUED FUNCTIONS
Lord Toke Marstrand Pontoppidan Lindhard.
My studynumber is 201906464, and 64%23=18, so I am doing the "Adaptive integration of complex-valued functions" exam.
------------------------------------------------------------------------------------------------------------------------
In this project, I have taken the adaptive recursive integrator from the homework 'quadratures' and generalized it to work for complex functions and complex limits as well. The integrator is tested on a few simple functions first to assure it is working correctly. Then, to test if we can reduce the amount of times the integration procedure is called, the Clenshaw-Curtis variable transformation is implemented. Both for the limits [-1,1] and the generalized [a,b]. Both implementations are tested against the same functions as before. Lastly the first kind Bessel function in cosine representation is calculated for n=0,...,4 using the expression from Wikipedia: https://en.wikipedia.org/wiki/Bessel_function. To ullustrate this is working correctly they are plotted and compared to the corresponding figure from Wikipedia. It can be seen that they express the same behaviour as the plot on Wikipedia. 

------------------------------------------------------------------------------------------------------------------------
                                                FILE STRUCTURE
------------------------------------------------------------------------------------------------------------------------
Main.cs: Here there are three processes. One for the test functions, which creates three different functions that calls the adapter from adaptint to integrate the function created. The next process testes the same three functions, but instead calls the Clenshaw-Curtis transformation to integrate the functions. The last process uses the usual adaptive integrator to calculate the first kind Bessel function J_n(x) for n=0,...,4. A for-loop is made over x-values from 0 to 50 and the corresponding J_n(x)-values are written into seperate files, so the Out.txt file doesn't get cluttered.

adaptint.cs: Contains the adaptive integrator. It is split into three parts. The integrate and adapter functions together make the integration with adaptive stepsize work, while the last function is the Clenshaw-Curtis transformation, which is only optional. 

cmath.cs: Library, which contains some of the common mathematical identities using complex numbers.

complex.cs: Library, which defines complex numbers and simple operations on them.

Bessel.pyxplot.png: Contains the plot made when calculating J_0(x),...,J_4(x). Consistent with plot from Wikipedia article linked above.

Out.txt: Output file for the integrations and explanatory text (aside from the Bessel functions. The data from them can be found in J0cos.txt,...,J4cos.txt).

Makefile: Creates all the necessary files with the correct dependencies, and also has a make clean function, which can be used to remove all files, that will be created by the program anyways. 

All references to equations are from the lecture notes. Specifically from the chapter "Integration".

