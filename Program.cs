using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int num1 = 0;
        int num2 = 0;
        int result = 0;

        string answer;
        Console.WriteLine("Hello, Welcome to the simple Calculator!");

        // Input for num1
        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Enter the First Number");
            try
            {
                num1 = Convert.ToInt32(Console.ReadLine());
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        // Input for num2
        validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Enter the Second Number");
            try
            {
                num2 = Convert.ToInt32(Console.ReadLine());
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        Console.WriteLine("Which Math Operation Would You Like To Do - \"+, -, *, /\" ?");

        answer = Console.ReadLine();

        bool inputValidation = false;

        while (!inputValidation)
        {
            Console.WriteLine("Which Math Operation Would You Like To Do - \"+, -, *, /\" ?");
            answer = Console.ReadLine();

            switch (answer)
            {
                case "+":
                    result = num1 + num2;
                    inputValidation = true;
                    break;
                case "-":
                    result = num1 - num2;
                    inputValidation = true;
                    break;
                case "*":
                    result = num1 * num2;
                    inputValidation = true;
                    break;
                case "/":
                    try
                    {
                        result = num1 / num2;
                        inputValidation = true;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect math operator. Try again.");
                    break;
            }
        }

        Console.WriteLine($"The result is {result}");
    }
}