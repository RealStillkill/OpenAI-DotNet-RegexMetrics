using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RegexMeasure;

internal class Program
{

	static void Main(string[] args)
	{
		string[] timestampStrings = GenerateTimestampStrings(100000);
		List<long> times = new List<long>();

		Regex tsRegex = new Regex(@"^(?<hour>\d+h)?(?<mins>\d+m(?!s))?(?<secs>\d+s)?(?<ms>\d+ms)?");

		for (int i = 0; i < timestampStrings.Length; i++)
		{
			Stopwatch sw = Stopwatch.StartNew();
			Match match = tsRegex.Match(timestampStrings[i]);
			sw.Stop();
			times.Add(sw.ElapsedMilliseconds);
			//Console.WriteLine($"{i + 1}/{timestampStrings.Length} - {timestampStrings[i]}");
		}

		Console.WriteLine("\n\n\n");
		Console.WriteLine($"Average performance: {times.Average().ToString()}ms");
		Console.WriteLine($"Best case: {times.Min()}ms");
		Console.WriteLine($"Worst Case: {times.Max()}ms");
		Console.WriteLine($"Total Time: {times.Sum()}ms");
	}

	static string[] GenerateTimestampStrings(int count)
	{
		string[] timestampStrings = new string[count];


		Random rng = new Random();
		for (int i = 0; i < timestampStrings.Length; i++)
		{
			int hours = rng.Next(0, 999);
			int min = rng.Next(0, 60);
			int sec = rng.Next(0, 60);
			int ms = rng.Next(0, 1000);
			timestampStrings[i] = $"{hours}h{min}m{sec}s{ms}ms";
		}
		return timestampStrings;
	}
}
