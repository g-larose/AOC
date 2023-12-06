using System.Text.RegularExpressions;
using AOC;
using AOC.Extensions;

namespace _2023.Day6;

public class Day6 : Solution
{
    public Day6() : base(2023, 6)
    {
        PartOne();
        PartTwo();
    }

    public int PartOne()
    {
        var input = Input.ToLines().ToArray();
        var times = input[0].Split(":")[1];
        var distances = input[1].Split(":")[1];
        var time = times.Split(" ", StringSplitOptions.RemoveEmptyEntries).AsInt32s();
        var distance = distances.Split(" ", StringSplitOptions.RemoveEmptyEntries).AsInt32s();

        var ans = 1;
        for (int i = 0; i < time.Count; i++)
        {
            var t = time[i];
            var d = distance[i];

            var nums = 0;
            for (int j = 0; j < t; j++)
            {
                var dist = (t - j) * j;
                if (dist > d)
                    nums++;
            }

            ans *= nums;
        }
        Console.WriteLine(ans);
        return ans;
    }

    public long PartTwo()
    {
        var input = Input.ToLines();
        var regex = new Regex(@"(\d+)");
        var times = regex.Matches(input[0]).Select(m => m.Value).ToArray();
        var distances = regex.Matches(input[1]).Select(m => m.Value).ToArray();
        long time = long.Parse(string.Join("", times));
        long distance = long.Parse(string.Join("", distances));
        var race = new Race(time, distance);
        var boat = new Boat();

        long ways = 0;
        for(long i = 0; i <= race.Time; i++)
        {
            boat.ChargeFor(i);
            (long timez, long traveled) = boat.Finish(race);
            if (traveled > race.Distance) ways++;
        }

        Console.WriteLine(ways);
        return ways;
    }
    
    public class Race
    {
        public long Time;
        public long Distance;
        public Race(long time, long distance)
        {
            Time = time;
            Distance = distance;
        }
    }
    
    public class Boat
    {
        long _startingSpeed;
        public void ChargeFor(long ms)
        {
            _startingSpeed = ms;
        }

        public (long time, long traveled) Finish(Race race)
        {
            long time = race.Time;
            long distance = race.Distance;

            time -= _startingSpeed;
            long traveledFor = time * _startingSpeed;

            return (time, traveledFor);
        }
    }
}