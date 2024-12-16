using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MidTest
{
    public static class MyFunctions
    {
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double CosMethod(double x, double acc, out int counter)
        {
            counter = 0;

            double radians = x;

            double CosValue = 1;
            int power = 2;
            int sign = -1;
            double term;
            do
            {
                term = sign * Math.Pow(radians, power) / Factorial(power);


                CosValue += term;


                power += 2;
                sign *= -1;



                counter++;
            }
            while (Math.Abs(term) >= acc);
            Console.WriteLine($"It was needed to have: {counter} amount of iterations");
            return CosValue;
        }




        public static void SaveToFile(string name_of_file, double accuracy, double result, int counter)
        {
            try
            {
                File.WriteAllText(name_of_file,
                    $"Chosen accuracy: {accuracy}\n" +
                    $"Calculated cos(x): {result}\n" +
                    $"Amount of iterations: {counter}"
                    );
                Console.WriteLine($"Results successfully written to file: {name_of_file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        public static void ReadFile(string name_of_file)
        {
            try
            {
                if (File.Exists(name_of_file))
                {
                    string content = File.ReadAllText(name_of_file);
                    Console.WriteLine("File content:");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"File \"{name_of_file}\" does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }
    }
}

