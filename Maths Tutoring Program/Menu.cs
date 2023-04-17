using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Menu
    {
        public string userName;
        public int corrects;
        public int incorrects;
        public Tutorial tutorial = new Tutorial();
        public Equation equation = new Equation();
        public Statistics stats = new Statistics();
        public Menu()
        {
            Console.WriteLine("Welcome to The LinCode Mathematics Tutoring Program");
            Console.WriteLine("Enter Username: ");
            while (true)
            {
                userName = Console.ReadLine();
                if (userName == "") 
                {
                    Console.WriteLine("Username must not be empty, Enter again: ");
                }
                else
                {
                    break;
                }
            }
            tutorial.PrintInstructions();
        }

        public void MenuInput()
        {
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
                        float percentage = 0.0f;
                        if (corrects+incorrects != 0)
                        {
                            percentage = ((float) corrects / (corrects + incorrects)) * 100;
                            Console.WriteLine(percentage);
                        }
                        stats.addStatistic(userName,corrects,incorrects,percentage);
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

            if (answer == equation.equationAnswer.Value)
            {
                Console.WriteLine("Your answer is correct!");
                corrects++;
            }
            else
            {
                Console.WriteLine("Your answer is incorrect");
                incorrects++;
            }
            equation.PrintAnswer();
        }
    }
}