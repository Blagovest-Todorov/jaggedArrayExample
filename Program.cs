using System;
using System.Linq;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int countRows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[countRows][]; //initialize the rows of the jaggedArr

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] inputNums = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = new int[inputNums.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = inputNums[col];
                }
            }

            while (true)
            {
                string data = Console.ReadLine();

                if (data == "END")
                {
                    //TODO
                    break;
                }

                string[] dataCommands = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = dataCommands[0];

                int rowIdx = int.Parse(dataCommands[1]);
                int colIdx = int.Parse(dataCommands[2]);
                int value = int.Parse(dataCommands[3]);


                if (cmd == "Add")
                {
                    if (AreIdexesCorrect(rowIdx, colIdx, jagged) == false)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }  

                    jagged[rowIdx][colIdx] += value;
                }
                else if (cmd == "Subtract")
                {
                    if (AreIdexesCorrect(rowIdx, colIdx, jagged) == false)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    jagged[rowIdx][colIdx] -= value;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write( jagged[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreIdexesCorrect(int rowIdx, int colIdx, int[][]jagged)
        {
            if (rowIdx < 0 || rowIdx > jagged.Length - 1 ||
                         colIdx < 0 || colIdx > jagged[rowIdx].Length - 1)
            {
                //Console.WriteLine("Invalid coordinates");
                return false;
            }

            return true;
        }
    }
}
