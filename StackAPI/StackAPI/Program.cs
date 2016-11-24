using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAPI
{
    class Program
    {
        static int top=0;
        static int[] matrix;
        static void Main(string[] args)
        {
            byte MaxArraySize = 255;
            int ArraySize = GetUserArraySize(MaxArraySize);
            matrix = new int[ArraySize];
            int UserValue = 0, result=0;
            string command;
            do
            {
                Console.WriteLine("Put your command");
                switch (command = Console.ReadLine())
                {
                    case "push":
                        Console.WriteLine("Put the integer value for push");
                        UserValue = Convert.ToInt32(Console.ReadLine());
                        if (StackPush(UserValue))
                        {
                            Console.WriteLine("Success");
                        }
                        else
                        {
                            Console.WriteLine("Fail: Stack is full");
                        }
                        break;
                    case "pop":
                        if (StackPop(out result))
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty");
                        }
                        break;
                    case "isempty":
                        Console.WriteLine(StakIsEmpty());
                        break;
                    case "isfull":
                        Console.WriteLine(StackIsFull());
                        break;
                    case "peek":
                        if (StackPeek(out result))
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty");
                        }
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

        static bool StackPush(int pushValue) //push the value to the next free sell
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

        static bool StackPop(out int result)    //return top value in the stack
        {
            if (top == 0)
            {
                result = 0;
                return (false);                              //return null if stack is empty
            }
            else
            {
                result=matrix[--top];
                return (true);                     //return top value and decrease pointer
            }
        }

        static bool StakIsEmpty()               //return true if stack is empty
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

        static bool StackIsFull() //return true if stack is full
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

        static bool StackPeek(out int result) //return top value without deletion
        {
            result = 0;
            if (top == 0)
            {
                return (false);
            }
            else
            {
                result = matrix[top - 1];
                return (true);
            }
        }
    }
}

