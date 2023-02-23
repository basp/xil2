using System.Text;
using Antlr4.Runtime;
using Xil2;

const char dot = '.';

var interpreter = new CycleVisitor();

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
            buf.Append(dot);
            break;
        }

        // Since we continue a multiline prompt we'll shift over
        // two spaces so it aligns nicely with the starting 
        // prompt.
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

        for (var i = stack.Count - 1; i >= 0; i--)
        {
            var pointer = "";
            if (i == stack.Count - 1)
            {
                pointer = "<- top";
            }
            // else if (i == 0)
            // {
            //     pointer = "<- bottom";
            // }

            var repr = stack[i].ToRepresentation();
            var offset = Math.Max(repr.Length + 1, 16);
            Console.WriteLine(string.Concat(
                repr.PadRight(offset),
                pointer));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
