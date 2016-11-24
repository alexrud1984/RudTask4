using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAPI
{
    class Program
    {
        static int head = 0, tail = 0, count = 0;
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int ArraySize = GetUserArraySize(MaxArraySize);
            int[] UserArray = new int[ArraySize];
            int UserValue = 0, decResult=0;
            string command;
            do
            {
                Console.WriteLine("Put your command");
                switch (command = Console.ReadLine())
                {
                    case "enq":
                        Console.WriteLine("Put the integer value for enqueue");
                        UserValue = Convert.ToInt32(Console.ReadLine());
                        if (Enqueue(UserArray, UserValue))
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Fail: queue is full");
                        }
                        break;
                    case "deq":
                        if (Dequeue(UserArray, out decResult))
                        {
                            Console.WriteLine(decResult);
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty");
                        }
                        break;
                    case "isempty":
                        Console.WriteLine(IsEmpty());
                        break;
                    case "isfull":
                        Console.WriteLine(IsFull(UserArray.Length));
                        break;
                    case "exit":
                        break;
                    case "help":
                        Console.WriteLine("Nobody can help you, all helpers are busy!");
                        break;
                    default:
                        Console.WriteLine("Unknown command see help");
                        break;
                }
            }
            while (command != "exit");
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

        static bool Enqueue(int[] matrix, int value)  //method puts the user's value in the queue. 
        {
            if (IsFull(matrix.Length))
            {
                return (false);                                                    //return false if queue if full
            }
            else
            {
                matrix[tail] = value;
                tail++;
                count++;
                if (tail == matrix.Length)
                {
                    tail = 0;
                }
                return (true);                                                      //returns true if success
            }
        }

        static bool Dequeue(int[] matrix, out int result)  //method gets the user's value from the queue.
        {
            int pointer = head;
            result = 0;
            if (IsEmpty())
            {   
                return (false);                                          //return NULL if queue is empty
            }
            else
            {
                head++;
                count--;
                if(head==matrix.Length)
                {
                    head = 0;
                }
                result = matrix[pointer];
                return (true);
            }
        }

        static bool IsFull (int length)                      
        {
            if (count==length)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        static bool IsEmpty()
        {
            if (count == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
