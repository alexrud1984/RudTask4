﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int[] UserArray;
            int ArraySize = GetUserArraySize(MaxArraySize);
            FillUserArray(ArraySize, out UserArray);
            InsertionSort(UserArray);
            PrintArray(UserArray,"Your array has been sorted:");
            Console.ReadKey();
        }

        static int GetUserArraySize(byte max) //method gets array size from user, max - biggest possible size
        {
            int size = 0;
            do
            {
                Console.WriteLine("Define an array size and press Enter \nSize can be from 1 to " + max);
                size = Convert.ToInt32(Console.ReadLine());
            }
            while (size < 1);
            return (size);
        }

        static void FillUserArray(int size, out int[] array) //method creates array with defined size, ask user to fill array
        {
            array = new int[size];
            Console.WriteLine("Fill the array via entering values from -2,147,483,648 to 2,147,483,647 \nPress Enter after each value.");
            for (int i = 0; i < size; i++)
            {
                array[i] = (Convert.ToInt32(Console.ReadLine()));
            }
        }

        static void DoSwap(int[] matrix, int first, int second) //swap sells in the matrix with given indexes
        {
            matrix[first] ^= matrix[second];
            matrix[second] = matrix[first] ^ matrix[second];
            matrix[first] ^= matrix[second];
        }

        static void InsertionSort(int[] matrix)                             //sort given matrix using insertion algorithm
        {
                for (int i = 1; i < matrix.Length; i++)
                {
                    int pointer = i;
                    while ((pointer>0) && (matrix[pointer-1] > matrix[pointer])) //do if current position >0 and previous sell is bigger than current. to Pavlo: is it correct? pointer-1 potentially==matrix[-1]?
                    {
                        DoSwap(matrix, pointer-1, pointer);                  //swap previous with current
                        pointer--;                                           //go to previous sell
                    }
            }
        }

        static void PrintArray(int[] matrix, string message) //print the matrix
        {
            Console.WriteLine(message);
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(matrix[i]);
            }
        }
    }
}
