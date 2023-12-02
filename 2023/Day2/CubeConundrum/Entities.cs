namespace CubeConundrum;

internal record Game(int Id, IEnumerable<CubesDraw> Draws);
internal record CubesDraw(int Blue = 0, int Red = 0, int Green = 0);

internal record BagContents(int Blue = 0, int Red = 0, int Green = 0)
{
    public int Power => Blue * Red * Green;
};

internal enum CubeColors { Blue, Red, Green };