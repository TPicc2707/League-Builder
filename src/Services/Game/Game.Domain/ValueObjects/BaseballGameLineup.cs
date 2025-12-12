namespace Game.Domain.ValueObjects;

public class BaseballGameLineup
{
    public Guid First { get; } = default!;
    public Guid Second { get; } = default!;
    public Guid Third { get; } = default!;
    public Guid Fourth { get; } = default!;
    public Guid Fifth { get; } = default!;
    public Guid Sixth { get; } = default!;
    public Guid Seventh { get; } = default!;
    public Guid Eighth { get; } = default!;
    public Guid Ninth { get; } = default!;
    public Guid StartingPitcher { get; } = default!;

    protected BaseballGameLineup()
    {
        
    }

    private BaseballGameLineup(
        Guid first,
        Guid second,
        Guid third,
        Guid fourth,
        Guid fifth,
        Guid sixth,
        Guid seventh,
        Guid eighth,
        Guid ninth,
        Guid startingPitcher)
    {
        First = first;
        Second = second;
        Third = third;
        Fourth = fourth;
        Fifth = fifth;
        Sixth = sixth;
        Seventh = seventh;
        Eighth = eighth;
        Ninth = ninth;
        StartingPitcher = startingPitcher;
    }

    public static BaseballGameLineup Of(
        Guid first,
        Guid second,
        Guid third,
        Guid fourth,
        Guid fifth,
        Guid sixth,
        Guid seventh,
        Guid eighth,
        Guid ninth,
        Guid startingPitcher)
    {
        return new BaseballGameLineup(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            seventh,
            eighth,
            ninth,
            startingPitcher);
    }
}
