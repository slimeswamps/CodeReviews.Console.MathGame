using System;

namespace MathsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcomes the user
            Console.WriteLine("Welcome to the Maths Game!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            List<int> results = new List<int>();
            bool playing = true;
            do
            {
                // Gets the chosen operator from the user
                Console.WriteLine("\nWhat game mode would you like to play?\nA - Addition\nS - Subtraction\nM - Multiplication\nD - Division\nR - View previous results\nQ - Exit game");
                string mode = Console.ReadLine().ToUpper();
                while (mode != "A" && mode != "S" && mode != "D" && mode != "M" && mode != "R" && mode != "Q")
                {
                    Console.WriteLine("\nInvalid operator.\nPlease choose from these:\nA - Addition\nS - Subtraction\nM - Multiplication\nD - Division\nR - View previous results\nQ - Exit game");
                    mode = Console.ReadLine();
                }
    
                if (mode == "A" || mode == "S" || mode =="M" || mode =="D")
                {
                   int score = 0;
                   for (int i = 0; i < 10; i++)
                   {
                       
                       int num1 = new Random().Next(1, 11);
                       int num2 = new Random().Next(1, 11);
                       int answer = 0;
                       if (mode == "A")
                       {
                           Console.WriteLine($"\nQuestion {i + 1}: What is {num1} + {num2}?");
                           answer = num1 + num2;
                       }
                       else if (mode == "S")
                       {
                           Console.WriteLine($"\nQuestion {i + 1}: What is {num1} - {num2}?");
                           answer = num1 - num2;
                       }
                       else if (mode == "M")
                       {
                           Console.WriteLine($"\nQuestion {i + 1}: What is {num1} * {num2}?");
                            answer = num1 * num2;
                       }
                       else if (mode == "D")
                       {
                           //Ensures that the division is possible with integers
                           float floatDivCheck = (float)num1/num2;
                           float intDivCheck = num1/num2;
                           while (floatDivCheck != intDivCheck)
                           {
                               num1 = new Random().Next(0, 101);
                               num2 = new Random().Next(1, 11);
                               floatDivCheck = (float)num1 / num2;
                               intDivCheck = num1 / num2;
                           }
                           Console.WriteLine($"\nQuestion {i + 1}: What is {num1} / {num2}?");
                           answer = num1 / num2;
                       }
                       int userAnswer;
                       while (!int.TryParse(Console.ReadLine(), out userAnswer))
                       {
                           Console.WriteLine("Invalid input. Please enter a number.");
                       }
                       if (userAnswer == answer)
                       {
                           Console.WriteLine("Correct!");
                           score++;
                       }
                       else
                       {
                        Console.WriteLine($"Incorrect. The correct answer was {answer}.");
                       }
                   }
                   Console.WriteLine($"Well done your score is: {score}");
                   results.Add(score);
                }
                else if (mode == "R")
                {
                   Console.WriteLine("\nYour previous results are:");
                   for (int i = 0; i < results.Count(); i++)
                   { 
                        Console.WriteLine(results[i]);
                   }
                     
                }
                else if (mode == "Q")
                {
                   Console.WriteLine("\nThank you for playing! Goodbye!");
                   return;
                }
            } while (playing);
        }
    }
}