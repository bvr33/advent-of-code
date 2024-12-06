namespace AdventOfCode2024.src.utils
{
    public static class Utils
    {
        public static char[,] Get2DCharArray(string[] inputFileLines)
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