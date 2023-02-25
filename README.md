# xil
Xil is an implementation of the Joy programming language. It also shares some characteristics of the XY programming language by formalizing a a queue alongside the stack. This was mainly inspired by Thun which is also based on Joy and has a concept of a queue as well.

```
xil> 1 2 "three" "four" 5.0.

                     . 1 2 "three" "four" 5
                   1 . 2 "three" "four" 5
                 1 2 . "three" "four" 5
         1 2 "three" . "four" 5
  1 2 "three" "four" . 5
1 2 "three" "four" 5 .

5           <- top
"four"
"three"
2
1
```

```
xil> [1 2 3] [dup *] step.

                . [1 2 3] [dup *] step
        [1 2 3] . [dup *] step
[1 2 3] [dup *] . step
          1 4 9 .

9           <- top
4
1
```

# notes
Built-in operations can be implemented in various ways and each have their own pros and cons.

* They can be implemented *directly* in C# manipulating `INode` instances and the stack. This is fast but has the downside that operations become opaque to the tracer. This is probably the preferred way if you plan to run anything serious using **Xil** but who is going to do this? For theoretical purposes it is more interesting to implement the combinators *indirectly* (see next bullet).
* They can also be implemented *indirectly* as a new sequence of factors prepended to the existing queue of factors. This is slower than the *direct* implementation but if implemented this way the tracer will be able to record each interpretation step. It will be able to accurately reflect a detailed view of the stack and queue values at each step of the term including expansions. This can be a big help during development. It is also easier to reason about since there is little or no black box behavior. Finally, it just looks amazing to see your your simple `step` operator unrolled.

Some other features of the current interpreter:
* By itself the interpreter doesn't do much. It needs a predefined set of symbols to be able to perform some useful tasks.
* It is easy to swap out the built-in operations for the interpreter so you can experiement with various implementations of any built-in operator or combinator. This essentially allows you to compose your own interpreter core, mixing and matching operations.
* The `Operations` class contains reference implementations for the most common operators and combinators and any other built-ins that are essential to bootstrap an interpreter. 
* Composing an interpreter core is as easy as implementing the `Interpreter` class and picking and assigning operations to symbols in the interpreter. This means you can easily compose your own interpreter kernel. An `Interpreter` instance is also a dictionary where a name can be mapped to a sequence of `INode` instances.
* the `Flat` operations (e.g. `IFlat`, `XFlat`, etc.) in the `Operations` class perform the same operation as their non-flat counterparts but they will expand onto the queue instead of operating directly on the stack. You typically don't really need these for production but they can be fun for theoretical purposes.
* The interpreter does not care whether a particular operation is implemented directly (opaque) or via the queue (transparent). It just does its thing. It is also OK to manipulate the interpreter queue and/or stack directly from combinators.
* See the `CoreEx` class for an example of an interpreter kernel.

> Make sure you use the `TracingCycleVisitor` if you want to see traces. If you do not need traces and wanna be a little bit more efficient you can just use the `CycleVisitor` instead. It's recommended to have traces on during development.

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)
* [The Concatenative Language XY](https://www.nsl.com/k/xy/xy.htm)