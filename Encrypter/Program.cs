using System;
using System.Collections.Generic;
using System.IO;

namespace Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Input
            Console.Write("Enter a valid .txt file: ");
            string decision = Console.ReadLine();
            Console.Write("Enter a name for the output .txt file: ");
            string filename = Console.ReadLine();
            using StreamWriter file = new(filename, append: true);

            // Text to List
            List<int> ASCIIList = new List<int>();
            string[] lineArray = System.IO.File.ReadAllLines(decision);
            for (int i = 0; i < lineArray.Length; i++)
                for (int j = 0; j < lineArray[i].Length; j++)
                    ASCIIList.Add(lineArray[i][j]);

            // Output
            for (int i = 0; i < ASCIIList.Count; i++)
                await file.WriteAsync(TypeCheck(ASCIIList[i]));
        }
    }
}
