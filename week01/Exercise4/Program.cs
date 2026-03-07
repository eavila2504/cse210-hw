using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = -1;
        while (inputNumber != 0)
        {
            Console.Write("Please, enter a number (press 0 to quit): ");
            string answer = Console.ReadLine();
            inputNumber = int.Parse(answer);

            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }

        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is {average}");

        int maxNumber = numbers[0];
        foreach (int number in numbers)
        {
            if (number > maxNumber)
            {
                maxNumber = number;

            }
        }
        Console.WriteLine($"The greatest number is {maxNumber} ");
    }

}