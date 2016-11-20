using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int ArraySize = GetUserArraySize(MaxArraySize);
            int[] UserArray = new int[ArraySize];
            int head=0, tail=0, count=0, UserValue = 0;
            string command;
            do
            {
                Console.WriteLine("Put your command");
                switch (command = Console.ReadLine())
                {
                    case "enq":
                        Console.WriteLine("Put the integer value for enqueue");
                        UserValue = Convert.ToInt32(Console.ReadLine());
                        if (Enqueue(UserArray, ref tail, ref count, UserValue))
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Fail: queue is full");
                        }
                        break;
                    case "deq":
                        Console.WriteLine(Dequeue(UserArray, ref head, ref count));
                        break;
                    case "isempty":
                        Console.WriteLine(IsEmpty(count));
                        break;
                    case "isfull":
                        Console.WriteLine(IsFull(UserArray.Length,count));
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

        static bool Enqueue(int[] matrix, ref int tail, ref int count, int value)  //method puts the user's value in the queue. 
        {
            if (IsFull(matrix.Length,count))
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

        static int? Dequeue(int[] matrix, ref int head, ref int count)  //method gets the user's value from the queue.
        {
            int pointer = head;
            if (IsEmpty(count))
            {
                return (null);                                          //return NULL if queue is empty
            }
            else
            {
                head++;
                count--;
                if(head==matrix.Length)
                {
                    head = 0;
                }
                return (matrix[pointer]);
            }
        }

        static bool IsFull (int length, int count)                      
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

        static bool IsEmpty(int count)
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
