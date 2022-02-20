all: out.txt
	cat $<

out.txt: fileio.exe
	mono fileio.exe -input:input.txt -output:out.txt

fileio.exe: fileio.cs
	mcs -target:exe -out:$@ $<

input.txt:
	echo 1 2 3 4 5 > input.txt

.PHONEY:clean
clean:
	$(RM) [Oo]ut* *.exe [Ll]og*
