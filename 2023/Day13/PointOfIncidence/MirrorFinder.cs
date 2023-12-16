namespace PointOfIncidence;

public static class MirrorFinder
{
    public static long SummarizeAllNotes(IEnumerable<string> lines)
    {
        var notes = GetNotes(lines);

        return notes.Sum(note => GetColumnsLeftOfReflection(note) + (GetRowsAboveReflection(note) * 100));
    }

    private static long GetRowsAboveReflection(char[][] note)
    {
        for (var y = 0; y < note.Length - 1; y++)
        {
            if (IsMirror(y, note, GetRow))
            {
                return y + 1;
            }
        }

        return 0;
    }

    private static char[] GetRow(char[][] note, int y)
    {
        return y < note.Length ? note[y] : [];
    }

    private static long GetColumnsLeftOfReflection(char[][] note)
    {
        for (var x = 0; x < note[0].Length - 1; x++)
        {
            if (IsMirror(x, note, GetColumn))
            {
                return x + 1;
            }
        }

        return 0;
    }
    
    private static IEnumerable<char> GetColumn(char[][] note, int x)
    {
        return x < note[0].Length ? note.Select(line => line[x]) : [];
    }

    private static bool IsMirror(int i, char[][] note, Func<char[][], int, IEnumerable<char>> getSequence)
    {
        for (var index = i; index >= 0; index--)
        {
            var distanceFromMirrorLine = i - index + 1;
            var nextIndex = i + distanceFromMirrorLine;

            var currentSequence = getSequence(note, index);
            var nextSequence = getSequence(note, nextIndex);
            
            if (!nextSequence.Any())
            {
                // end of note, nothing to compare with
                break;
            }

            if (!IsMirror(currentSequence, nextSequence))
            {
                return false;
            }
        }

        return true;
    }


    private static bool IsMirror(IEnumerable<char> sequence1, IEnumerable<char> sequence2)
    {
        return sequence1.SequenceEqual(sequence2);
    }

    private static IEnumerable<char[][]> GetNotes(IEnumerable<string> lines)
    {
        List<List<string>> notes = [];
        List<string> currentNote = new();
        
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                notes.Add(currentNote);
                currentNote = new List<string>();
            }
            else
            {
                currentNote.Add(line);
            }
        }
        notes.Add(currentNote);

        return notes.Select(note => note.Select(line => line.ToCharArray()).ToArray()).ToList();
    }
}