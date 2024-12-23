namespace Day15.Tests;

public class RobotMoverTests
{
    [Fact]
    public void Move_Part1_Example_1()
    {
        string[] input =
        [
            "########",
            "#..O.O.#",
            "##@.O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "<"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#..O.O.#",
            "##@.O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_2()
    {
        string[] input =
        [
            "########",
            "#..O.O.#",
            "##@.O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "^"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#.@O.O.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_3()
    {
        string[] input =
        [
            "########",
            "#.@O.O.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "^"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#.@O.O.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_4()
    {
        string[] input =
        [
            "########",
            "#.@O.O.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            ">"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#..@OO.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }
    
    [Fact]
    public void Move_Part1_Example_5()
    {
        string[] input =
        [
            "########",
            "#..@OO.#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            ">"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#...@OO#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_6()
    {
        string[] input =
        [
            "########",
            "#...@OO#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            ">"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#...@OO#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }
    
    
    [Fact]
    public void Move_Part1_Example_7()
    {
        string[] input =
        [
            "########",
            "#...@OO#",
            "##..O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "v"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#....OO#",
            "##..@..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#...O..#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_8()
    {
        string[] input =
        [
            "########",
            "#....OO#",
            "##..@..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#...O..#",
            "########",
            "",
            "v"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#....OO#",
            "##..@..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#...O..#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_9()
    {
        string[] input =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#...O..#",
            "#.#.O@.#",
            "#...O..#",
            "#...O..#",
            "########",
            "",
            "<"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#...O..#",
            "#.#O@..#",
            "#...O..#",
            "#...O..#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_10()
    {
        string[] input =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#...O..#",
            "#.#O@..#",
            "#...O..#",
            "#...O..#",
            "########",
            "",
            "<"
        ];
        
        string[] expectedResult =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#...O..#",
            "#.#O@..#",
            "#...O..#",
            "#...O..#",
            "########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_Smaller()
    {
        string[] input =
        [
            "########",
            "#..O.O.#",
            "##@.O..#",
            "#...O..#",
            "#.#.O..#",
            "#...O..#",
            "#......#",
            "########",
            "",
            "<^^>>>vv<v>>v<<"        
        ];
        
        string[] expectedResult =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#.....O#",
            "#.#O@..#",
            "#...O..#",
            "#...O..#",
            "########"
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }

    [Fact]
    public void Move_Part1_Example_Large()
    {
        string[] input =
        [
            "##########",
            "#..O..O.O#",
            "#......O.#",
            "#.OO..O.O#",
            "#..O@..O.#",
            "#O#..O...#",
            "#O..O..O.#",
            "#.OO.O.OO#",
            "#....O...#",
            "##########",
            "",
            "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^",
            "vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v",
            "><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<",
            "<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^",
            "^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><",
            "^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^",
            ">^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^",
            "<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>",
            "^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>",
            "v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^"
        ];
        
        string[] expectedResult =
        [
            "##########",
            "#.O.O.OOO#",
            "#........#",
            "#OO......#",
            "#OO@.....#",
            "#O#.....O#",
            "#O.....OO#",
            "#O.....OO#",
            "#OO....OO#",
            "##########",
        ];
        
        var (map, moves) = InputParser.Parse(input);
        var newMap = RobotMover.Move(map, moves);
        var printedNewMap = PrintMap(newMap);
        
        Assert.Equal(expectedResult, printedNewMap);
    }
    
    private static string[] PrintMap(char[][] map) => map.Select(t => new String(t)).ToArray();
}