# xil
Xil is an implementation the [Joy](https://hypercubed.github.io/joy/joy.html) programming language. It is a dynamic, functional, concatenative language. It shares a few semantical concepts with [XY](https://nsl.com/k/xy/xy.htm) which in turn is also inspired by Joy. The implementation was inspired by [Thun](https://joypy.osdn.io/notebooks/Intro.html).

In contrast to Joy, where built-ins are mostly implemented opaquely. Xil takes some inspiration of the XY programming language by formalizing a queue alongside the stack in its execution semantics. This allows for most combinators to be implemented in a *transparent* (continuation-passing style) fashion that makes it easy to observe the transformation steps that take place on the stack as well as the queue.

## overview
At a very basic level Xil is just a calculator. You push things to a **stack** memory, invoke an operation denoted by a *symbol* and it will replace zero or more values on the current stack with zero or more computed values. Unlike a basic calculator, Xil is also symbolic in that programs are just data. This means that a program is a list and a list is also a program. Xil is dynamic so it does not care what is on the stack up until the moment it actually tries to use these values for an operation. 

If the stack does not contain the right amount or right kinds of factors then it will complain. Xil will try to do some basic type inference when its convenient. * All values are *thruthy* in that they can be evaluated to `true` or `false`.
* All `Integer` nodes will readily convert to `Float` nodes via the `IFloatable` interface which also supplies the binary arithmetic for basic math such as `+`, `-`, `/`, `*`, etc.
* All `Integer`, `Char` and `Bool` values support ordinal operations (such as `succ` and `pred`) via the `IOrdinal` interface. 
* `List`s, `String`s and `Set`s implement the `IAggregate` interface which means they support (amongst other) `first`, `rest`, `concat` and `cons` operations.

The list of remaining *factors* (or nodes) to be executed is called the **queue**. In the example below we construct a *quotation* (a list of factors) and push it onto the stack. Then we invoke the `trace` *combinator* which takes the program and prepends it to the queue as a program to be executed (a combinator is not unlike a higher order function). The interpreter will then to proceed to execute this program normally while keeping a record of the stack and queue at each evaluation step (i.e. each factor in the queue). When the `trace` operator completes, the trace history will be printed before the usual stack display.
```
xil> [2 3 +].

[2 3 +]     <- top

xil> trace.

    . 2 3 +
  2 . 3 +
2 3 . +
  5 .

5           <- top
```

In the trace history, the stack is displayed on the left of the dot (`.`) and the queue is displayed on the right. The rightmost item on the stack is the top of the stack (TOS) and the leftmost item in the queue is the factor to be evaluated.

It is possible to have multiple traces in a single term:
```
xil> [3 2 +] trace [3 2 +] trace [-] trace.

    . 3 2 +
  3 . 2 +
3 2 . +
  5 .

    5 . 3 2 +
  5 3 . 2 +
5 3 2 . +
  5 5 .

5 5 . -
  0 .

0           <- top
```

In contrast to XY which allows programmers to also manipulate the queue directly, Xil only allows this in the context of some combinators. The queue can be implicitly manipulated but it is not possible to manipulate it directly as is possible with the stack. The `i` and `x` combinators in particular are an exception in that they resemble the `/` (`use`) operation in XY and directly manipulate the queue by prepending the top of the stack as a quotation onto the queue to be executed.

For example:
```
xil> [[3 2 +] i] trace.

        . [3 2 +] i
[3 2 +] . i
        . 3 2 +
      3 . 2 +
    3 2 . +
      5 .

5           <- top
```

The `x` combinator does the same but it leaves the original program on the stack:
```
xil> [[3 2 +] x] trace.

            . [3 2 +] x
    [3 2 +] . x
    [3 2 +] . 3 2 +
  [3 2 +] 3 . 2 +
[3 2 +] 3 2 . +
  [3 2 +] 5 .

5           <- top
[3 2 +]
```

We can also define things at runtime. In the example below we are defining the `true` and `false` clauses for a `branch` combinator.
```
xil> If == [3 2 +].

xil> Else == [4 5 +].

xil> [true If Else branch] trace.

                     . true If Else branch
                true . If Else branch
                true . [3 2 +] Else branch
        true [3 2 +] . Else branch
        true [3 2 +] . [4 5 +] branch
true [3 2 +] [4 5 +] . branch
                     . 3 2 +
                   3 . 2 +
                 3 2 . +
                   5 .

5           <- top
```

By using the `intern` operator to transform strings into symbols in conjunction with the `unit` operator we can also compose dynamic calls as shown in the following example.
```
xil> foo == 3 2 +.

xil> ["foo" intern unit i] trace.

      . "foo" intern unit i
"foo" . intern unit i
  foo . unit i
[foo] . i
      . foo
      . 3 2 +
    3 . 2 +
  3 2 . +
    5 .

5           <- top
```

> A caveat to all of this is that we do not support the module semantics as defined in the Joy papers (i.e. the `LIBRA`, `HIDE`, `IN`, `DEFINE` stuff). The module system is not super great and while the interpreter is still not complete it does not make much sense to have a module system in the first place. There will be definitely some kind of way to read in a list of definitions order to setup the interpreter environment in the near future but a fully fledged module system will have to wait until later.

# execution
The interpreter is started by a call to `Execute` from a client application. The client is responsible for supplying a *term* (a sequence of `INode` instances called *factors*) as an argument when invoking the `Execute` method. When the interpreter starts it will initialize its queue to the list of factors supplied. Next it will loop continuously until it is unable to dequeue a node from the queue. Every loop the interpreter will look at the first node at the queue and evaluate it using the following algorithm:

* If it is a symbol we attempt a lookup in the interpreter environment.
    * If this fails we throw a `RuntimeException`.
    * If the lookup succeeds we check wheter this is a built-in symbol.
        * If this is a built-in then we just execute the associated 
        `Action<Interpreter>` which is defined in C# code.
        * If this symbol was defined at runtime (as a Joy definition) we
        will prepend its body of factors to the queue to be executed.
* If the factor is not a symbol we will push the node (i.e. its literal value) onto the stack.

## tracability
Symbols that are defined at runtime are always traceable and executed transparently. This means you can get a full trace using the `trace` builtin. This is not always the case for builtin operations though. A lot of the primitives are opaque in the sense that they operate on the stack directly in a conceptually atomic operation. Usually this means that they do not use the queue so it makes no sense to trace them.

For example, take the `+` operator. This cannot reduce further so it is a primitive to the interpreter and has to be executed in an opaque way. This means we cannot *see into* the `+` operator. It is a black box and we can only see the stack before and after, there is no queue manipulation:
```
xil> [3 2 +] trace.

    . 3 2 +
  3 . 2 +
3 2 . +
  5 .

5           <- top
```

Most of the combinators (higher order operations) are interpreted transparantely even though they are builtin. This means they will use the queue and they will be traceable. If you need more performance then it is quite easy to implement them in an opaque fashion which can usually be much faster at the expense of losing some visibility into the execution of your program.

Contrast the following `map` example with the `+` operator from above, you can see that `map` translates into a bunch of `infra`, `first` and `swaack` stuff with the current stack `["foo", "bar"]` meshed in between them.

We will push some strings on the stack beforehand to indicate how this preserves the current stack by enqueing at a list just in front of the `swaack`.
```
xil> "foo" "bar".

"bar"       <- top
"foo"

xil> [[1] [dup +] map] trace.

                             "foo" "bar" . [1] [dup +] map
                         "foo" "bar" [1] . [dup +] map
                 "foo" "bar" [1] [dup +] . map
"foo" "bar" [] [[1] [dup +] infra first] . infra
                                         . [1] [dup +] infra first ["bar" "foo"] swaack
                                     [1] . [dup +] infra first ["bar" "foo"] swaack
                             [1] [dup +] . infra first ["bar" "foo"] swaack
                                       1 . dup + [] swaack first ["bar" "foo"] swaack
                                       1 . 1 + [] swaack first ["bar" "foo"] swaack
                                     1 1 . + [] swaack first ["bar" "foo"] swaack
                                       2 . [] swaack first ["bar" "foo"] swaack
                                    2 [] . swaack first ["bar" "foo"] swaack
                                     [2] . first ["bar" "foo"] swaack
                                       2 . ["bar" "foo"] swaack
                         2 ["bar" "foo"] . swaack
                         "foo" "bar" [2] .

[2]         <- top
"bar"
"foo"
```

> This is more or less equivalent to where any other interpreter would save the current stack frame by pushing it onto the stack but in this case we just wrap the stack into a list value and sqeeze it into the the queue instead, eliminating any recursion in the process.

An interesting thing to observe is how the `map` operator by itself could be considered rather opaque in the sense that it mostly operates on the stack instead of the queue. However, it does not really gobble up any values and just reshuffles and recombines them with new values. And, by virtue of it reducing to `infra`, we still get a lot of transparency.

# goals
The main goal for this project is to keep the **Joy** programming language alive and relevant and to raise interest in stack based concatenative programming languages in general. 

This is meant to be embeddable in any .NET application. The main use case is embedding one or more interpreters to execute realitively simple programs in parallel or sequence or delayed by time (so that we can delay tasks on a queue of things to execute). 

Another possible scenario is to have a higher level language and transpile it to Joy/Xil. In fact, the original (somewhat ambitious) goal was to have an X intermediate language (where the name Xil comes from) that could serve as a general purpose, high level stack based IL for virtual machines.

# disclaimer
For now, this project is a toy and should not be used for production systems. It can be a useful playground to play with ideas though.

# random
* Joy and by deduction Xil both allow for some pretty crazy identifier names. Most things are a go. For example you can have identifiers like `,foo`, `*bar`, `$frotz`, `#.234*foo` etc. If there's a printable character in front that is not a number it's likely good to go.
* The parser does not accept symbols starting with a digit (i.e. `0..9`) but since the interpreter does not care it is possible to push symbols starting with an digit onto the stack using the `intern` operator.
```
xil> [3_foo] i.

Runtime exception: Unknown symbol: '_foo'

xil> "3_foo" intern.

3_foo       <- top
```
* It is possible to change the semantics of the language in interesting ways by pushing nodes either to the stack or the queue. For example, the `ifte` operator can be implemented lazily by pushing part of its quotation on the stack instead of enqueuing. In essence the result on the stack will not be an actual result but an actual program that has to be evaluated by applying a combinator (such as `i` or `x`).

# external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)
* [The Concatenative Language XY](https://www.nsl.com/k/xy/xy.htm)