using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        bool performCalculation = true;

        while (performCalculation)
        {
            PerformCalculation();

            Console.WriteLine("Do you want to perform another calculation?");

            string answer = Console.ReadLine().ToLower();
            performCalculation = (answer == "y" || answer == "yes");
        }

        Console.WriteLine("Thank you for using the calculator!");

    }

    static void PerformCalculation()
    {
        double num1 = 0;
        double num2 = 0;
        double result = 0;

        Console.WriteLine("Welcome to the Calculator!");

        num1 = GetNumberInput("Enter the First Number");
        num2 = GetNumberInput("Enter the Second Number");

        string operation = GetOperation();

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                try
                {
                    result = num1 / num2;
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
        Console.WriteLine($"The result is {result:F2}");
    }

    static double GetNumberInput(string prompt)
    {
        double number;
        bool validInput = false;

        do
        {
            Console.WriteLine(prompt);
            validInput = double.TryParse(Console.ReadLine(), out number);

            if (!validInput)
            {
                Console.WriteLine("Invalid Input. Enter a number");
            }
        } while (!validInput);

        return number;
    }

    static string GetOperation()
    {
        string[] validOperations = { "+", "-", "*", "/" };

        string operation;

        do
        {
            Console.WriteLine("Which Math Operation Would You Like To Do - \"+, -, *, /\" ?");
            operation = Console.ReadLine();
            if (!validOperations.Contains(operation))
            {
                Console.WriteLine("Incorrect math operator. Try again.");
            }
        } while (!validOperations.Contains(operation));

        return operation;
    }
}

