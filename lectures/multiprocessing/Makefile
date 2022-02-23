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

Out.txt: t2.exe t1.exe pfor.exe Makefile
	cat /dev/null > $@
	/bin/time -portability -output $@ --append $(RUN) t1.exe &>> $@
	/bin/time -p -o $@ --append $(RUN) t2.exe &>> $@
	/bin/time -p -o $@ --append $(RUN) t2.exe &>> $@
	/bin/time -p -o $@ --append $(RUN) pfor.exe 5e7 &>> $@

t2.exe: t2.cs
	$(CSC) -target:exe -out:$@ $<

t1.exe: t1.cs
	$(CSC) -target:exe -out:$@ $<

pfor.exe: pfor.cs
	$(CSC) -target:exe -out:$@ $<

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
