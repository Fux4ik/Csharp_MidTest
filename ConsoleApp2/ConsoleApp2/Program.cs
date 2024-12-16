using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Reflection;
using MidTest;

namespace MidTest
{

    namespace Kalashnyk
    {




        internal class Program
        {


            static void Main(string[] args)
            {
                string name_of_file;
                int choice;

                double accuracy;
                Console.WriteLine("Choose the value for x: ");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Choose the accurancy from following: 1 - 10(-6), 2 - 10(-9), 3 - 10(-12) ");
                while (true)
                {
                    int acc = int.Parse(Console.ReadLine());
                    switch (acc)
                    {
                        case 1:
                            accuracy = Math.Pow(10, -6);
                            break;
                        case 2:
                            accuracy = Math.Pow(10, -9);
                            break;
                        case 3:
                            accuracy = Math.Pow(10, -12);
                            break;
                        default:
                            Console.WriteLine("Incorrect input, try again");
                            continue;
                    }
                    break;
                }

                double result = MyFunctions.CosMethod(x, accuracy, out int counter);
                Console.WriteLine($"The calculated value of cos({x}) is: {result}");
                Console.WriteLine("This data will be transfered to txt file. Would you like to rename the file?");
                Console.WriteLine("1 - Yes, 2 - No");
               
                while (true)
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("How you would like to rename the file?");
                            name_of_file = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("The name of file <result> saved on your computer");
                            name_of_file = "result";
                            break;
                        default:
                            Console.WriteLine("Incorrect input, please try again.");
                            continue;
                    }
                    break;
                }
                MyFunctions.SaveToFile(name_of_file, accuracy, result, counter);
                MyFunctions.ReadFile(name_of_file);

                Console.WriteLine(Math.Cos(x));

            }
        }
    }
}
