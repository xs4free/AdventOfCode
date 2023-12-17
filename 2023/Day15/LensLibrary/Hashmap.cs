namespace LensLibrary;

public static class Hashmap
{
    public static int FocussingPower(string input)
    {
        var steps = input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var boxes = FillBoxes(steps);

        return boxes.Values.SelectMany(box => box.Lenses.Select((lens,index) => CalculateLensFocussingPower(lens,index + 1,box))).Sum();
    }

    private static int CalculateLensFocussingPower(Lens lens, int slot, Box box)
    {
        return (box.Number + 1) * slot * lens.FocalLength;
    }

    private static Dictionary<int, Box> FillBoxes(string[] steps)
    {
        Dictionary<int, Box> boxes = [];
        
        foreach (var step in steps)
        {
            var split = step.Split('-', '=');
            var label = split[0];
            var operation = step.Contains('-') ? "-" : "=";
            var focalLength = split.Length >= 2 ? split[1] : string.Empty;

            var hash = Hash.Compute(label);

            if (!boxes.TryGetValue(hash, out var box))
            {
                box = new Box { Number = hash };
                boxes.Add(hash, box);
            }

            PerformOperation(operation, box, label, focalLength);
        }

        return boxes;
    }

    private static void PerformOperation(string operation, Box box, string label, string focalLengthText)
    {
        switch (operation)
        {
            case "-":
            {
                var index = box.Lenses.FindIndex(lens => lens.Label == label);
                if (index > -1)
                {
                    box.Lenses.RemoveAt(index);
                }

                break;
            }
            case "=":
            {
                var focalLength = int.Parse(focalLengthText);
                var index = box.Lenses.FindIndex(lens => lens.Label == label);
                if (index > -1)
                {
                    box.Lenses[index].FocalLength = focalLength;
                }
                else
                {
                    box.Lenses.Add(new Lens { FocalLength = focalLength, Label = label });
                }

                break;
            }
        }
    }
}