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

all: Out.txt testsolv.pyxplot.png damposc.pyxplot.png
	cat Out.txt

testsolv.pyxplot.png: testsolv.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'testsolv' \n\
	set key right top \n\
	plot [0:7] [-1:1]\
	'testsolv.txt' index 0 using 1:2 with lines title 'sin',\ \n\
	'testsolv.txt' index 0 using 1:3 with lines title 'cos'\ \n\
	" | tee log.gpi | pyxplot

damposc.pyxplot.png: damposc.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ t $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'damped oscillator' \n\
	set key right top \n\
	plot [0:11] [-4:4]\
	'damposc.txt' index 0 using 1:2 with lines title 'theta',\ \n\
	'damposc.txt' index 0 using 1:3 with lines title 'omega'\ \n\
	" | tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll ode.dll
	$(CSC) -target:exe -reference:matrix.dll -reference:ode.dll $<

ode.dll: ode.cs matrix.dll
	mcs -target:library -reference:matrix.dll $<

LIBDIR = ../../../matlib

matrix.dll: \
	$(LIBDIR)/matrix/matrix.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
clean:
	$(RM) *.dll *.exe *.txt *.png