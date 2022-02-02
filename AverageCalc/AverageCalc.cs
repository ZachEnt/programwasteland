/*
* Calculates the average of numbers input into console.
*/

using System;
using System.Threading.Channels;

namespace AverageCalc
{
    class AverageCalc
    {
        public static void Main(string[] args)
        {
            double average = 0.0;
            var inputNumber = 0;
            int counter = 0;
            
            while (inputNumber != -1)
            {
                Console.Write($"Input score for student #{counter + 1}: ");
                var inputString = Console.ReadLine();

                var passed = int.TryParse(inputString, out inputNumber);
                if (!passed) // Removes wrong datatype error.
                {
                    Console.WriteLine("Terminated, Please only enter numbers!!!");
                    break;
                }

                if (inputNumber != -1) // Only increment if there is a valid input.
                {
                    average += inputNumber;
                    counter += 1;
                }
            }

            Console.WriteLine($"\n{average} / {counter}");
            if (counter != 0) // Prevent divide by 0.
                average = average / counter;

            Console.WriteLine($"The average score of all students is: {average}");
        }
    }
}