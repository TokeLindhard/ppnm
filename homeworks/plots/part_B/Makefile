SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: gamma.pyxplot.png lngamma.pyxplot.png

gamma.pyxplot.png: gamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'gamma function' \n\
	set key left top \n\
	plot [0:10] [0:10] '$<' index 0 using 1:2 with lines title 'gamma function',\ \n\
	'gamma.tab.txt' with points pointtype 3 title 'tab' \n\
	" | tee log.gpi | pyxplot

gamma.data.txt: main.exe
	mono $< > $@

lngamma.pyxplot.png: lngamma.data.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel '$$ x $$' \n\
	set ylabel '$$ y $$' \n\
	set title 'lngamma function' \n\
	set key left top \n\
	plot [0:10] [-1:10] '$<' index 0 using 1:3 with lines title 'lngamma function',\ \n\
	'lngamma.tab.txt' with points pointtype 3 title 'tab' \n\
	" | tee log.gpi | pyxplot

lngamma.data.txt: main.exe
	mono $< > $@

all: main.exe

%.exe: %.cs
	mcs $< > $@

clean:
	$(RM) *.dll *.exe *.png *.gpi *.data.txt
