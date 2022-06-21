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

all: Out.txt Besselcos.pyxplot.png
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

Besselcos.pyxplot.png: J0cos.txt J1cos.txt J2cos.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ J_n(x) $$' \n\
	set grid \n\
	set title 'Bessel function of first kind for integer orders n=0,1,2,3,4' \n\
	set key right top \n\
	plot [0:51] [-0.5:1.2]\
	'J0cos.txt' index 0 using 1:2 with lines title 'J0',\ \n\
	'J1cos.txt' index 0 using 1:2 with lines title 'J1',\ \n\
	'J2cos.txt' index 0 using 1:2 with lines title 'J2',\ \n\
	'J3cos.txt' index 0 using 1:2 with lines title 'J3',\ \n\
	'J4cos.txt' index 0 using 1:2 with lines title 'J4'\ \n\
	" | tee log.gpi | pyxplot

main.exe: main.cs cmath.dll adaptint.dll
	$(CSC) -target:exe -reference:cmath.dll -reference:adaptint.dll $<

adaptint.dll: adaptint.cs cmath.dll
	mcs -target:library -reference:cmath.dll $<

cmath.dll: cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs
	
clean:
	$(RM) *.dll *.exe *.txt *.png *.gpi