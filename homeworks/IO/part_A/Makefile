all: Out.txt
	cat Out.txt

Out.txt: stdin.exe
	echo 1 2 3 4 5 | mono stdin.exe > $@ 

stdin.exe: stdin.cs
	mcs -target:exe -out:$@ $<

