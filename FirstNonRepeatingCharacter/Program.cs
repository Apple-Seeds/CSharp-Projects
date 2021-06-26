using System;
using System.Collections.Generic;

namespace FirstNonRepeatingCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            Console.Write("Enter a string: ");
            string entry = Console.ReadLine().ToLower();

            // Processing
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < entry.Length; i++)
            {
                if (!letters.ContainsKey(entry[i]))
                    letters.Add(entry[i], 1);
                else
                    letters[entry[i]]++;
            }

            // Output
            string answer = Output(letters);
            if (answer.Equals("404"))
                Console.WriteLine("There is no non-repeating character.");
            else
                Console.WriteLine("The first non-repeating character is: '" + answer + "'");

        }

        static string Output(Dictionary<char, int> let)
        {
            foreach (KeyValuePair<char, int> element in let)
                if (element.Value == 1)
                    return element.Key.ToString();
            return "404";
        }
    }
}
