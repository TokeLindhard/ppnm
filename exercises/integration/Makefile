out.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

matlib.dll: integrate.cs
	mcs -target:library -out:$@ $<
