namespace Xil2;

public static class Validators
{
    public static readonly Validator SwapValidator =
        new Validator("swap")
            .TwoArguments();

    public static readonly Validator ConsValidator =
        new Validator("cons")
            .TwoArguments()
            .ListOnTop();

    public static readonly Validator BranchValidator =
        new Validator("branch")
            .ThreeArguments()
            .TwoQuotes();

    public static readonly Validator ChoiceValidator =
        new Validator("choice")
            .ThreeArguments();

    public static readonly Validator IfteValidator =
        new Validator("ifte")
            .ThreeArguments()
            .ThreeQuotes();

    public static readonly Validator DipValidator =
        new Validator("dip")
            .TwoArguments()
            .OneQuote();

    public static readonly Validator ConcatValidator =
        new Validator("concat")
            .TwoArguments()
            .TwoQuotes();

    public static readonly Validator PopValidator =
        new Validator("pop")
            .OneArgument();


    public static readonly Validator FirstValidator =
        new Validator("first")
            .OneArgument()
            .AggregateOnTop();

    public static readonly Validator RestValidator =
        new Validator("rest")
            .OneArgument()
            .NonEmptyAggregateOnTop<IAggregate>();

    public static readonly Validator DupValidator =
        new Validator("dup")
            .OneArgument();

    public static readonly Validator _XValidator =
        new Validator("x")
            .OneArgument()
            .OneQuote();

    public static readonly Validator _IValidator =
        new Validator("i")
            .OneArgument()
            .OneQuote();


    public static readonly Validator SwaackValidator =
        new Validator("swaack")
            .OneArgument()
            .ListOnTop();

    public static readonly Validator InfraValidator =
        new Validator("infra")
            .TwoArguments()
            .TwoQuotes();

    public static readonly Validator MapValidator =
        new Validator("map")
            .TwoArguments()
            .OneQuote()
            .ListAsSecond();

    public static readonly Validator TraceValidator =
        new Validator("trace")
            .OneArgument()
            .OneQuote();
}
