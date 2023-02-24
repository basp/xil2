using System.Text;
using Antlr4.Runtime;
using Xil2;

const char dot = '.';
const string prompt = "xil> ";
const int pointerOffset = 12;

// The `CoreEx` interpreter is just a minimal test core that
// functions like a subset of the Joy programming language.
// The use-case is to allow for any interpreter to be used
// instead independent of the language syntax but coherent with
// the language semantics.
var interpreter = new CoreEx();

// This visitor is a shallow implementation of an ANTLR parse tree 
// visitor that will either deal with a definition or a term to be evaluated.
var visitor = new TracingCycleVisitor(interpreter);

// Read cycles (term or definition) of input until the user gets tired.
while (true)
{
    // Setup a string buffer to buildup our code in the interactive.
    var buf = new StringBuilder();

    // Display the prompt that starts a cycle.
    Console.Write(prompt);

    // Read multiline input until dot is found.
    while (true)
    {
        // Console.ReadLine will eat up the new line which
        // we need for the parser so we'll just add it back in.
        var input = Console.ReadLine() + Environment.NewLine;
        if (string.IsNullOrWhiteSpace(input))
        {
            // This is just a hack to ensure that
            // an empty string does not result in a
            // parse error.
            buf.Append(".");
            break;
        }

        buf.Append(input);

        // When we find a dot we have reached the end of our cycle.
        if (input.Trim().EndsWith(dot))
        {
            break;
        }

        // Since we are continuing a multiline prompt we'll shift over
        // to give some visual feedback in the interactive.
        Console.Write(string.Empty.PadRight(prompt.Length));
    }

    // At this point we have collected some input that (at least on the
    // surface) looks like some code we can parse and execute so let's try it.
    var stream = new AntlrInputStream(buf.ToString());
    var lexer = new XilLexer(stream);
    var tokens = new CommonTokenStream(lexer);
    var parser = new XilParser(tokens);

    try
    {
        // A cycle is either a term (to be evaluated immediately) or a
        // definition that should be stored in the interpreter environment.
        var ctx = parser.cycle();
        var stack = ctx.Accept(visitor);

        Console.WriteLine();

        // Top of stack (TOS) is at stack[stack.Count - 1] so we
        // loop backward in order to print it properly.
        for (var i = stack.Count - 1; i >= 0; i--)
        {
            // It's nice to have a visual que to draw
            // attention to where the top of the stack is.
            var pointer = "";
            if (i == stack.Count - 1)
            {
                pointer = "<- top";
            }

            // This will give us a representation of what
            // the code would look like for the value on
            // the stack.
            var repr = stack[i].ToRepresentation();

            // Put TOS pointer at `pointerOffset` unless the 
            // length of the representation exceeds this value. 
            // In that case we will just add one space to the
            // length of the representation for separation.
            var offset = Math.Max(repr.Length + 1, pointerOffset);

            // Print the stack value along with the TOS pointer
            // if this value happens to be at the top of the stack.
            // Otherwise the TOS pointer will still be printed
            // but it will be just an empty string.
            Console.WriteLine(
                string.Concat(repr.PadRight(offset), pointer));
        }

        if (stack.Count > 0)
        {
            // Print an empty line between the stack print and
            // the next prompt but only if there are any items on 
            // the stack.
            Console.WriteLine();
        }
    }
    catch (RuntimeException ex)
    {
        // These are generally thrown when stack validation
        // for a particular operation fails. They are usually
        // a result of user errors.
        Console.WriteLine($"Runtime exception: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        // These are thrown when the runtime attempts to
        // execute an operation with invalid operands. If this
        // exception is thrown it is usually the result of
        // insufficient stack validation or an bug in the 
        // interpreter.
        Console.WriteLine(ex.ToString());
    }
}
