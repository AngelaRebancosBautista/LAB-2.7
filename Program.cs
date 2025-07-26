using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixDiagonalDifference
{
    static void Main()
    {
        int n;

        while (true)
        {
            Console.Write("Enter the size of square matrix: ");
            n = int.Parse(Console.ReadLine());

            if(n >= 3)
                break;
            else
                Console.WriteLine("Invalid input.");
        }

        int[,] matrix = new int[n, n];

        Console.WriteLine($"Enter the elements of the {n}x{n} matrix (row by row):");

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Row {i + 1} : ");
                string[] rowInput = Console.ReadLine().Split();

                if (rowInput.Length == n && Array.TrueForAll(rowInput, s => int.TryParse(s, out _)))
                {
                    for (int j = 0; j < n; j++)
                        matrix[i, j] = int.Parse(rowInput[j]);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid row.");
                }
            }
        }

        int primaryDiagonalSum = 0;
        int secondaryDiagonalSum = 0;

        for (int i = 0; i < n; i++)
        {
            primaryDiagonalSum += matrix[i, i];
            secondaryDiagonalSum += matrix[i, n - i - 1];
        }

        int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
        Console.WriteLine($"\nDiagonal Difference: {difference}");
    }
}
