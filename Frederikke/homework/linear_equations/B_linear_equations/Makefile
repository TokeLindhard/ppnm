all: Out.txt
	cat Out.txt | less

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll QR-GramSchmidt.dll
	mcs -target:exe -reference:matrix.dll -reference:QR-GramSchmidt.dll $<

QR-GramSchmidt.dll: QR-GramSchmidt.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -f *.exe *.dll *.txt



