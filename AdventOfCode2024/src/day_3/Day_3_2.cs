using System.Text.RegularExpressions;
using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_3
{
    public static class Day_3_2
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_3/input.txt");

            string corruptedMemory = string.Join("", inputFileLines);

            string[] patterns = [
                @"mul\((\d{1,3}),(\d{1,3})\)",
                @"don't\(\)",
                @"do\(\)"
            ];
            string pattern = string.Join("|", patterns);

            int mulSum = 0;

            bool flag = true;
            foreach (Match instruction in Regex.Matches(corruptedMemory, pattern))
            {
                string instructionValue = instruction.Value;
                if (instructionValue.Contains("do()")) flag = true;
                if (instructionValue.Contains("don't()")) flag = false;

                if (flag && instructionValue.Contains("mul(")) mulSum += MultipleValues(instruction);
            }

            Console.Clear();
            Console.WriteLine(mulSum);
        }

        private static int MultipleValues(Match instruction)
        {
            int[] values = instruction.Value.Replace("mul(", "").Replace(")", "").Split(",").Select(int.Parse).ToArray();
            return values[0] * values[1];
        }
    }
}