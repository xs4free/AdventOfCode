namespace Day13;

public record ButtonOffset(int Dx, int Dy);
public record Button(char Id, ButtonOffset Offset, int TokenCost);
public record Location(int X, int Y);

public record MachineBehaviour(List<Button> Buttons, Location PrizeLocation);
