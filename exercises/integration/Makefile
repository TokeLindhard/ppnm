erf.pyxplot.png: erf.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'error function' \n\
	set key left top \n\
	plot [-2:2] [-1:1] '$<' index 0 using 1:2 with lines title 'error function' \n\
	" | tee log.gpi | pyxplot

out.txt: main.exe
	mono $< > $@

erf.data.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

matlib.dll: integrate.cs
	mcs -target:library -out:$@ $<

clean:
	$(RM) *.dll *.exe *.txt *.png *.gpi