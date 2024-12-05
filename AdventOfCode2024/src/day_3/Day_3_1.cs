using System.Text.RegularExpressions;
using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_3
{
    public static class Day_3_1
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_3/input.txt");

            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            string corruptedMemory = string.Join("", inputFileLines);

            MatchCollection uncorruptedInstructionMatches = Regex.Matches(corruptedMemory, pattern);

            int mulSum = 0;
            foreach (Match instruction in uncorruptedInstructionMatches)
            {
                int[] values = instruction.Value.Replace("mul(", "").Replace(")", "").Split(",").Select(int.Parse).ToArray();
                mulSum += values[0] * values[1];
            }

            Console.Clear();
            Console.WriteLine(mulSum);
        }
    }
}