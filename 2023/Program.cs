﻿using AOC;

namespace _2023;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WindowWidth = 160;
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
        Console.WriteLine(PuzzleHelper.GetPuzzleTitle("2019", "1")); //change the year when doing different years
        Console.ForegroundColor = ConsoleColor.Green;
    }
}
