using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class PuzzleHelper
    {
        public static string GetPuzzleTitle(string year, string day)
        {
            var title = string.Empty;
            var path = $"https://adventofcode.com/{year}/day/{day}";
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(path);
                title = doc.DocumentNode.SelectSingleNode("//article[@class='day-desc']/h2").InnerText;
                return title;
            }
            catch (Exception ex)
            {
                title = $"Error: unable to fetch [Title] from {path}";
                return title;
            }

        }
    }
}
