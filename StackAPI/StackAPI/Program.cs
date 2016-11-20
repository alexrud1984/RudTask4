using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int ArraySize = GetUserArraySize(MaxArraySize);
            int [] UserArray = new int[ArraySize];
            int top = 0;
            int UserValue = 0;
            string command;
            do
            {
                Console.WriteLine("Put your command");
                switch (command = Console.ReadLine())
                {
                    case "push":
                        Console.WriteLine("Put the integer value for push");
                        UserValue = Convert.ToInt32(Console.ReadLine());
                        if (StackPush(UserArray, UserValue, ref top))
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Fail: Stack is full");
                        }
                        break;
                    case "pop":
                        Console.WriteLine(StackPop(UserArray, ref top));
                        break;
                    case "isempty":
                        Console.WriteLine(StakIsEmpty(top));
                        break;
                    case "isfull":
                        Console.WriteLine(StackIsFull(UserArray, top));
                        break;
                    case "peek":
                        Console.WriteLine(StackPeek(UserArray, top));
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

        static bool StackPush(int [] matrix, int pushValue, ref int top) //push the value to the next free sell
        {
            if (top == matrix.Length)
            {
                return (false);                                      //return false if stack is full
            }
            else
            {
                matrix[top] = pushValue;                             //push the value, return true and icrease pointer
                top++;                                               
                return (true);
            }
        }

        static int? StackPop(int [] matrix, ref int top)    //return top value in the stack
        {
            if (top == 0)
            {
                return (null);                              //return null if stack is empty
            }
            else
            {
                return (matrix[--top]);                     //return top value and decrease pointer
            }
        }

        static bool StakIsEmpty(int top)               //return true if stack is empty
        {
            if (top == 0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        static bool StackIsFull(int [] matrix, int top) //return true if stack is full
        {
            if (top == matrix.Length)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        static int? StackPeek(int [] matrix, int top) //return top value without deletion
        {
            if (top == 0)
            {
                return (null);
            }
            else
            {
                return (matrix[top-1]);
            }
        }
    }
}

