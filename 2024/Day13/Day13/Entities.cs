namespace Day13;

public record ButtonOffset(long Dx, long Dy);
public record Button(char Id, ButtonOffset Offset, int TokenCost);
public record Location(long X, long Y);

public record MachineBehaviour(List<Button> Buttons, Location PrizeLocation);
