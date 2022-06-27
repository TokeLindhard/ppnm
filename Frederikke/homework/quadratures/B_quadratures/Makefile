all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs quadratures.dll matrix.dll
	mcs -target:exe -reference:quadratures.dll -reference:matrix.dll $<

quadratures.dll: quadratures.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean: rm -f *.exe *.dll Out.txt *.png
