using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static List<string> calculationHistory = new List<string>();
    const string historyFile = "calculation_history.txt";

    static void Main(string[] args)
    {
        LoadCalculations();
        bool continueCalculating = true;

        while (continueCalculating)
        {
            Console.WriteLine("\n1. Perform Calculation");
            Console.WriteLine("2. View History");
            Console.WriteLine("3. Clear History");
            Console.WriteLine("4. Exit");
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
                    ClearCalculations();
                    break;
                case "4":
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
            SaveCalculations();
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
            int counter = 0;
            foreach (string calculation in calculationHistory)
            {
                counter++;
                Console.WriteLine($"{counter}. {calculation}");
            }
        }
    }

    static void SaveCalculations()
    {
        try
        {
            File.WriteAllLines(historyFile, calculationHistory);
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error has occured while saving: {e.Message}");
        }
    }

    static void LoadCalculations()
    {
        try
        {
            if (File.Exists(historyFile))
            {
                calculationHistory = new List<string>(File.ReadAllLines(historyFile));
                Console.WriteLine("Calculations loaded successfully.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Couldn't load calculations: {e.Message}");
        }
    }

    static void ClearCalculations()
    {
        try
        {
            calculationHistory.Clear();

            Console.WriteLine("Are you sure you want to clear history? (y/n)");

            string check = Console.ReadLine().ToLower();

            if (check == "y" || check == "yes")
            {
                if (File.Exists(historyFile))
                {
                    File.WriteAllText(historyFile, string.Empty);
                    Console.WriteLine("Calcualtions history has been cleared.");
                }
            }
            else
            {
                Console.WriteLine("Operation canceled. Returning to main menu.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occured while trying to clear the history: {e.Message}");
        }
    }
}

