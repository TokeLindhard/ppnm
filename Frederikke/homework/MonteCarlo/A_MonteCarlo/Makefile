all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll MonteCarlo.dll
	mcs -target:exe -reference:MonteCarlo.dll -reference:matrix.dll $<

MonteCarlo.dll: MonteCarlo.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll:\
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean: 
	rm -f *.exe *.dll *.txt
