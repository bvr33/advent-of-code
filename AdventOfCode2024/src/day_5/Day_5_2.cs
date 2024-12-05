using System.Text.RegularExpressions;
using AdventOfCode2024.src.utils;

using RuleMap = System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>>;

namespace AdventOfCode2024.src.day_5
{
    public static class Day_5_2
    {
        private static readonly string rulePattern = @"\b\d{2}\|\d{2}\b";
        private static readonly string instructionPattern = @"(\b\d{2},)+\d{2}\b$";

        public static void Run()
        {
            string[] inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_5/input.txt").ToArray();

            RuleMap rulesAfterMap = [];
            RuleMap rulesBeforeMap = [];

            List<int[]> instructionsList = [];

            foreach (string line in inputFileLines)
            {
                if (Regex.IsMatch(line, rulePattern)) UpdateRules(rulesAfterMap, rulesBeforeMap, line);
                if (Regex.IsMatch(line, instructionPattern)) instructionsList.Add(line.Split(",").Select(int.Parse).ToArray());
            }

            List<int[]> correctedInstructions = instructionsList
                .Where(instruction => !IsCorrectInstruction(rulesAfterMap, rulesBeforeMap, instruction))
                .Select(instruction => GetCorrectInstruction(rulesAfterMap, rulesBeforeMap, instruction))
                .ToList();

            int instructionSum = correctedInstructions.Sum(instruction => instruction[instruction.Length / 2]);

            Console.WriteLine(instructionSum);
        }

        private static void UpdateRules(RuleMap rulesAfterMap, RuleMap rulesBeforeMap, string line)
        {
            int[] values = line.Split("|").Select(int.Parse).ToArray();
            AddToDictionary(rulesBeforeMap, values[0], values[1]);
            AddToDictionary(rulesAfterMap, values[1], values[0]);
        }

        private static int[] GetCorrectInstruction(RuleMap rulesAfterMap, RuleMap rulesBeforeMap, int[] instruction)
        {
            return [.. instruction.OrderBy(x => x, Comparer<int>.Create((x, y) =>
            {
                return CompareWithRules(rulesBeforeMap, x, y) ?? CompareWithRules(rulesAfterMap, x, y) ?? x.CompareTo(y);
            }))];
        }

        private static int? CompareWithRules(RuleMap rulesMap, int x, int y)
        {
            return IsRuleMet(rulesMap, y, [x])
            ? -1
            : IsRuleMet(rulesMap, x, [y]) ? 1 : null;
        }

        private static bool IsCorrectInstruction(RuleMap rulesAfterMap, RuleMap rulesBeforeMap, int[] instruction)
        {
            return Enumerable.Range(1, instruction.Length - 1).All(i =>
            {
                int currentValue = instruction[i - 1];
                int[] beforeValues = instruction.Take(i - 1).ToArray();
                int[] afterValues = instruction.Skip(i).ToArray();

                return IsRuleMet(rulesBeforeMap, currentValue, beforeValues) && IsRuleMet(rulesAfterMap, currentValue, afterValues);
            });
        }

        private static bool IsRuleMet(RuleMap rulesMap, int currentValue, int[] valuesToCheck)
        {
            if (!rulesMap.TryGetValue(currentValue, out var rule)) return true;
            return !valuesToCheck.Any(rule.Contains);
        }

        private static void AddToDictionary(RuleMap map, int key, int value)
        {
            if (!map.ContainsKey(key)) map[key] = [];
            map[key].Add(value);
        }
    }
}