using System.Text.RegularExpressions;
using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_5
{
    public static class Day_5_1
    {
        private static readonly string rulePattern = @"\b\d{2}\|\d{2}\b";
        private static readonly string instructionPattern = @"(\b\d{2},)+\d{2}\b$";

        public static void Run()
        {
            Console.Clear();
            string[] inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_5/input.txt").ToArray();

            Dictionary<int, List<int>> rulesAfterMap = [];
            Dictionary<int, List<int>> rulesBeforeMap = [];

            List<int[]> instructionsList = [];

            foreach (string line in inputFileLines)
            {
                if (Regex.IsMatch(line, rulePattern))
                {
                    int[] values = line.Split("|").Select(int.Parse).ToArray();
                    AddToDictionary(rulesBeforeMap, values[0], values[1]);
                    AddToDictionary(rulesAfterMap, values[1], values[0]);
                };
                if (Regex.IsMatch(line, instructionPattern)) instructionsList.Add(line.Split(",").Select(int.Parse).ToArray());
            }

            List<int[]> correctInstructions = [];

            foreach (int[] instruction in instructionsList)
            {
                if (IsCorrectInstruction(rulesAfterMap, rulesBeforeMap, instruction)) correctInstructions.Add(instruction);
            }

            int instructionSum = correctInstructions.Sum(instruction => instruction[instruction.Length / 2]);

            Console.WriteLine(instructionSum);
        }

        private static bool IsCorrectInstruction(Dictionary<int, List<int>> rulesAfterMap, Dictionary<int, List<int>> rulesBeforeMap, int[] instruction)
        {
            return Enumerable.Range(1, instruction.Length - 1).All(i =>
            {
                int currentValue = instruction[i - 1];
                int[] beforeValues = instruction.Take(i - 1).ToArray();
                int[] afterValues = instruction.Skip(i).ToArray();

                return IsRuleMet(rulesBeforeMap, currentValue, beforeValues) && IsRuleMet(rulesAfterMap, currentValue, afterValues);
            });
        }

        private static bool IsRuleMet(Dictionary<int, List<int>> rulesMap, int currentValue, int[] valuesToCheck)
        {
            if (!rulesMap.TryGetValue(currentValue, out var rule)) return true;
            return !valuesToCheck.Any(rule.Contains);
        }

        private static void AddToDictionary(Dictionary<int, List<int>> map, int key, int value)
        {
            if (!map.ContainsKey(key)) map[key] = [];
            map[key].Add(value);
        }
    }
}