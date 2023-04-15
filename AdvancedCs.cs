using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Test
{
    // Setting all methods to private since no other class uses the methods below
    public class Program
    {
        // Method to calculate return the sum of two numbers
        private double Add(double x, double y)
        {
            return x + y;
        }

        // Method to subtract the second number from the first
        // number, and returns the result
        private double Subtract(double x, double y)
        {
            return x - y;
        }

        // Method to calculate and return the product of two numbers
        private double Multiply(double x, double y)
        {
            return x * y;
        }

        /* Method to return the quotient of two numbers.
         * If division by zero is attempted, method throws an exception
        */
        private double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new ArgumentException("Invalid denominator. Re-compile with different input");
            }
            else return x / y;
        }

        // Method to return the remainder of division of two numbers
        private double CalculateRemainder(int x, int y)
        {
            return x % y;
        }

        // Method to calculate an exponential term and return the result           
        private double CalculateExponentiation(double x, double n)
        {
            double result = 1;
            if (n < 0)
            {
                Console.WriteLine("Exponent must be a non-negative integer.");
                Environment.Exit(-1);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= x;
                }
            }
            return result;
        }

        // Method to calculate and return the square root of a number
        private double CalculateSquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        // Method to display all possible operations of a calculator
        private static void DisplayOperations()
        {
            Console.WriteLine("Available operations: \n" +
            "\t+ | Addition\n" +
            "\t- | Subtraction\n" +
            "\t/ | Division\n" +
            "\t* | Multiplication\n" +
            "\t% | Remainder\n" +
            "\t^ | Exponentination function\n" +
            "\ts | Square root\n");
        }
       
        private static void DisplayMessage()
        {
            Console.WriteLine("UPDATE:");
            Console.WriteLine("All results are marked with letter 'R' in front of them.\n"
                + "Numbers that have asterix symbol (*) are the ones selected from the list.\n"
                + "Number that are selected from the list always behaves as the first operand.\n"
                + "Program will ask user for another input if number at certain index in the list \n"
                + "cannot be found. Program will ask for the valid index entry.\n");
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            double num = 0, num2, result = 0;
            Double num1;
            double amendNum;
            double temp = 0;
            double passedValue = 0;
            char operation;
            ConsoleKeyInfo operationEnter; // Used to detect 'Enter' key event
            string breaker = "default";
            string extractedNumber;
            bool escape = true;
            bool controller = false;
            int listIndex;
            
            // list to store inputs and results
            List<double> elements = new List<double>();

            // Displays all possible operations calculator supports
            DisplayMessage();
            DisplayOperations();            
            Console.WriteLine("Enter the number, then select your operation, and enter the second number followed by '=': ");

            // escape will be true until one of the loops detects 'Q' or 'q' as an operation
            while (escape)
            {
                if (Regex.IsMatch(breaker, @"[+-]?\d+(\.\d+)?"))
                {                    
                    num1 = num;
                    breaker = "default";                    
                } // checks if inner loop input is number or operation
                    
                else
                {
                    // Keeps asking for user input until valid entry happens. When valid entry is detected, loop breaks 
                    // and further execution continues.
                    while (true)
                    {
                        try
                        {                            
                            num1 = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {                            
                            Console.Write("");
                        }
                    }
                }
                    
                // Keeps asking for valid operation. When valid entry is detected, loop breaks and further execution continues.
                while(true)
                {                    
                    operation = Console.ReadLine()[0];
                    if(operation == '+' || operation == '-' || operation == '/' ||
                        operation == '*' || operation == '%' || operation == '^' || operation == 's' ||
                        operation == 'q' || operation == 'Q' || operation == 'P')
                        break;
                }

                // If any exception is thrown during an execution of a try block, loop resets.
                // If a valid entry is detected, break statement in try block exits the loop and continues with further execution.
                while (true)
                {
                    try
                    {
                        switch (operation)
                        {
                            case '+':                                
                                num2 = Convert.ToDouble(Console.ReadLine());
                                result = obj.Add(num1, num2);
                                // operation = Console.ReadLine()[0];
                                while(true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        //Console.WriteLine("");
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                    else if (operationEnter.KeyChar == 'M')
                                    {
                                        elements.Add(num2);
                                        Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {                                            
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));                                            
                                            break;
                                        }
                                    }
                                    else
                                        continue;
                                }
                                break;
                            case '-':
                                num2 = Convert.ToDouble(Console.ReadLine());
                                result = obj.Subtract(num1, num2);
                                while (true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                    else if (operationEnter.KeyChar == 'M')
                                    {
                                        elements.Add(num2);
                                        Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));
                                            break;
                                        }
                                    }
                                    else
                                        continue;
                                }
                                break;
                            case '/':
                                num2 = Convert.ToDouble(Console.ReadLine());
                                try
                                {
                                    result = obj.Divide(num1, num2);
                                    while (true)
                                    {
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));
                                            break;
                                        }
                                        else if (operationEnter.KeyChar == 'M')
                                        {
                                            elements.Add(num2);
                                            Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                            operationEnter = Console.ReadKey();
                                            if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                            {
                                                Console.WriteLine("\nR: " + Math.Round(result, 2));
                                                break;
                                            }
                                        }
                                        else
                                            continue;
                                    }
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine("Division by zero attempted. " + ex);
                                }
                                break;
                            case '*':
                                num2 = Convert.ToDouble(Console.ReadLine());
                                result = obj.Multiply(num1, num2);
                                while (true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                    else if (operationEnter.KeyChar == 'M')
                                    {
                                        elements.Add(num2);
                                        Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));
                                            break;
                                        }
                                    }
                                    else
                                        continue;
                                }
                                break;
                            case '%':
                                num2 = Convert.ToDouble(Console.ReadLine());
                                result = obj.CalculateRemainder(Convert.ToInt32(num1), Convert.ToInt32(num2));
                                while (true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                    else if (operationEnter.KeyChar == 'M')
                                    {
                                        elements.Add(num2);
                                        Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));
                                            break;
                                        }
                                    }
                                    else
                                        continue;
                                }
                                break;
                            case '^':
                                num2 = Convert.ToDouble(Console.ReadLine());
                                result = obj.CalculateExponentiation(num1, num2);
                                while(true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                    else if (operationEnter.KeyChar == 'M')
                                    {
                                        elements.Add(num2);
                                        Console.WriteLine(" -> " + Math.Round(num2, 2) + " added to list.");
                                        operationEnter = Console.ReadKey();
                                        if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                        {
                                            Console.WriteLine("\nR: " + Math.Round(result, 2));
                                            break;
                                        }
                                    }
                                    else
                                        continue;
                                }
                                break;
                            case 's':
                                if (result == 0)
                                {
                                    result = obj.CalculateSquareRoot(num1);
                                    Math.Round(result, 2);
                                }
                                    
                                else
                                {
                                    result = obj.CalculateSquareRoot(result);
                                    Math.Round(result, 2);
                                }
                                while (true)
                                {
                                    operationEnter = Console.ReadKey();
                                    if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                    {
                                        Console.WriteLine("\nR: " + Math.Round(result, 2));
                                        break;
                                    }
                                }
                                break;                            
                            case 'q':
                                escape = false; // 1st. escape sequence
                                break;
                            case 'Q':
                                escape = false; // 1st. escape sequence
                                break;
                            default:
                                Console.WriteLine("Wrong operation!");
                                break;
                        }
                        break;
                    }                                        
                    catch (Exception)
                    {
                        Console.Write("");
                    }

                }

                // DECIDER SEQUENCE BEGINS
                // Checks if user keeps appending operations
                // If user input is a number, the program will store the value in the temporary variable 'num' 
                // and assign that value to a first number in an outer loop. Otherwise, if a valid operation 
                // is detected, program asks for another input, which will be appended to the previous 
                // result, depending on which operation user chose.
                          
                // UPDATE 
                // When a number is selected from the list of saved elements, it will be marked 
                // with asterix symbol (*). This is to keep the interface as clean as possible
                while (!Regex.IsMatch(breaker, @"[+-]?\d+(\.\d+)?") && escape)
                {
                    // Operation or value input
                    Console.WriteLine("You're at breaker");
                    breaker = Console.ReadLine();
                    if (breaker == "+" || breaker == "-" || breaker == "/" || breaker == "*"
                        || breaker == "%" || breaker == "^" || breaker == "s")
                    {
                        while (true)
                        {
                            try
                            {
                                switch (breaker)
                                {
                                    case "+":                                        
                                        amendNum = Convert.ToDouble(Console.ReadLine());
                                        temp = amendNum;
                                        if (controller)
                                        {                                            
                                            result = passedValue;
                                            result = obj.Add(result, amendNum);
                                            controller = false;
                                        }                                                                                   
                                        else
                                        {                                            
                                            result = obj.Add(result, amendNum);                                           
                                        }                                            
                                        break;
                                    case "-":
                                        amendNum = Convert.ToDouble(Console.ReadLine());
                                        temp = amendNum;
                                        if (controller)
                                        {
                                            result = passedValue;
                                            result = obj.Subtract(result, amendNum);
                                            controller = false;
                                        }                                                                                   
                                        else
                                        {                                            
                                            result = obj.Subtract(result, amendNum);
                                        }
                                        break;
                                    case "/":
                                        try
                                        {
                                            amendNum = Convert.ToDouble(Console.ReadLine());
                                            temp = amendNum;
                                            if (controller)
                                            {
                                                result = passedValue;
                                                result = obj.Divide(result, amendNum);
                                                controller = false;
                                            }                                                                                       
                                            else
                                            {                                                
                                                result = obj.Divide(result, amendNum);
                                            }
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine("Division by zero attempted. " + ex);
                                        }
                                        break;
                                    case "*":
                                        amendNum = Convert.ToDouble(Console.ReadLine());
                                        temp = amendNum;
                                        if (controller)
                                        {
                                            result = passedValue;
                                            result = obj.Multiply(result, amendNum);
                                            controller = false;
                                        }                                                                                    
                                        else
                                        {                                            
                                            result = obj.Multiply(result, amendNum);
                                        }
                                        break;
                                    case "%":
                                        amendNum = Convert.ToDouble(Console.ReadLine());
                                        temp = amendNum;
                                        if (controller)
                                        {
                                            result = passedValue;
                                            result = obj.CalculateRemainder(Convert.ToInt32(result), Convert.ToInt32(amendNum));
                                            controller = false;
                                        }                                                                                  
                                        else
                                        {                                            
                                            result = obj.CalculateRemainder(Convert.ToInt32(result), Convert.ToInt32(amendNum)); ;
                                        }
                                        
                                        break;
                                    case "^":
                                        amendNum = Convert.ToDouble(Console.ReadLine());
                                        temp = amendNum;
                                        if (controller)
                                        {
                                            result = passedValue;
                                            result = obj.CalculateExponentiation(result, amendNum);
                                            controller = false;
                                        }
                                        else
                                        {                                            
                                            result = obj.CalculateExponentiation(result, amendNum);
                                        }
                                        break;
                                    case "s":
                                        // result = obj.CalculateSquareRoot(result);
                                        if(controller)
                                        {
                                            result = obj.CalculateSquareRoot(passedValue);
                                            controller = false;
                                        }
                                        else if (result == 0)
                                        {
                                            result = obj.CalculateSquareRoot(num1);
                                            Math.Round(result, 2);
                                        }                                                                                  
                                        else
                                        {
                                            result = obj.CalculateSquareRoot(result);
                                            Math.Round(result, 2);
                                        }
                                            
                                        break;                                    

                                    default:
                                        break;
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.Write("");                                
                            }
                        }
                        
                        // operation = Console.ReadLine()[0];
                        while (true)
                        {
                            operationEnter = Console.ReadKey();
                            if (operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                            {
                                Console.WriteLine("\nR: " + Math.Round(result, 2));
                                break;
                            }  
                            else if(operationEnter.KeyChar == 'M')
                            {
                                elements.Add(temp);
                                Console.WriteLine(" -> " + temp + " added to list. ");
                                operationEnter = Console.ReadKey();
                                if(operationEnter.Key == ConsoleKey.Enter || operationEnter.KeyChar == '=')
                                {
                                    Console.WriteLine("\nR: " + Math.Round(result, 2));
                                    break;
                                }
                            }
                        }

                    }
                    
                    else if (Regex.IsMatch(breaker, @"[+-]?\d+(\.\d+)?") && !breaker.Contains('R'))
                    {
                        // temp variable num gets passed to an outer loop 
                        num = Convert.ToDouble(breaker);
                        continue;
                    }
                    else if (breaker == "q" || breaker == "Q")
                    {
                        // Clear all elements from the memory
                        elements.Clear();
                        escape = false; // 2nd. escape sequence
                        break;
                    }

                    else if (breaker == "M")
                    {
                        elements.Add(result);
                        Console.WriteLine("-> " + Math.Round(result, 2) + " added to list");
                        continue;
                    }

                    else if(breaker == "P")
                    {
                        Console.Write("Saved elements: ");
                        foreach (double x in elements)
                        {
                            Console.Write(Math.Round(x, 2) + " ");                            
                        }                   
                        Console.WriteLine("");
                        breaker = "default";
                    }

                    else if(breaker.Contains('R'))
                    {
                        // string variable in which recognized index is stored
                        extractedNumber = Regex.Match(breaker, @"\d+").Value;

                        // integer that accepts converted index from previous string var.
                        listIndex = Int32.Parse(extractedNumber);                        
                        if (elements.Any() && elements.ElementAtOrDefault(listIndex-1) != 0)
                        {                                        
                            Console.WriteLine(elements[listIndex-1] + "*");
                            passedValue = elements[listIndex - 1];
                            controller = true;
                        }
                        else
                        {
                            Console.WriteLine("Result does not exist at location. ");
                            while (true)
                            {
                                breaker = Console.ReadLine();
                                if(breaker.Contains('R'))
                                {
                                    // string variable in which recognized index is stored
                                    extractedNumber = Regex.Match(breaker, @"\d+").Value;

                                    // integer that accepts converted index from previous string var.
                                    listIndex = Int32.Parse(extractedNumber);
                                    if (elements.Any() && elements.ElementAtOrDefault(listIndex - 1) != 0)
                                    {
                                        Console.WriteLine(elements[listIndex - 1] + "*");
                                        passedValue = elements[listIndex - 1];
                                        controller = true;
                                        break;
                                    }
                                }                                
                            }
                        }
                        breaker = "default";
                    }
                    else
                        continue;         
                    // END OF DECIDER SEQUENCE
                }
            }
        }
    }
}
