namespace Day13;

public static class InputParser
{
    public static IEnumerable<MachineBehaviour> Parse(string[] lines)
    {
        var buttons = new List<Button>();
        
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            
            var parts = line.Split([' ',':',',','+','='], StringSplitOptions.RemoveEmptyEntries);
            switch (parts[0])
            {
                case "Button":
                {
                    var id = parts[1][0];
                    var dx = int.Parse(parts[3]);
                    var dy = int.Parse(parts[5]);
                    var cost = id == 'A' ? 3 : 1;
                
                    buttons.Add(new Button(id, new ButtonOffset(dx, dy), cost));
                    break;
                }
                case "Prize":
                {
                    var x = int.Parse(parts[2]);
                    var y = int.Parse(parts[4]);
                
                    yield return new MachineBehaviour(buttons, new Location(x, y));
                
                    buttons = [];
                    break;
                }
            }
        }
    }
}