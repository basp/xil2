# xil2
Xil is an implementation of the Joy programming language that can be embedded in .NET applications.

# reference transcript
```
PS D:\basp\xil2\src\Xil2> dotnet run
: B == 2 3 + .
: A == 4 5 + .
: [B] i.
5
: zap .
: [A] i.
9
: zap .
: [B] [A]
line 1:7 missing '.' at '<EOF>'
[B]
[A]
: .
[B]
[A]
: [[i] dip i] .
[B]
[A]
[[i] dip i]
: cons .
[B]
[[A] [i] dip i]
: cons .
[[B] [A] [i] dip i]
: i
line 1:1 no viable alternative at input 'i'
[[B] [A] [i] dip i]
: i .
5
9
: [5 9] i.
5
9
5
9
: zap zap zap zap .
:
```

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)