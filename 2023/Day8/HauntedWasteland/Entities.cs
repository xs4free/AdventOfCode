namespace HauntedWasteland;

public record Map(string Instructions, Node FirstNode);

public record Node(string Name, string LeftId, string RightId, Node? Left, Node? Right)
{
    public Node? Left { get; set; } = Left;
    public Node? Right { get; set; } = Right;
}
