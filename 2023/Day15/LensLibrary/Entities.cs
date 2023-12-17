namespace LensLibrary;

public class Box
{
    public int Number { get; init; }
    public List<Lens> Lenses { get; } = [];
}

public class Lens
{
    public string Label { get; init; }
    public int FocalLength { get; set; }
}