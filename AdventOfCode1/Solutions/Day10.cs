namespace AdventOfCode1.Solutions
{
    public class Day10
    {
        private readonly IEnumerable<string> _parsedInput;

        public Day10()
        {
            _parsedInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day10.txt"));
        }

        public int Solution1() => GetSyntaxScore(_parsedInput);
        public long Solution2() => GetCompletionScore(_parsedInput);

        public static IEnumerable<string> ParseInput(string inputString) => inputString
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        public static int GetSyntaxScore(IEnumerable<string> input)
        {
            var illegals = input.Select(GetFirstIllegal)
                .Where(c => c != '0')
                .ToList();

            var scores = illegals.Select(c =>
            {
                return c switch
                {
                    ')' => 3,
                    ']' => 57,
                    '}' => 1197,
                    '>' => 25137,
                    _ => throw new ArgumentException("Invalid Illegal Character")
                };
            });

            return scores.Sum();
        }

        public static long GetCompletionScore(IEnumerable<string> input)
        {
            var completionChars = DiscardInvalid(input)
                .Select(GetUnclosedParens)
                .Select(GetCompletionChars);

            var scores = completionChars.Select(line =>
                {
                    var lineList = line.ToList();
                    long score = 0;
                    for (var i = 0; i < lineList.Count(); i++)
                    {
                        score = score * 5 + lineList[i] switch
                        {
                            ')' => 1,
                            ']' => 2,
                            '}' => 3,
                            '>' => 4,
                            _ => throw new ArgumentException("Invalid Illegal Character")
                        };
                    }

                    return score;
                }
            ).ToList();

            scores.Sort();

            return scores[scores.Count / 2];
        }

        public static IEnumerable<string> DiscardInvalid(IEnumerable<string> input) => input.Where(c => GetFirstIllegal(c) == '0');

        public static IEnumerable<char> GetUnclosedParens(string input)
        {
            var parens = new List<char>() { input[0] };

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] is '{' or '[' or '(' or '<')
                    parens.Add(input[i]);
                else if (IsCorrectClosingBracket(parens.Last(), input[i]))
                    parens.RemoveAt(parens.Count - 1);
                else
                    throw new ArgumentException("InvalidInput");
            }

            return parens;
        }

        public static char GetFirstIllegal(string input)
        {
            var parens = new List<char>() { input[0] };

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] is '{' or '[' or '(' or '<')
                    parens.Add(input[i]);
                else if (IsCorrectClosingBracket(parens.Last(), input[i]))
                    parens.RemoveAt(parens.Count - 1);
                else return input[i];
            }

            return '0';
        }

        public static bool IsCorrectClosingBracket(char opening, char closing)
        {
            var openingInt = (int)opening;
            var closingInt = (int)closing;
            return openingInt == closingInt - 1 || openingInt == closingInt - 2;
        }

        public static IEnumerable<char> GetCompletionChars(IEnumerable<char> input) =>
            input.Reverse().Select(c =>
                {
                    return c switch
                    {
                        '(' => ')',
                        '[' => ']',
                        '{' => '}',
                        '<' => '>',
                        _ => throw new ArgumentException("Invalid Bracket")
                    };
                }
            );
    }
}