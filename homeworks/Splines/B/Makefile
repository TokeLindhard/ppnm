SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: Out.txt qspline.pyxplot.png
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs qspline.dll
	$(CSC) -target:exe -reference:qspline.dll $<

qspline.dll: qspline.cs
	mcs -target:library $<

qspline.pyxplot.png: qspline.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'Quadratic spline' \n\
	set key left top \n\
	plot [1:10] [0:100]\
	'qspline.txt' index 0 using 1:2 with points pointtype 3 title 'data points',\ \n\
	'qspline.txt' index 1 using 1:2 with lines title 'qspline',\ \n\
	'qspline.txt' index 1 using 1:3 with lines title 'derivative',\ \n\
	'qspline.txt' index 1 using 1:4 with lines title 'integral'\ \n\
	" | tee log.gpi | pyxplot

clean:
	$(RM) *.dll *.exe *.txt *.png [Oo]ut* *.gpi