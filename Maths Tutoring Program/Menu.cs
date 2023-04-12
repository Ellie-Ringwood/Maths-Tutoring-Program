using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Menu
    {
        
        public Tutorial tutorial = new Tutorial();
        public Equation equation = new Equation();
        public Menu()
        {
            Console.WriteLine("Welcome to The LinCode Mathematics Tutoring Program");
            tutorial.PrintInstructions();
        }

        public void MenuInput()
        {
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("\nMenu:\n1: Instructions\n2: Deal 3 cards (2 numbers and an operation)\n3: Deal 5 cards (3 numbers and 2 operations)\n4: Stop program");
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
            }
            else
            {
                Console.WriteLine("Your answer is incorrect");
            }
            equation.PrintAnswer();
        }
    }
}