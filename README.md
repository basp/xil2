# xil
Xil is an implementation of the Joy programming language.

```
PS D:\xil2> dotnet run
: 3
  2
  +
  .
5           <- top
```

# notes
Built-in operations can be implemented in various ways and each have their
own pros and cons.

* They can be implemented *directly* in C# manipulating `INode` instances and
the stack directly. This is fast but has the downside that operations become opaque to the tracer. This is probably the preferred way if you plan to run anything serious using **Xil** but let us face it? Who is going to do that in the first place?
* Most can also be implemented *indirectly* as a new sequence of factors prepended to the existing queue of factors. This is slower than the *direct* implementation but if implemented this way the tracer will be able to record each interpretation step and accurately reflect a detailed view of the stack and queue values at each step of the execution of a term which can be a big help during development. It's also easier to reason about since there is no black box.
* It is possible to write each *indirect* implementation as a *direct* implementation but the reverse is not true.
* It is easy to swap out the built-in operations for the interpreter so you can experiement with various implementations of any built-in operator or combinator.

For example, the `map` combinator is implemented in the *direct* style which manipulates the interpreter using the .NET API. This means that there is no trace output for any intermediate steps the `map` combinator might have. 

> There is an experimental `map` combinator that uses the *indirect* style but this fails to push an empty list when mapping on an empty list so at the moment it is not very useful except for demonstration purposes.

The `step` combinator is implemented indirectly by prepending a new list of factors to the queue. This means that when using this combinator, parts of the stack will essentially be new factors that are preprended to the queue to be executed. Other combinators such as `i` and `x` are also implemented in this fashion.

> Make sure you use the `TracingCycleVisitor` if you wanna see traces. If you do not need traces and wanna be a little bit more efficient you can just use the `CycleVisitor` instead. It's recommended to have traces on during development.

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)