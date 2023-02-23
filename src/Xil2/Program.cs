using System.Text;
using Antlr4.Runtime;
using Xil2;

const char dot = '.';

var interpreter = new CycleVisitor(new CoreEx());

while (true)
{
    var buf = new StringBuilder();
    Console.Write(": ");

    // Read multiline input until dot is found.
    while (true)
    {
        // Console.ReadLine will eat up the new line which
        // we need for the parser so we'll just add it back in.
        var input = Console.ReadLine() + Environment.NewLine;
        if (string.IsNullOrWhiteSpace(input))
        {
            break;
        }

        buf.Append(input);

        // When we find a dot we have reached the end of our cycle.
        if (input.Trim().EndsWith(dot))
        {
            break;
        }

        // Since we continue a multiline prompt we'll shift over
        // the prompt two spaces so it aligns nicely with the starting
        // prompt. It also provides some visual feedback in the interactive.
        Console.Write("  ");
    }

    var stream = new AntlrInputStream(buf.ToString());
    var lexer = new JoyLexer(stream);
    var tokens = new CommonTokenStream(lexer);
    var parser = new JoyParser(tokens);

    try
    {
        var ctx = parser.cycle();
        var stack = ctx.Accept(interpreter);

        // Top of stack is at stack[stack.Count - 1] so we
        // need to loop backwards.
        for (var i = stack.Count - 1; i >= 0; i--)
        {
            var pointer = "";
            if (i == stack.Count - 1)
            {
                pointer = "<- top";
            }

            var repr = stack[i].ToRepresentation();

            // Put TOS pointer at column 16 unless the length
            // of the representation exceeds this value. In
            // that case we will just add one space to the
            // length of the representation.
            var offset = Math.Max(repr.Length + 1, 16);
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
