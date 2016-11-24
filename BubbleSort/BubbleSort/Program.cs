using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int[] UserArray;
            int ArraySize = GetUserArraySize(MaxArraySize);
            FillUserArray(ArraySize, out UserArray);
            BubbleSort(UserArray);
            PrintArray(UserArray, "Your array has been sorted:");
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
            int bufferValue = matrix[first];
            matrix[first] = matrix[second];
            matrix[second] = bufferValue;
        }

        static void BubbleSort(int[] matrix) //sort given matrix using bubble algorithm
        {
            bool SwapTrue = false;
            do
            {
                SwapTrue = false;
                for (int i = 0; i < (matrix.Length - 1); i++)
                {
                    if (matrix[i] > matrix[i + 1])
                    {
                        DoSwap(matrix, i, (i + 1));
                        SwapTrue = true;
                    }
                }
            }
            while (SwapTrue);
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
