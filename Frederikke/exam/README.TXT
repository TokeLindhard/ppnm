Author: Frederikke Filippa Vorgod

Student number: 201907640

Exam question: 40%23 = 17

Description of project: Implement the inverse iteration algorithm that calculates the eigenvalue (and the corresponding eigenvector) of the given symmetric matrix A that is closest to the given shift-value s. Use your own linear algebra routines.

_____________________________Exam projekt_______________________________

In this project, I have implemented the inverse iteration algoritm. 
The inverse iteration was performed using the QR-decomposition routine used in the homework "Linear Equations".   


This folder contains the implementation on a random matrix A with a random vector.
The folder Inverse_Iteration_on_hydrogen_atom contains the sam iteration on the hydrogen atom. 
For this iteration an eigenvector for the hydrogen atom was used. 
The eigenvector was found using the Jacobi routine from the "Eigenvalues" homework. 

________________________Important files__________________________

This project contain some important files

Invers_Iteration: This file is identical for both the random iteration and the iteration for the hydrogen atom.
The file runs the Inverse Iteration function on a given matrix A. It calculates the identity matrix for the given matrix A.
It requries a vector b, which will be the first guess for a eigenvector. 
It also requires two doubles as an input; one of the is s called the shift-factor, which is a quess for the eigenvalue and acc which is the accuracy.
The function return an eigenvector and an eigenvalue for matrix A.

main.cs: This file is different depending the matrix the user wishes to use.
In the main "exam" folder this file creates a random matrix and vector. In the folder Inverse_Iteration_on_hydrogen_atom this file creates the matrix for the hydrogen atom and calculates the eigenvector using the Jacobi method. 
This file also contains the value for the shift factor s and the accuracy, and calculates the mismatch.

Makefile: This file states the dependencies of the different files in the folder, and contain libraries that can runs the QR-decomposition rutine and the Jacobi rutine from differnet folders in the repository. 
