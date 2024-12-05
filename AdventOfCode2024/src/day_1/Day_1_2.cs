using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_1
{
    public static class Day_1_2
    {
        public static void Run()
        {
            IEnumerable<string> inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_1/input.txt");

            List<int> leftNumbers = [];
            List<int> rightNumbers = [];
            List<int> numList = [];

            foreach (string line in inputFileLines)
            {
                string[] numStrings = line.Split("   ");
                leftNumbers.Add(int.Parse(numStrings[0]));
                rightNumbers.Add(int.Parse(numStrings[1]));
            }

            leftNumbers.ForEach(leftNumber =>
            {
                int repeatCount = rightNumbers.FindAll(rightNumber => rightNumber == leftNumber).Count;
                numList.Add(leftNumber * repeatCount);
            });

            int numSum = numList.Sum();

            Console.Clear();
            Console.WriteLine(numSum);
        }
    }
}