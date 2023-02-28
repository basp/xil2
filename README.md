# xil
Xil is an implementation of the Joy programming language. It is a dynamic, functional, concatenative language. It only knows values and operations. It is a subset of Joy and shares some semantical concepts with XY. The implementation was inspired by Thun.

In contrast to Joy, which builtins are mostly implemented opaquely. Xil takes some inspiration of the XY programming language by somewhat formalizing a queue alongside the stack. This makes it straightforward to define a lot of operations in a continuation-passing style (CPS).

In contrast to XY which allows programmers to also manipulate the queue directly, Xil does not really allow this. The queue can be implicitly manipulated by interpreting operations but it is not really possible to manipulate it directly as is possible with the stack. 

The `i` combinator in particular resembles the `->` operation in XY and it and its family of interpreting operators (such as the conditional and mapping combinators) do allow some queue manipulation within the semantics of the Joy language.

For example:
``
xil> [[3 2 +] i] trace.

        . [3 2 +] i
[3 2 +] . i
        . 3 2 +
      3 . 2 +
    3 2 . +
      5 .

5           <- top``

In contrast to Thun this was meant to be embeddable in any .NET application. As such the interface has to be a little bit more static as well. Another key difference is that we support definitions in the Joy language itself so you can just start up the interactive and do the following:
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

> A caveat to all of this is that we do not support the module semantics as defined in the Joy papers (i.e. the `LIBRA`, `HIDE`, `IN`, `DEFINE` stuff). The module system is not super great and while the interpreter is still not complete it does not make much sense to have a module system in the first place. There will be definitely some kind of way to read in a list of definitions order to setup the interpreter environment in the near future but a fully fledged module system will have to wait until later.

When the interpreter starts, the parsed term (list of factors) is the queue. Every cycle a factor is dequeued and interpreted:

* If it is a symbol we attempt a lookup in the interpreter environment.
    * If this fails we throw a `RuntimeException`.
    * If this succeeds we check wheter this is a builtin symbol.
        * If this is a builtin then we just execute the associated action which is defined in C# code.
        * If this symbol was defined at runtime (as a Joy definition) we
        will prepend its body of factors to the queue to be executed.
* If the factor is not a symbol we will push the node (i.e. its literal value) onto the stack.

# tracability
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

The `swaack`'s  swap the stack with the list on top of the stack. They are not important for this example. The main point here is that the `map` operator is implemented transparently in that it unfolds into ever more primitive operations at the beginning of the queue instead of recursing on the stack. It ends with a final `swaack` and since this operation has to operate on the stack directly it is implemented as a primitive and thus opaque to the tracer. You can see how it saves the current stack in the queue by enqueing `["bar" "foo"]` before the final `swaack`. In this way the original stack will be restored before `swaack` is interpreted.

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