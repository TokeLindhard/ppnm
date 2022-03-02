CSC = mcs
RUN = mono
CMATHDIR = /home/toke/repos/ppnm/exercises/complex

all: gamma.pyxplot.png

gamma.pyxplot.png: gamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set zlabel '$$ z $$' \n\
	set title 'Complex gamma' \n\
	set key left top \n\
	plot 3d [-5:5] [-5:5] [0:10]'$<' with lines title 'Complex $$ \Gamma(z) $$'\ \n\
	" | tee log.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<

cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll
