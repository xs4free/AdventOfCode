namespace PointOfIncidence;

public static class MirrorFinder
{
    public static long SummarizeAllNotes(IEnumerable<string> lines, bool repairSmudge)
    {
        var notes = GetNotes(lines);

        return notes.Sum(note => NoteMirrorValue(note, repairSmudge));
    }

    private static long NoteMirrorValue(char[][] note, bool repairSmudge)
    {
        var columnsLeftOfReflection = GetColumnsLeftOfReflection(note, repairSmudge);
        if (columnsLeftOfReflection > 0)
        {
            return columnsLeftOfReflection;
        }

        var rowsAboveReflection = GetRowsAboveReflection(note, repairSmudge);
        if (rowsAboveReflection > 0)
        {
            return rowsAboveReflection * 100;
        }
        
        return 0;
    }

    private static long GetRowsAboveReflection(char[][] note, bool repairSmudge)
    {
        for (var y = 0; y < note.Length - 1; y++)
        {
            if (IsMirror(y, note, GetRow, repairSmudge))
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

    private static long GetColumnsLeftOfReflection(char[][] note, bool repairSmudge)
    {
        for (var x = 0; x < note[0].Length - 1; x++)
        {
            if (IsMirror(x, note, GetColumn, repairSmudge))
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

    private static bool IsMirror(
        int i, 
        char[][] note, 
        Func<char[][], int, IEnumerable<char>> getSequence,
        bool repairSmudge)
    {
        var smudgeFound = false;
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

            if (!IsMirror(currentSequence, nextSequence, repairSmudge))
            {
                return false;
            }

            if (repairSmudge && NumberOfDifferentElements(currentSequence, nextSequence) == 1)
            {
                repairSmudge = false;
                smudgeFound = true;
            }
        }

        return repairSmudge && smudgeFound || !repairSmudge; // 2 modes: (1) don't repair smudges => result = true, (2) repair smudges => result == smudgeFound
    }

    private static bool IsMirror(IEnumerable<char> sequence1, IEnumerable<char> sequence2, bool repairSmudges)
    {
        if (sequence1.SequenceEqual(sequence2))
        {
            return true;
        }

        return repairSmudges && NumberOfDifferentElements(sequence1, sequence2) == 1;
    }
    
    private static long NumberOfDifferentElements(IEnumerable<char> sequence1, IEnumerable<char> sequence2)
    {
        var seq1 = sequence1.ToList();
        var seq2 = sequence2.ToList();

        if (seq1.Count != seq2.Count)
        {
            throw new InvalidDataException("Sequences should contain same number of elements for this to work");
        }

        return seq1.Where((chr1, index) => chr1 != seq2[index]).Count();
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