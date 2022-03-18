SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
# remember to export DOTNET_CLI_TELEMETRY_OPTOUT=1
CSC = mcs -optimize+ -platform:arm
RUN = mono -O=all #-O=all,-shared #--optimize=unsafe,loop,inline #--gc=sgen --llvm --optimize=all

CFLAGS = -Ofast -march=native
LDLIBS = $(shell gsl-config --libs)

comma:=,
empty:=
space:=$(empty) $(empty)
commalist = $(subst $(space),$(comma),$(1))

all: out.txt plot.times.svg times.gsl.svg

out.txt: main.exe Makefile
	$(RUN) $< 7 | tee $@

out.gsl.txt: main Makefile
	cat /dev/null > $@
	for N in `seq 200 10 300`; do \
	echo "N=$$N";\time -ao $@ -f "$$N %U" ./main $$N ; \
	done

main:main.c

times.gsl.svg: out.gsl.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "times,14";\
	set out "$@";\
	set key left;\
	set title "matrix diagonalization times (gsl `gsl-config --version` `uname -m`)";\
	set xlabel "matrix size n";\
	set ylabel "diagonalization time t, sec";\
	f(x)=b+(x/a)**c;\
	b=1; a=90; c=3;\
	fit f(x) "$<" via a,b;\
	plot \
	 "$<" title "measurement" \
	,f(x) title sprintf("fit: (n/%.f)^{%.2f}+%.3f",a,c,b) \
	'| gnuplot

plot.times.svg: out.times.txt Makefile
	echo '\
	set term svg size 640,480 background "white" font "times,14";\
	set out "$@";\
	set key left;\
	set title "matrix diagonalization times (`$(CSC) --version` `uname -m`)";\
	set xlabel "matrix size n";\
	set ylabel "diagonalization time t, sec";\
	f(x)=b+(x/a)**c;\
	b=1; a=90; c=3;\
	fit f(x) "$<" via a,b;\
	plot \
	 "$<" title "measurement" \
	,f(x) title sprintf("cyclic: fit: (n/%.f)^{%.2f}+%.3f",a,c,b) \
	'| gnuplot

out.times.txt: main.exe
	cat /dev/null > $@
	for N in `seq 73 5 133`; do \
	echo "N=$$N";\time -ao $@ -f "$$N %U" $(RUN) main.exe $$N ; \
	done

main.exe: main.cs matrix.dll
	$(CSC) $< -out:$@ -r:$(call commalist,$(filter-out $<,$^))

matrix.dll: jacobi.cs ../matrix/matrix.cs ../matrix/vector.cs
	$(CSC) $^ /t:library /out:$$(pwd)/$@

clean: ; $(RM) *.dll *.exe out.* *.log *.svg

#%.dll: %.cs ; $(CSC) -t:library $*.cs -o:$*.dll *log

test:
	echo $(LDLIBS)
	echo $$($(RUN) --version)
