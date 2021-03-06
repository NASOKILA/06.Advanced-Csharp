﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pompInfo = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pompInfo);
            }

                for (int start = 0; start < n - 1; start++)
                {
                    int fuel = 0;
                    bool isSolution = true;

                    for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                    {
                        int[] currentPomp = queue.Dequeue();
                        int fuelAmount = currentPomp[0];
                        int distanceUntillNextPomp = currentPomp[1];

                        queue.Enqueue(currentPomp);

                        fuel += fuelAmount - distanceUntillNextPomp;

                        if (fuel < 0)
                        {
                            start += pumpsPassed;
                            isSolution = false;
                            break;
                        }
                    }

                    if (isSolution) {
                        Console.WriteLine(start);
                        return;
                    }
                }
        }
    }
}
