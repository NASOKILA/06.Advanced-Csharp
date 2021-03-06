﻿using System;
using System.Linq;

namespace _06.Targer_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimantions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int rows = dimantions[0];
            int cols = dimantions[1];

            string snake = Console.ReadLine();

            int[] shot = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            char[,] matrix = fillMatrix(snake, rows, cols);

            matrix = FireShot(shot, matrix);
            matrix = Gravity(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write(matrix[row, col]);

                Console.WriteLine();
            }
        }

        private static char[,] Gravity(char[,] matrix)
        {         
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int emptyRows = 0;
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyRows++;
                    }
                    else if (emptyRows > 0) {
                        
                        matrix[row + emptyRows, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }   
            return matrix;
        }

        private static char[,] FireShot(int[] shot, char[,] matrix)
        {
            int row = shot[0];
            int column = shot[1];
            int radius = shot[2];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    int a = row - r;
                    int b = column - c;
                    double distance = Math.Sqrt(a * a + b * b);

                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }

            return matrix;
        }

        private static char[,] fillMatrix(string snake, int rows, int cols)
        {
            var matrix = new char[rows, cols];

            bool isGoingLeft = true;

            int snakeIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                int index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;

                int increment = isGoingLeft ? -1 : 1;
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, index] = snake[snakeIndex++];
                    
                    if (snakeIndex >= snake.Length)
                        snakeIndex = 0;

                    index += increment;
                }

                isGoingLeft = !isGoingLeft;
            }

            return matrix;
        }
    }
}
