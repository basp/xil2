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

* They can be implemented directly in C# manipulating `INode` instances and
the stack directly. This is fast but has the downside that operations become opaque to the tracer.
* Most can also be implemented as a new sequence of factors prepended to the existing queue of factors. If implemented this way the tracer will be able to record each interpretation step and accurately reflect a detailed view of the stack and queue values at each step of the execution of a term.

For example, the `map` combinator is implemented in the *direct* style which manipulates the interpreter using the .NET API. This means that there is no trace output for any intermediate steps the `map` combinator might have. The `step` combinator is implemented indirectly by prepending a new list of factors to the queue. This means that when using this combinator, parts of the stack will essentially be new factors that are preprended to the queue to be executed. Other combinators such as `i` and `x` are also implemented in this fashion.

> Make sure you use the `TracingCycleVisitor` if you wanna see traces.

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)