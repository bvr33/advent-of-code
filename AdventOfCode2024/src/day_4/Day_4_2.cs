using AdventOfCode2024.src.utils;

namespace AdventOfCode2024.src.day_4
{
    public static class Day_4_2
    {
        private static readonly string searchedValue = "MAS";
        public static void Run()
        {
            string[] inputFileLines = InputReader.GetFileLinesRecursiveToSrcFolder("day_4/input.txt").ToArray();

            char[,] char2dArray = Get2DCharArray(inputFileLines);

            int soughtValueCount = 0;
            for (int i = 0; i < char2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < char2dArray.GetLength(1); j++)
                {
                    soughtValueCount += HasDiagonalsValue(char2dArray, i, j);
                }
            }

            Console.Clear();
            Console.WriteLine(soughtValueCount);
        }


        private static int HasDiagonalsValue(char[,] char2dArray, int i, int j)
        {
            if (i + 2 >= char2dArray.GetLength(0) || j + 2 >= char2dArray.GetLength(1)) return 0;

            string[] valuesToCheck = [
                $"{char2dArray[i, j]}{char2dArray[i+1 , j+1 ]}{char2dArray[i+2 , j+2]}",
                $"{char2dArray[i+2, j]}{char2dArray[i+1, j+1]}{char2dArray[i, j+2]}"
            ];

            if (IsSoughtValue(valuesToCheck[0]) && IsSoughtValue(valuesToCheck[1])) return 1;

            return 0;
        }

        private static bool IsSoughtValue(string valueToCheck)
        {
            string reversedSearchedValue = new(searchedValue.Reverse().ToArray());
            return searchedValue == valueToCheck || reversedSearchedValue == valueToCheck;
        }

        private static char[,] Get2DCharArray(string[] inputFileLines)
        {
            char[,] charArray = new char[inputFileLines.Length, inputFileLines[0].Length];

            for (int i = 0; i < inputFileLines.Length; i++)
            {
                for (int j = 0; j < inputFileLines[0].Length; j++)
                {
                    charArray[i, j] = inputFileLines[i][j];
                }
            }

            return charArray;
        }
    }
}