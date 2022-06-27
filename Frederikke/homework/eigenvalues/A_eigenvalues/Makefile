all: Out.txt
	cat Out.txt | less

Out.txt: main.exe
	mono $< >$@

LIBDIR = ../../../matlib

main.exe: main.cs  matrix.dll JacobiDia.dll
	mcs -target:exe -reference:JacobiDia.dll -reference:matrix.dll $<

JacobiDia.dll: JacobiDia.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

matrix.dll: $(LIBDIR)/matrix/matrix.cs $(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *exe *.dll *.txt


