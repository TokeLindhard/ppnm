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

all: Fig.oscillator.png
Fig.oscillator.png: fig.oscillator.gpi oscillator.data.txt
	pyxplot $<

oscillator.data.txt: main.exe
	$(RUN) $< 1> $@ 2>log

main.exe: main.cs matlib.dll

LIBDIR = ../../matlib
matlib.dll: \
	$(LIBDIR)/odeint/ode.cs \
	$(LIBDIR)/matrix/vector.cs
	$(CSC) -target:library -out:./$@ $^
	
%.exe: %.cs
	$(CSC) -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	$(CSC) -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
