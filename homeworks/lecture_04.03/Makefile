// LIBDIR = stien til dine integrate.cs

Out.txt: main.exe test.py
	mono $< >$@
	python3 test.py >> $@


main.exe: main.cs matlib.dll

matlib.dll: \
	$(LIBDIR)/integrate/integrate.cs \
	$(LIBDIR)/odeint/cs \
	$(LIBDIR)/matrix/vector.cs	
	mcs -target:library -out./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $filter %.cs,$^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)
