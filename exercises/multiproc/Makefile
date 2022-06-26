CSC = mcs
RUN = mono

all:Out.txt 
	cat $<

Out.txt: main.exe Makefile
	cat /dev/null > $@
	time -p $(RUN) main.exe >> $@

main.exe: main.cs
	$(CSC) -target:exe -out:$@ $<

clean:
	rm -f *.dll *.exe [Oo]ut* [Ll]og*
