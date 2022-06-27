all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll QR-GramSchmidt2.dll
	mcs -target:exe -reference:matrix.dll -reference:QR-GramSchmidt2.dll $<

QR-GramSchmidt2.dll: QR-GramSchmidt2.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt


