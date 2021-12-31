namespace Day4_Giant_Squid
{
    public readonly record struct Game(IEnumerable<Board> Boards, IEnumerable<int> DrawnNumbers);
}
