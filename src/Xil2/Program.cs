using Antlr4.Runtime;

var visitor = new JoyCycleVisitor();

while (true)
{
    Console.Write(": ");
    var src = Console.ReadLine();
    var input = new AntlrInputStream(src);
    var lexer = new JoyLexer(input);
    var tokens = new CommonTokenStream(lexer);
    var parser = new JoyParser(tokens);

    try
    {
        var ctx = parser.cycle();
        var stack = ctx.Accept(visitor);
        foreach (var x in stack)
        {
            Console.WriteLine(x.ToRepresentation());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
