SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
# export DOTNET_CLI_TELEMETRY_OPTOUT=1
CSC = mcs
RUN = mono

all: Out.txt erf.pyxplot.png
	cat Out.txt

erf.pyxplot.png: erf.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ z $$' \n\
	set ylabel '$$ erf(z) $$' \n\
	set title 'Error function' \n\
	set key left top \n\
	plot [-4:4] [-2:2]\
	'erf.txt' index 0 using 1:2 with lines title 'Integrated values',\ \n\
	'erf.txt' index 1 using 1:2 with points title 'Tabulated values'\ \n\
	" | tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll quad.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:quad.dll $<

quad.dll: quad.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
clean:
	$(RM) *.dll *.exe *.txt *.png