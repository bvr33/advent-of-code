using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_4
{
    public static class Day_4_1
    {
        private static readonly string searchedValue = "XMAS";
        public static void Run()
        {
            string[] inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_4/input.txt").ToArray();

            char[,] char2dArray = Utils.Get2DCharArray(inputFileLines);

            int soughtValueCount = 0;
            for (int i = 0; i < char2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < char2dArray.GetLength(1); j++)
                {
                    soughtValueCount += HasHorizontalValue(char2dArray, i, j) + HasVerticalValue(char2dArray, i, j) + HasDiagonalsValue(char2dArray, i, j);
                }
            }

            Console.Clear();
            Console.WriteLine(soughtValueCount);
        }

        private static int HasHorizontalValue(char[,] char2dArray, int i, int j)
        {
            if (i + 3 >= char2dArray.GetLength(0)) return 0;

            string valueToCheck = $"{char2dArray[i, j]}{char2dArray[i + 1, j]}{char2dArray[i + 2, j]}{char2dArray[i + 3, j]}";
            if (IsSoughtValue(valueToCheck)) return 1;

            return 0;
        }

        private static int HasVerticalValue(char[,] char2dArray, int i, int j)
        {
            if (j + 3 >= char2dArray.GetLength(1)) return 0;

            string valueToCheck = $"{char2dArray[i, j]}{char2dArray[i, j + 1]}{char2dArray[i, j + 2]}{char2dArray[i, j + 3]}";
            if (IsSoughtValue(valueToCheck)) return 1;

            return 0;
        }

        private static int HasDiagonalsValue(char[,] char2dArray, int i, int j)
        {
            if (i + 3 >= char2dArray.GetLength(0) || j + 3 >= char2dArray.GetLength(1)) return 0;

            string[] valuesToCheck = [
                $"{char2dArray[i, j]}{char2dArray[i + 1, j + 1]}{char2dArray[i + 2, j + 2]}{char2dArray[i + 3, j + 3]}",
                $"{char2dArray[i+3, j]}{char2dArray[i+2,j+1]}{char2dArray[i+1,j+2]}{char2dArray[i,j+3]}"
            ];

            int valueCount = 0;
            foreach (string value in valuesToCheck)
            {
                if (IsSoughtValue(value)) valueCount++;
            }

            return valueCount;
        }

        private static bool IsSoughtValue(string valueToCheck)
        {
            string reversedSearchedValue = new(searchedValue.Reverse().ToArray());
            return searchedValue == valueToCheck || reversedSearchedValue == valueToCheck;
        }

    }
}