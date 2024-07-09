using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static List<string> calculationHistory = new List<string>();

    static void Main(string[] args)
    {
        bool continueCalculating = true;

        while (continueCalculating)
        {
            Console.WriteLine("\n1. Perform Calculation");
            Console.WriteLine("2. View History");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformCalculation();
                    break;
                case "2":
                    ViewHistory();
                    break;
                case "3":
                    continueCalculating = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the calculator. Goodbye!");
    }
    static void PerformCalculation()
    {
        double num1 = GetNumberInput("Enter the First Number");
        double num2 = GetNumberInput("Enter the Second Number");
        string operation = GetOperation();

        double result = 0;
        bool calculationSuccessful = true;

        try
        {
            checked
            {
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
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = num1 / num2;
                        break;
                }
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The result is too large or too small to be represented.");
            calculationSuccessful = false;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            calculationSuccessful = false;
        }

        if (calculationSuccessful)
        {
            string calculationString = $"{num1} {operation} {num2} = {result:F2}";
            Console.WriteLine($"The result is {result:F2}");
            calculationHistory.Add(calculationString);
        }
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
        string[] validOperations = { "+", "-", "*", "/", "%" };

        string operation;

        do
        {
            Console.WriteLine("Which Math Operation Would You Like To Do - \"+, -, *, /, %\" ?");
            operation = Console.ReadLine();
            if (!validOperations.Contains(operation))
            {
                Console.WriteLine("Incorrect math operator. Try again.");
            }
        } while (!validOperations.Contains(operation));

        return operation;
    }

    static void ViewHistory()
    {
        if (calculationHistory.Count == 0)
        {
            Console.WriteLine("No calculations have been performed yet.");
        }
        else
        {
            Console.WriteLine("Calculation History:");
            for (int i = 0; i < calculationHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {calculationHistory[i]}");
            }
        }
    }
}

