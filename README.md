# xil
Xil is an implementation of the Joy programming language. It is a dynamic, functional, concatenative language. It only knows values and operations. 

It shares some characteristics of the XY programming language by formalizing a queue alongside the stack. This makes it straightforward to define a lot of operations in a continuation-passing style (CPS).

# goals
The main goal for this project is to keep the **Joy** programming language alive and relevant. To make embeddable in .NET environment and to raise interest in stack based concatenative programming languages in general. 

# disclaimer
For now, this project is a toy and should not be used for production systems. It can be a useful playground to play with ideas though.

# quircks
* Joy and by deduction Xil both allow for some pretty crazy identifier names. Most things are a go. For example you can identifiers like `,foo`, `*bar`, `$frotz`, etc. If there's a printable character in front that is not a number it's likely good to go.
* In contrast to Joy, most of Xil is written in CPS inspired by XY and Thun. This means the language is slower (since a lot of stuff reduces to nodes being placed on the queue). On the other hand, it reduces recursion in favor of using more memory and  allows for detailed traces that can support and prove theoretical reasoning about programs. 

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)
* [The Concatenative Language XY](https://www.nsl.com/k/xy/xy.htm)