using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_2
{
    public static class Day_2_2
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_2/input.txt");

            List<int[]> reportsList = inputFileLines.Select(line => line.Split(" ").Select(int.Parse).ToArray()).ToList();

            int safeReportsCount = reportsList.Count(IsSafeWithSingleBadSignal);

            Console.Clear();
            Console.WriteLine(safeReportsCount);
        }

        private static bool IsSafeReport(int[] report)
        {
            for (int i = 0; i < report.Length - 1; i++)
            {
                if (!IsCorrectDeference(report, i) || !IsUnidirectional(report, i)) return false;
            }
            return true;
        }

        private static bool IsSafeWithSingleBadSignal(int[] report)
        {
            if (IsSafeReport(report)) return true;

            for (int i = 0; i < report.Length; i++)
            {
                int[] modifiedRaport = report.Where((_, idx) => idx != i).ToArray();
                if (IsSafeReport(modifiedRaport)) return true;
            }
            return false;
        }

        private static bool IsUnidirectional(int[] report, int idx)
        {
            bool isIncreasing = report[0] < report[1];

            return isIncreasing
            ? report[idx] < report[idx + 1]
            : report[idx] > report[idx + 1];
        }

        private static bool IsCorrectDeference(int[] report, int idx)
        {
            int[] possibleDifferences = [1, 2, 3];
            int difference = (int)MathF.Abs(report[idx] - report[idx + 1]);
            return possibleDifferences.Contains(difference);
        }
    }
}