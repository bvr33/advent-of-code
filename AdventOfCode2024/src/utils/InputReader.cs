using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2024.src.utils
{
    public static class InputReader
    {
        public static IEnumerable<string> GetFileLinesRecursiveToSrcFolder(string srcResursiePath)
        {
            string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string inputPath = Path.GetFullPath($"{executablePath}/../../../src/{srcResursiePath}");

            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException("File Not Found");
            }

            IEnumerable<string> inputFileLines = File.ReadLines(inputPath);
            return inputFileLines;
        }
    }
}