SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

erf.pyxplot.png: erf.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'error function' \n\
	set key left top \n\
	plot [-2:2] [-1:1] '$<' index 0 using 1:2 with lines title 'error function',\ \n\
	'erf.tab.txt' with points pointtype 3 title 'tab' \n\
	" | tee log.gpi | pyxplot

erf.data.txt: main.exe
	mono $< > $@

gamma.pyxplot.png: gamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'gamma function' \n\
	set key left top \n\
	plot [-2:2] [-1:1] '$<' index 0 using 1:2 with lines title 'gamma function',\ \n\
	'gamma.tab.txt' with points pointtype 3 title 'tab' \n\
	" | tee loggamma.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

all: main.exe

%.exe: %.cs
	mcs $< > $@