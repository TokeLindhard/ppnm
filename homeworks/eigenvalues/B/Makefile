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

all: Out.txt rmaxConvergence.pyxplot.png drConvergence.pyxplot.png
	cat Out.txt

rmaxConvergence.pyxplot.png: rmaxConvergence.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ rmax $$' \n\
	set ylabel '$$ energy $$' \n\
	set title 'rmax convergence' \n\
	set key right top \n\
	plot [0:30] [-1:5]\
	'rmaxConvergence.txt' index 0 using 1:2 with lines title 'E0',\ \n\
	'rmaxConvergence.txt' index 0 using 1:3 with lines title 'E1',\ \n\
	'rmaxConvergence.txt' index 0 using 1:4 with lines title 'E2',\ \n\
	-1.0/2 with lines title 'exact E0',\ \n\
	-1.0/8 with lines title 'exact E1',\ \n\
	-1.0/18 with lines title 'exact E2' \ \n\
	" | tee log.gpi | pyxplot

drConvergence.pyxplot.png: drConvergence.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ dr $$' \n\
	set ylabel '$$ energy $$' \n\
	set title 'dr convergence' \n\
	set key right top \n\
	plot [0:10] [-4:0]\
	'drConvergence.txt' index 0 using 1:2 with lines title 'E0',\ \n\
	'drConvergence.txt' index 0 using 1:3 with lines title 'E1',\ \n\
	'drConvergence.txt' index 0 using 1:4 with lines title 'E2',\ \n\
	-1.0/2 with lines title 'exact E0',\ \n\
	-1.0/8 with lines title 'exact E1',\ \n\
	-1.0/18 with lines title 'exact E2' \ \n\
	" | tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll Jacobi.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:Jacobi.dll $<

Jacobi.dll: Jacobi.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
clean:
	$(RM) *.dll *.exe *.txt *.png