all: Out.txt
	cat Out.txt | less

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll JacobiDia.dll Invers_Iteration.dll
	mcs -target:exe -reference:matrix.dll -reference:JacobiDia.dll -reference:Invers_Iteration.dll $<

Invers_Iteration.dll: Invers_Iteration.cs matrix.dll QR-GramSchmidt.dll
	mcs -target:library -reference:matrix.dll -reference:QR-GramSchmidt.dll $<

QRDIR = ../../homework/linear_equations/B_linear_equations

QR-GramSchmidt.dll: \
	$(QRDIR)/QR-GramSchmidt.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $<

JacobiDIR = ../../homework/eigenvalues/A_eigenvalues

JacobiDia.dll: \
	$(JacobiDIR)/JacobiDia.cs
	mcs -target:library -reference:matrix.dll -out:./$@ $<

LIBDIR = ../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^


clean:
	rm -f *.exe *.dll *.txt
