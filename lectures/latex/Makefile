SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all:ms.pdf

ms.pdf: ms.tex gamma.pyx.pdf
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	pdflatex $<

gamma.pyx.pdf: fig.pyxplot.gpi out.gamma.txt tab.gamma.txt
	pyxplot $<

out.gamma.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs sfuns.dll

%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs 
	$(CSC) -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
