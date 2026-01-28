using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MathsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Maths Game!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            List<string[]> results = new List<string[]>();
            bool playing = true;
            do
            {
                Console.WriteLine("\nWhat game mode would you like to play?\nA - Addition\nS - Subtraction\nM - Multiplication\nD - Division\nR - View previous results\nQ - Exit game");
                string? mode = Console.ReadLine().ToUpper();
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
                       switch (mode)
                       {
                            case "A":
                                Console.WriteLine($"\nQuestion {i + 1}: What is {num1} + {num2}?");
                                answer = num1 + num2;
                                break;
                            case "S":
                                Console.WriteLine($"\nQuestion {i + 1}: What is {num1} - {num2}?");
                                answer = num1 - num2;
                                break;
                            case "M":
                                Console.WriteLine($"\nQuestion {i + 1}: What is {num1} * {num2}?");
                                answer = num1 * num2;
                                break;
                            case "D":
                                float floatDivCheck = (float)num1 / num2;
                                float intDivCheck = num1 / num2;
                                while (floatDivCheck != intDivCheck)
                                {
                                    num1 = new Random().Next(0, 101);
                                    num2 = new Random().Next(1, 11);
                                    floatDivCheck = (float)num1 / num2;
                                    intDivCheck = num1 / num2;
                                }
                                Console.WriteLine($"\nQuestion {i + 1}: What is {num1} / {num2}?");
                                answer = num1 / num2;
                                break;

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
                   results.Add(new string[2] {score.ToString(),mode});
                }
                else if (mode == "R")
                {
                    DateTime date = DateTime.Now;
                    Console.WriteLine($"\n{date}");
                    Console.WriteLine("Your previous results are:");
                    for (int i = 0; i < results.Count(); i++)
                    {
                        string[] tempResult = results[i];
                        string resultMode = tempResult[1];
                        switch (tempResult[1])
                        {
                            case "A":
                                resultMode = "Addition";
                                break;
                            case "S":
                                resultMode = "Subtraction";
                                break;
                            case "M":
                                resultMode = "Multiplication";
                                break;
                            case "D":
                                resultMode = "Division";
                                break;
                        }
                        Console.WriteLine($"\t{resultMode} - {tempResult[0]}");
                    }
                    Console.ReadKey();
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