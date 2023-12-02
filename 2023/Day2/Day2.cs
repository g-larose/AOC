using AOC;
using AOC_2023.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2023.Day2
{
    public class Day2 : Solution
    {
        public Day2() : base(2023, 2)
        {
            Solve(Input.ToLines());
        }

        public (string, string) Solve(IEnumerable<string> input)
        {
            var regex = new Regex(@"^Game (?<gameid>\d+): ((?<sets>[^;]*)(; )?)*$", RegexOptions.ExplicitCapture);
            var regex2 = new Regex(@"(\d+) (\w+)");

            var games = input
                .Select(l => regex.Match(l))
                .Select(m => new
                {
                    id = int.Parse(m.Groups["gameid"].Value),
                    sets = m.Groups["sets"]
                        .Captures
                        .Select(c => regex2.Matches(c.Value)
                            .OfType<Match>()
                            .Select(m => (num: int.Parse(m.Groups[1].Value), Color: m.Groups[2].Value))
                            .GroupBy(
                                x => x.Color,
                                (k, g) => (color: k, num: g.Sum(x => x.num)))
                            .ToDictionary(x => x.color, x => x.num))
                        .ToList(),
                })
                .ToList();

            var part1 = games
                .Where(g => g.sets.All(s =>
                    s.GetValueOrDefault("red") <= 12
                    && s.GetValueOrDefault("green") <= 13
                    && s.GetValueOrDefault("blue") <= 14))
                .Sum(g => g.id)
                .ToString();

            var part2 = games
                .Select(g => g.sets.Max(s => s.GetValueOrDefault("red", 1)) *
                    g.sets.Max(s => s.GetValueOrDefault("green", 1)) *
                    g.sets.Max(s => s.GetValueOrDefault("blue", 1)))
                .Sum()
                .ToString();

            return (part1, part2);
        }
    }
}
