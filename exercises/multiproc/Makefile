SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll 
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all:Out.txt
	cat $<

Out.txt: main.exe Makefile
	cat /dev/null > $@
	/bin/time -p -o $@ --append $(RUN) main.exe >> $@

main.exe: main.cs
	$(CSC) -target:exe -out:$@ $<

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*