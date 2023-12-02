using AOC;
using AOC.Extensions;
using System.Text.RegularExpressions;

namespace _2023.Day1;

public class Day1 : Solution
{
    public Day1() : base(2023, 1)
    {
        PartOne();
        PartTwo();
    }

    public int PartOne()
    {
        var input = Input.SplitBy(Environment.NewLine);
        var regex = new Regex(@"^\d+$");
        var digits = new List<int>();
        List<string> numsBeforeSum = new();
        var result = 0;

        //TODO: this is bad. need to get this faster
        foreach (var item in input)
        {
            //TODO: this is also bad.
            foreach (var c in item)
            {
                if (char.IsDigit(c))
                {
                    var num = c.ToString();
                    numsBeforeSum.Add(num);
                }

            }

            var first = numsBeforeSum.First().ToString();
            var last = numsBeforeSum.Last().ToString();
            var newNum = first + last;
            if (first == last)
            {
                newNum = first + last;
            }

            var parsedNum = int.TryParse(newNum, out int n);
            digits.Add(n);
            result += digits.Sum();
            digits.Clear();
            numsBeforeSum.Clear();
        }

        // Console.WriteLine(result);
        return result;
    }

    public long PartTwo()
    {
        var lines = Input.ToLines();

        long sum = 0;
        foreach (var line in lines)
        {
            var numText = "";
            numText += Search(line, +1);
            numText += Search(line, -1);

            sum += int.Parse(numText);
        }
        return sum;
    }

    private static char Search(string line, int increment)
    {
        var start = increment > 0 ? 0 : line.Length - 1;
        var end = increment > 0 ? line.Length : -1;
        for (var i = start; i != end; i += increment)
        {
            if (line[i] >= '0' && line[i] <= '9')
                return line[i];
            var wordNum = TextToNumber(line[i..]);
            if (wordNum is not null) return (char)wordNum;
        }

        throw new Exception();
    }

    private static char? TextToNumber(string word)
    {
        if (word.StartsWith("one")) return '1';
        if (word.StartsWith("two")) return '2';
        if (word.StartsWith("three")) return '3';
        if (word.StartsWith("four")) return '4';
        if (word.StartsWith("five")) return '5';
        if (word.StartsWith("six")) return '6';
        if (word.StartsWith("seven")) return '7';
        if (word.StartsWith("eight")) return '8';
        if (word.StartsWith("nine")) return '9';
        return null;
    }
}
