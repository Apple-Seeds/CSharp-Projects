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
            if (!filename.Contains(".txt"))
                filename = filename + ".txt";

            // Processing
            try
            {
                // Text to List
                List<string> cryptList = new List<string>();
                string[] lineArray = System.IO.File.ReadAllLines(decision);
                for (int i = 0; i < lineArray.Length; i++)
                    for (int j = 0; j < lineArray[i].Length; j++)
                        cryptList.Add(TypeCheck(lineArray[i][j]));

                // Output
                File.WriteAllLines(filename, cryptList);
                Console.WriteLine("Encryption complete! File has been created.");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Sorry! " + e.Message);
            }
        }

        static string TypeCheck(char given)
        {
            int value = given;
            if (value >= 65 && value <= 90)
                return UpperCase(value);
            else if (value >= 97 && value <= 122)
                return LowerCase(value);
            else
                return SpecialCase(value);
        }

        static string UpperCase(int value)
        {
            return "^" + (value - 65); // 65 is the ASCII value of 'A', which has the lowest numerical value the encrypted character can have 
        }

        static string LowerCase(int value)
        {
            return "_" + (value - 97); // 97 is the ASCII value of 'a', which has the lowest numerical value the encrypted character can have 
        }

        static string SpecialCase(int value)
        {
            if (value >= 32 && value <= 64)
                return "+A" + (value - 32); // 32 is the ASCII value of ' ', which has the lowest numerical value the encrypted character can have 
            else if (value >= 91 && value <= 96)
                return "+B" + (value - 91); // 91 is the ASCII value of '[', which has the lowest numerical value the encrypted character can have 
            else if (value >= 123 && value <= 126)
                return "+C" + (value - 91); // 123 is the ASCII value of '{', which has the lowest numerical value the encrypted character can have
            else
                return "???";
        }
    }
}
