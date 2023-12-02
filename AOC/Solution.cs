using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AOC
{
    public class Solution
    {
        public int Day { get; private set; }
        public int Year { get; private set; }
        public string Input { get; set; }


        public Solution(int year, int day)
        {
            Day = day;
            Year = year;
            Input = GetInput(Year, Day);
        }

        private static string GetSecretJson()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utils", "secret.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonSerializer.Deserialize<ConfigJson>(json);

            return configJson!.Secret!;
        }

        string GetInput(int year, int day)
        {
            string Baseurl = $"https://adventofcode.com/{year}/day";
            string InputSuffix = "input";
            string session = GetSecretJson();

        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Year.ToString(), $"Day{Day}"));
            string cachedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Year.ToString(), $"Day{day}", "input.txt");

            if (File.Exists(cachedFile)) return File.ReadAllText(cachedFile);
            else
            {
                string contents = "";
                Task.Run(async () =>
                 {
                     var wc = new HttpClient();
                     var request = new HttpRequestMessage(HttpMethod.Get, $"{Baseurl}/{day}/{InputSuffix}");
                     wc.DefaultRequestHeaders.Add("User-Agent", Uri.EscapeDataString("https://www.github.com/g-larose"));
                     wc.DefaultRequestHeaders.Add(nameof(HttpRequestHeader.Cookie), $"session={session}");
                     var response = await wc.SendAsync(request);
                     contents = await response.Content.ReadAsStringAsync();
                     File.WriteAllText(cachedFile, contents);
                 }).Wait();

                return contents;
            }
        }
    }
}
