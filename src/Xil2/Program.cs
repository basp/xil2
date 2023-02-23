using System.Text;
using Antlr4.Runtime;
using Xil2;

const char dot = '.';
const string prompt = ": ";

var interpreter = new CycleVisitor(new CoreEx());

while (true)
{
    var buf = new StringBuilder();
    Console.Write(prompt);

    // Read multiline input until dot is found.
    while (true)
    {
        // Console.ReadLine will eat up the new line which
        // we need for the parser so we'll just add it back in.
        var input = Console.ReadLine() + Environment.NewLine;
        if (string.IsNullOrWhiteSpace(input))
        {
            // This doesn't seem to work... 
            // Is it because of the new line that we add back in?
            break;
        }

        buf.Append(input);

        // When we find a dot we have reached the end of our cycle.
        if (input.Trim().EndsWith(dot))
        {
            break;
        }

        // Since we continue a multiline prompt we'll shift over
        // the prompt to give some visual feedback in the interactive.
        Console.Write(string.Empty.PadRight(prompt.Length));
    }

    // At this point we have collected some input that (at least on the
    // surface) looks like some code we can parse and execute so let's do it.
    var stream = new AntlrInputStream(buf.ToString());
    var lexer = new JoyLexer(stream);
    var tokens = new CommonTokenStream(lexer);
    var parser = new JoyParser(tokens);

    try
    {
        // A cycle is either a term (to be evaluated immediately) or a
        // definition that should be stored in the interpreter environment.
        var ctx = parser.cycle();
        var stack = ctx.Accept(interpreter);

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

            // Put TOS pointer at column 16 unless the length
            // of the representation exceeds this value. In
            // that case we will just add one space to the
            // length of the representation for separation.
            var offset = Math.Max(repr.Length + 1, 16);

            // Print the stack value along with the TOS pointer
            // if this value happens to be at the top of the stack.
            Console.WriteLine(
                string.Concat(repr.PadRight(offset), pointer));
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
