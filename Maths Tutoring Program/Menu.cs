using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Menu
    {
        private Tutorial tutorial = new Tutorial();
        private Equation equation;
        private Statistics stats;

        public Menu(Statistics stats, Equation equation)
        {
            this.stats = stats;
            this.equation = equation;
        }

        public void UserInput()
        {
            Console.WriteLine("\nWelcome to The LinCode Mathematics Tutoring Program");
            tutorial.PrintInstructions();
            Console.WriteLine("Enter Username: ");
            while (true)
            {
                string username = Console.ReadLine();
                if (username == "")
                {
                    Console.WriteLine("Username must not be empty, Enter again: ");
                }
                else
                {
                    stats.currentUsername = username;
                    break;
                }
            }
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("\nMenu:\n1: Instructions\n2: Deal 3 cards (2 numbers and an operation)\n3: Deal 5 cards (3 numbers and 2 operations)\n4: LeaderBoard \n5: Stop program");
                switch (Console.ReadLine())
                {
                    case "1":
                        tutorial.PrintInstructions();
                        break;
                    case "2":
                        AskQuestion(2);
                        break;
                    case "3":
                        AskQuestion(3);
                        break;
                    case "4":
                        stats.PrintStats();
                        break;
                    case "5":
                        stats.addStatistic();
                        running = false;
                        Console.WriteLine("Goodbye from The LinCode Mathematics Tutoring Program");
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry: Input not understood");
                        break;
                }
            }
        }

        public void AskQuestion(int numValues)
        {
            equation.CreateEquation(numValues);
            int answer = -1;
            while (true)
            {
                Console.WriteLine("\nEnter Answer (Round down to integer if needed):");
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error answer not integer");
                }
            }
            if (equation.CheckAnswer(answer, stats))
            {
                Console.WriteLine("Your answer is correct!");
            }
            else
            {
                Console.WriteLine("Your answer is incorrect!");
            }
            equation.PrintAnswer();
        }
    }
}