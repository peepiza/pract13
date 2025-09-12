using System;

class Program
{
    static void Main(string[] args)
    {
        double memory = 0;
        double currentResult = 0;
        
        Console.WriteLine("Выберите операцию: +, -, *, /, %, ^, sqrt");
        Console.WriteLine("Память: M+, M-, MR");
        Console.WriteLine("Для выхода напишите 'exit'");
        
        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "exit")
                break;
                
            if (input == "MR")
            {
                Console.WriteLine("Memory: " + memory);
                continue;
            }
            
            if (input == "M+")
            {
                memory += currentResult;
                Console.WriteLine("Added to memory: " + currentResult);
                continue;
            }
            
            if (input == "M-")
            {
                memory -= currentResult;
                Console.WriteLine("Subtracted from memory: " + currentResult);
                continue;
            }
            
            string[] parts = input.Split(' ');
            
            if (parts.Length == 2 && parts[0] == "sqrt")
            {
                if (double.TryParse(parts[1], out double number))
                {
                    currentResult = Math.Sqrt(number);
                    Console.WriteLine("Result: " + currentResult);
                }
                else
                {
                    Console.WriteLine("ОШИБКА: Invalid number");
                }
                continue;
            }
            
            if (parts.Length == 3)
            {
                if (!double.TryParse(parts[0], out double num1) || 
                    !double.TryParse(parts[2], out double num2))
                {
                    Console.WriteLine("ОШИБКА: Invalid numbers");
                    continue;
                }
                
                switch (parts[1])
                {
                    case "+":
                        currentResult = num1 + num2;
                        break;
                    case "-":
                        currentResult = num1 - num2;
                        break;
                    case "*":
                        currentResult = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("ОШИБКА: Division by zero");
                            continue;
                        }
                        currentResult = num1 / num2;
                        break;
                    case "%":
                        currentResult = num1 % num2;
                        break;
                    case "^":
                        currentResult = Math.Pow(num1, num2);
                        break;
                    default:
                        Console.WriteLine("ОШИБКА: Unknown operation");
                        continue;
                }
                
                Console.WriteLine("Ответ: " + currentResult);
            }
            else
            {
                Console.WriteLine("ОШИБКА: Invalid input format");
                Console.WriteLine("Используйте: выражение типа: 'число операция число'");
                Console.WriteLine("Или: sqrt(x)");
            }
        }
    }
}
