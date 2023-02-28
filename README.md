# xil
Xil is an implementation the [Joy](https://hypercubed.github.io/joy/joy.html) programming language. It is a dynamic, functional, concatenative language. It shares a few semantical concepts with [XY](https://nsl.com/k/xy/xy.htm) which in turn is also inspired by Joy. The implementation was inspired by [Thun](https://joypy.osdn.io/index.html).

In contrast to Joy, where built-ins are mostly implemented opaquely. Xil takes some inspiration of the XY programming language by formalizing a queue alongside the stack in its execution semantics. This allows for most combinators to be implemented in a *transparent* (continuation-passing style) fashion that makes it easy to observe the transformation steps that take place on the stack as well as the queue.

## overview
At a very basic level Xil is just a calculator. You push things to a **stack** memory, invoke an operation denoted by a *symbol* and it will replace zero or more values on the current stack with zero or more computed values. Unlike a basic calculator, Xil is also symbolic in that programs are just data. This means that a program is a list and a list is also a program. Xil is dynamic so it does not care what is on the stack up until the moment it actually tries to use these values for an operation. 

If the stack does not contain the right amount or right kinds of factors then it will complain. Xil is type-safe at runtime but will try to do some basic type inference when its convenient. 

### thruthymess
All values are *thruthy* in that they can be evaluated to `true` or `false`.
* `Boolean` values are interpreted as `true` or `false`.
* `Integer` values are `true` when they are non-zero.
* The same is true for `Float` values.
* `List` values are *thruthy* when they have more than zero elements.
* All other values are thruthy.

### basic math
All `Integer` nodes will readily convert to `Float` nodes via the `IFloatable` interface which also supplies the binary arithmetic for basic math such as `+`, `-`, `/`, `*`, etc. Xil will implicitly convert `Integer` to `Float` when they are combined in a single operation. However, when you have two `Integer` nodes on the stack and perform `/` operation you *will* get an `Integer` node back.

### ordinals
* All `Integer`, `Char` and `Bool` values support ordinal operations (such as `succ` and `pred`) via the `IOrdinal` interface. 

### aggregates
`List`, `String` and `Set` implement the `IAggregate` interface which means they support (amongst other) `first`, `rest`, `concat` and `cons` operations.

## stack and queue
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

In contrast to XY which offers a variety of operations to manipulate the queue directly, Xil only allows this in the context of some combinators. The `i` and `x` combinators in particular resemble the `/` (use) operation in XY and directly manipulate the queue by prepending the top of the stack as a quotation onto the queue to be executed.

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
There are various other combinators that take things on the stack, possibly reshuffle them, either push them onto the stack or onto the queue in various combinations. 

For example, the `infra` combinator is generally used to perform some stack preserving operation. You will often find this used with a `swaack` which will *swap-stack* (`X Y [U V] -> U V [X Y]`) the list on top of the stack (the preserved stack) as the current stack (see the `map` example in the "tracability" section).

We can also define things by associating a term to with a symbol. In the example below we are defining the `If` and `Else` (`true` and `false`) clauses for a `branch` combinator.
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

This uses the default Joy syntax for definitions (i.e. `A == B.`). These are handled in defintion mode and not evaluated, they are added to the interpreter environment as is (unevaluated factors). 

> In contrast to Joy, there is an additional way to create definitions in Xil using the `def` operator. This will pop a quotation and a symbol and define the symbol in the interpreter dynamically. There's some more info in the notes at the end.

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

## execution
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

Most of the combinators (higher order operations) are interpreted transparantely even though they are built-in. This means they will use the queue (as much as possible) and they will be traceable.

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

> The implementation of `map` (and the usage of `swaack` and `infra`) was directly inspired by [Thun](https://joypy.osdn.io/index.html). Even today it is somewhat magical to see it at work.

## goals
The main goal for this project is to keep the **Joy** programming language alive and relevant and to raise interest in stack based concatenative programming languages in general. 

This is meant to be embeddable in any .NET application. The main use case is embedding one or more interpreters to execute realitively simple programs in parallel or sequence or delayed by time (so that we can delay tasks on a queue of things to execute). 

Another possible scenario is to have a higher level language and transpile it to Joy/Xil. In fact, the original (somewhat ambitious) goal was to have an X intermediate language (where the name Xil comes from) that could serve as a general purpose, high level stack based IL for virtual machines.

## disclaimer
For now, this project is a toy and should not be used for production systems. It can be a useful playground to play with ideas though.

## random
This is just a section documenting some random but interesting aspects about the syntax and semantics of Xil.

### crazy identifier names
Joy and by deduction Xil both allow for some pretty crazy identifier names. Most things are a go. For example you can have identifiers like `,foo`, `*bar`, `$frotz`, `#.234*foo` etc. If there's a *printable* (a very oldschool definition) character in front that is not a number it's likely good to go. 
> The parser tries to respect this freedom but currently it does get confused by stuff like `123_foo` where it will parse an integer `123` and a symbol `_foo`.

### fooling the parser
As mentioned in the previous section, the parser chokes on symbols starting with a digit (i.e. `0..9`) but since the interpreter does not care it is possible to push symbols starting with an digit onto the stack using the `intern` operator.
```
xil> [3_foo] i.

Runtime exception: Unknown symbol: '_foo'

xil> "3_foo" intern.

3_foo       <- top
```

### fooling the parser twice
Using the `def` operator it is also possible to define runtime symbols that have an *illegal* name (at least according to the parser and grammar). This requires a threesome between the `intern`, `i` and `unit` operators.

Here's a somwehat convoluted example that defines a symbol `2+3` with a body of `[2 3 +]` and then evaluates this symbol leaving the result (of `5`) on the top of the stack.
```
xil> [["2+3" intern] i [3 2 +] def ["2+3" intern] i unit i] trace.

               . ["2+3" intern] i [3 2 +] def ["2+3" intern] i unit i
["2+3" intern] . i [3 2 +] def ["2+3" intern] i unit i
               . "2+3" intern [3 2 +] def ["2+3" intern] i unit i
         "2+3" . intern [3 2 +] def ["2+3" intern] i unit i
           2+3 . [3 2 +] def ["2+3" intern] i unit i
   2+3 [3 2 +] . def ["2+3" intern] i unit i
               . ["2+3" intern] i unit i
["2+3" intern] . i unit i
               . "2+3" intern unit i
         "2+3" . intern unit i
           2+3 . unit i
         [2+3] . i
               . 2+3
               . 3 2 +
             3 . 2 +
           3 2 . +
             5 .

5           <- top
```
* `intern` converts a string into a symbol for the interpreter (bypassing any parser rules).
* `i` evalues a quotation on the stack, prepending it onto the queue.
* `unit` wraps a value into a quotation (i.e. `x unit = [x]`).

It is not clear how useful this is in practice but it is kind of neat.

> I'm not sure if the `def` operator has an equivalent in Joy. As far as I know it does not. It is just another way to manipulate the three key aspects of the interpreter: the stack, the queue and the environment. It is already possible to manipulate the stack (and queue) so it should be equally possible to manipulate the environment from the program itself instead of activating it from the top-level.

### to stack or enqueue
It is possible to change the semantics of the language in interesting ways by pushing nodes either to the stack or the queue. For example, the `ifte` operator can be implemented lazily by pushing part of its quotation on the stack instead of enqueuing. In essence the result on the stack will not be an actual result but an lazy value (a program) that has to be evaluated by applying a combinator (such as `i` or `x`).

## operations
This will be a sort of reference but for now it is just some general notes on arithmetic and logical operations.

### arithmetic
These are supported by all types that implement the `IFloatable` interface. This interface will support other basic math operations such as `Sqrt`, `Sin`, `Pow` and such in the near future.

### logical
These are currently only supported on ordinals since they translate to an integer value. The equality comparison will be supported for aggregates in the future.

## external references
* [Joy](https://hypercubed.github.io/joy/joy.html)
* [The Theory of Concatenative Combinators](http://tunes.org/~iepos/joy.html)
* [Kitten](https://kittenlang.org/)
* [Joy on Hacker News](https://news.ycombinator.com/item?id=17685548)
* [Thun](http://joypy.osdn.io/index.html)
* [The Concatenative Language XY](https://www.nsl.com/k/xy/xy.htm)