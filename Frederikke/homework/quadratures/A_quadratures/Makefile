all: Out.txt errfunc.png
	cat Out.txt

errfunc.png: errfunc.txt errfunc.tab.txt Makefile main.exe
	echo '\
	set term png;\
	set out "$@";\
	set title "Integral of Error Function";\
	set xlabel ' $x$ ';\
	set ylabel ' $y$ ';\
	set key out;\
	set x range [-3:4];\
	plot \
	"errfunc.txt" index 0 using 1:2 with lines title "Error Function Integral Representation",\
	"errfunc.tab.txt" index 0 using 1:2 with points title "Tabulated values"\
	' | tee log | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs quadratures.dll
	mcs -target:exe -reference:quadratures.dll $<

quadratures.dll: quadratures.cs
	mcs -target:library -out:$@ $<

clean: rm -f *.exe *.dll Out.txt *.png
