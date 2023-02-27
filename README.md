# xil
Xil is an implementation of the Joy programming language. It is a dynamic, functional, concatenative language. It only knows values and operations. 

In contrast to Joy, which builtins are mostly implemented opaquely. Xil takes some inspiration of the XY programming language by somewhat formalizing a queue alongside the stack. This makes it straightforward to define a lot of operations in a continuation-passing style (CPS).

# interpreter
When the interpreter starts the parsed term (list of factors) is the queue. Every cycle a factor is dequeued and interpreted:

* If it is a symbol we attempt a lookup in the interpreter environment.
    * If this fails we throw a `RuntimeException`.
    * If this succeeds we check wheter this is a builtin symbol.
        * If this is a builtin then we just execute the associated action which is defined in C# code.
        * If this symbol was defined at runtime (as a Joy definition) we
        will prepend its body of factors to the queue to be executed.
* If the factor is not a symbol we will push the node (i.e. its literal value) onto the stack.

Symbols that are defined at runtime are always traceable and executed transparently. This means you can get a full trace using the `trace` builtin. This is not always the case for builtin operations though. A lot of the primitives are opaque in the sense that they operate on the stack directly in a conceptually atomic operation. Usually this means that they do not use the queue so it makes no sense to trace them.

Most of the combinators (higher order operations) are interpreted transparantely even though they are builtin. This means they will use the queue and they will be traceable. If you need more performance then it is quite easy to implement them in an opaque fashion which can usually be much faster at the expense of losing some visibility into the execution of your program.

# goals
The main goal for this project is to keep the **Joy** programming language alive and relevant. To make embeddable in .NET environment and to raise interest in stack based concatenative programming languages in general. 

# disclaimer
For now, this project is a toy and should not be used for production systems. It can be a useful playground to play with ideas though.

# quircks
* Joy and by deduction Xil both allow for some pretty crazy identifier names. Most things are a go. For example you can identifiers like `,foo`, `*bar`, `$frotz`, etc. If there's a printable character in front that is not a number it's likely good to go.
* In contrast to Joy, most of Xil is written in CPS inspired by XY and Thun. This means the language is slower (since a lot of stuff reduces to nodes being placed on the queue). On the other hand, it reduces recursion in favor of using more memory and  allows for detailed traces that can support and prove theoretical reasoning about programs. 
* It is possible to drastsically change the semantics of the language by choosing to push nodes either to the stack or the queue. For example, the `ifte` operator can be implemented lazily by pushing part of its quotation on the stack instead of queuing this.

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)
* [The Concatenative Language XY](https://www.nsl.com/k/xy/xy.htm)