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

all: Out.txt half_life.pyxplot.png
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

half_life.pyxplot.png: tabdata.txt Out.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ t (days) $$' \n\
	set ylabel '$$ Activity $$' \n\
	set title 'Activity of ThX' \n\
	set key right top \n\
	plot [-0.1:20] [0:150] 'Out.txt' index 0 using 1:2 with lines title 'Activity fit',\ \n\
	'tabdata.txt' using 1:2:3 with pointtype 7 yerrorbars title '1902 data' \n\
	" | tee log.gpi | pyxplot

main.exe: main.cs lsfit.dll matlib.dll QRGS.dll
	$(CSC) -target:exe -reference:lsfit.dll -reference:matrix.dll -reference:QRGS.dll $<

lsfit.dll: lsfit.cs matrix.dll QRGS.dll
	$(CSC) -target:library -reference:matrix.dll -reference:QRGS.dll $<

QRGS.dll: QRGS.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
clean:
	$(RM) *.dll *.exe *.txt log*