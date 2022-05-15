SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: Out.txt 2ndpoly.pyxplot.png integration.pyxplot.png
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs interpolation.dll 
	$(CSC) -target:exe -reference:interpolation.dll $<

interpolation.dll: interpolation.cs
	mcs -target:library $<

2ndpoly.pyxplot.png: 2ndpoly.txt integration.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title '2nd degree polynomial and integrated function' \n\
	set key left top \n\
	plot [1:10] [0:100]\
	'2ndpoly.txt' index 0 using 1:2 with points pointtype 3 title 'data points',\ \n\
	'integration.txt' index 0 using 1:2 with lines title 'linear interpolation',\ \n\
	'integration.txt' index 0 using 1:3 with lines title 'integrated function'\ \n\
	" | tee log.gpi | pyxplot


clean:
	$(RM) *.dll *.exe *.txt *.png [Oo]ut*