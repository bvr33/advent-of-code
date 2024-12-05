using System;
using System.Linq;
using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_2
{
    public static class Day_2_1
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_2/input.txt");

            List<int[]> reportsList = inputFileLines.Select(line => line.Split(" ").Select(int.Parse).ToArray()).ToList();

            int safeReportsCount = 0;

            reportsList.ForEach(report =>
            {
                if (IsValidReport(report)) safeReportsCount++;
            });

            Console.Clear();
            Console.WriteLine(safeReportsCount);
        }

        private static bool IsValidReport(int[] report)
        {
            if (report.Length != new HashSet<int>(report).Count) return false;

            for (int i = 0; i < report.Length - 1; i++)
            {
                if (!IsCorrectDeference(report, i) || !IsUnidirectional(report, i)) return false;
            }
            return true;
        }

        private static bool IsUnidirectional(int[] report, int idx)
        {
            bool isIncreasing = report[1] > report[0];
            return isIncreasing && report[idx] < report[idx + 1] || !isIncreasing && report[idx] > report[idx + 1];
        }

        private static bool IsCorrectDeference(int[] report, int idx)
        {
            int[] differences = [1, 2, 3];
            int difference = (int)MathF.Abs(report[idx] - report[idx + 1]);
            return differences.Contains(difference);
        }
    }
}