namespace AdventOfCode1.Solutions;

public class Day18
{
    private readonly List<string> _input;

    public Day18()
    {
        _input = File.ReadAllText("./Puzzle Inputs/Day18.txt").Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public long Solution1() => GetMagnitude(AddNumbers(_input));

    public long Solution2()
    {
        var maxMag = 0;
        for (var i = 0; i < _input.Count(); i++)
        {
            for (var j = 0; j < _input.Count(); j++)
            {
                if (i == j) continue;

                var currentSet = new List<string>() {_input[i], _input[j]};

                var mag = GetMagnitude(AddNumbers(currentSet));

                maxMag = Math.Max(maxMag, mag);
            }
        }

        return maxMag;
    }

    public static int GetMagnitude(List<Entry> input)
    {
        for (var depth = 4; depth > 0; depth--)
        {
            var entriesAtDepth = input.Where(e => e.Depth == depth).ToList();

            for (var i = 0; i < entriesAtDepth.Count; i += 2)
            {
                var magnitude = entriesAtDepth[i].Value * 3 + entriesAtDepth[i + 1].Value * 2;
                var index = input.IndexOf(entriesAtDepth[i]);
                input.RemoveAt(index + 1);
                input[index].Value = magnitude;
                input[index].Depth--;
            }
        }

        return input.Single().Value;  
    }

    public static List<Entry> AddNumbers(IEnumerable<string> input)
    {
        var numberList = input.Select(StringToEntries).ToList();

        var cumSum = numberList.First().ToList();

        foreach (var number in numberList.Skip(1))
        {
            cumSum.AddRange(number);
            cumSum.ForEach(cs => cs.Depth++);

            cumSum = ReduceNumber(cumSum).ToList();
        }

        return cumSum;
    }

    //Breaks if values over 10
    public static List<Entry> StringToEntries(string input)
    {
        var depth = 0;
        var entries = new List<Entry>();
        foreach (var t in input)
        {
            switch (t)
            {
                case ',':
                    continue;
                case '[':
                    depth++;
                    break;
                case ']':
                    depth--;
                    break;
                default:
                    entries.Add(new Entry { Depth = depth, Value = (int)char.GetNumericValue(t) });
                    break;
            }
        }
        return entries;
    }

    public static IEnumerable<Entry> ReduceNumber(List<Entry> number)
    {
        while (true)
        {
            var numberList = number.ToList();
            if (numberList.Any(n => n.Depth > 4))
            {
                number = ExplodeNumber(number);
                continue;
            }

            if (numberList.Any(n => n.Value > 9))
            {
                number = SplitNumber(number);
                continue;
            }

            return numberList;
        }
    }

    public static List<Entry> SplitNumber(List<Entry> number)
    {
        var splitter = number.First(n => n.Value > 9);
        var index = number.IndexOf(splitter);

        number.Insert(index + 1, new Entry
        {
            Depth = splitter.Depth + 1,
            Value = (int)Math.Ceiling((double)splitter.Value / 2)
        });
        number[index].Value = (int)Math.Floor((double)splitter.Value / 2);
        number[index].Depth++;

        return number;
    }

    public static List<Entry> ExplodeNumber(List<Entry> number)
    {
        var exploder = number.First(n => n.Depth > 4);
        var index = number.IndexOf(exploder);

        if (index > 0)
            number[index - 1].Value += exploder.Value;

        if (index < number.Count - 2)
            number[index + 2].Value += number[index + 1].Value;

        number[index].Value = 0;
        number[index].Depth--;
        number.RemoveAt(index + 1);

        return number;
    }

    public class Entry
    {
        public int Value;
        public int Depth;
    }
}
