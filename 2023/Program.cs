using _2023.Day1.Benchmark;
using _2023.Day2.Benchmark;
using _2023.Day4.Benchmark;
using _2023.Day6.Benchmark;
using AOC;
using BenchmarkDotNet.Running;

namespace _2023;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WindowWidth = 160;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        var title = @"

             =============================================================================================================================

            █████╗ ██████╗ ██╗   ██╗███████╗███╗   ██╗████████╗     ██████╗ ███████╗     ██████╗ ██████╗ ██████╗ ███████╗    ██████╗ ██████╗ 
           ██╔══██╗██╔══██╗██║   ██║██╔════╝████╗  ██║╚══██╔══╝    ██╔═══██╗██╔════╝    ██╔════╝██╔═══██╗██╔══██╗██╔════╝    ╚════██╗╚════██╗
           ███████║██║  ██║██║   ██║█████╗  ██╔██╗ ██║   ██║       ██║   ██║█████╗      ██║     ██║   ██║██║  ██║█████╗       █████╔╝ █████╔╝
           ██╔══██║██║  ██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║   ██║       ██║   ██║██╔══╝      ██║     ██║   ██║██║  ██║██╔══╝      ██╔═══╝  ╚═══██╗
           ██║  ██║██████╔╝ ╚████╔╝ ███████╗██║ ╚████║   ██║       ╚██████╔╝██║         ╚██████╗╚██████╔╝██████╔╝███████╗    ███████╗███████╗
           ╚═╝  ╚═╝╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═══╝   ╚═╝        ╚═════╝ ╚═╝          ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝    ╚══════╝╚══════╝ 

             =============================================================================================================================

";
        Console.Write(title);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(PuzzleHelper.GetPuzzleTitle("2023", "6"));
        Console.ForegroundColor = ConsoleColor.Green;

        //var day = new Day6.Day6();
       
        BenchmarkRunner.Run<Benchmark_Day6>();
    }
}
