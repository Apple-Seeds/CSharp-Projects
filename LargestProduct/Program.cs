using System;
using System.Collections.Generic;

// This problem came from: https://projecteuler.net/problem=8
namespace LargestProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            // User Input
            Console.Write("Enter a valid .txt file: ");
            string decision = Console.ReadLine();

            // Digit Parsing
            List<int> digitList = new List<int>();
            string[] lineArray = System.IO.File.ReadAllLines(decision);
            List<char[]> charList = new List<char[]>();
            for (int i = 0; i < lineArray.Length; i++)
            {
                charList.Add(lineArray[i].ToCharArray());
                for (int j = 0; j < charList[i].Length; j++)
                    digitList.Add(int.Parse(charList[i][j].ToString()));
            }

            // Product Solving
            long fourProduct = ParseProduct(digitList, 4);
            long thirteenProduct = ParseProduct(digitList, 13);

            // Output
            Console.WriteLine("The greatest product of four adjacent digits is: " + fourProduct);
            Console.WriteLine("The greatest product of thirteen adjacent digits is: " + thirteenProduct);
        }

        static long ParseProduct(List<int> list, int counter)
        {
            long placeholder = 0;
            long product = 0;
            for (int i = 0; i < list.Count - counter; i++)
            {
                placeholder = list[i];
                for (int j = 1; j < counter; j++)
                    placeholder *= list[j + i];
                if (placeholder > product)
                    product = placeholder;
            }
            return product;
        }
    }
}
