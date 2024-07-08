using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int num1;
        int num2;
        int result = 0;

        string answer;
        Console.WriteLine("Hello, Welcome to the simple Calculator!");
        Console.WriteLine("Enter the First Number");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the Second Number");

        num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Which Math Operation Would You Like To Do - \"+, -, *, /\" ?");
        Console.WriteLine("");

        answer = Console.ReadLine();

        if (answer.Equals("+"))
        {
            result = num1 + num2;
        }
        else if (answer.Equals("-"))
        {
            result = num1 - num2;
        }
        else if (answer.Equals("*"))
        {
            result = num1 * num2;
        }
        else if (answer.Equals("/"))
        {
            result = num1 / num2;
        }
        else
        {
            Console.WriteLine("Incorrect math operator. Try again.");
        }

        Console.WriteLine($"The result is {result}");
    }
}