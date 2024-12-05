using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_1
{
    public static class Day_1_1
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_1/input.txt");

            List<int> leftNumbers = [];
            List<int> rightNumbers = [];
            List<int> distancesList = [];

            foreach (string line in inputFileLines)
            {
                string[] numStrings = line.Split("   ");
                leftNumbers.Add(int.Parse(numStrings[0]));
                rightNumbers.Add(int.Parse(numStrings[1]));
            }

            leftNumbers.Sort();
            rightNumbers.Sort();

            foreach (var (value, idx) in leftNumbers.Select((value, idx) => (value, idx)))
            {
                distancesList.Add((int)MathF.Abs(value - rightNumbers[idx]));
            }

            int distance = distancesList.Sum();

            Console.Clear();
            Console.WriteLine(distance);
        }

    }
}