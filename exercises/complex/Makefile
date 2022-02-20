all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*.txt
