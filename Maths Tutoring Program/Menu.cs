using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Menu
    {
        public Menu()
        {
            Console.WriteLine("Welcome to The LinCode Mathematics Tutoring Program");
            PrintInstructions();
        }

        public Pack ValuePack = new Pack(true);
        public Pack OperationPack = new Pack(false);

        public void UserInput()
        {
            bool running = true;
            while (running == true)
            {
                List<Card> ValueCards = new List<Card>();
                List<Card> OperationCards = new List<Card>();
                ValuePack.ShuffleCardPack();
                OperationPack.ShuffleCardPack();
                Console.WriteLine("\nMenu:\n1: Instructions\n2: Deal 3 cards (2 numbers and an operation)\n3: Deal 5 cards (3 numbers and 2 operations)\n4: Stop program");
                switch (Console.ReadLine())
                {
                    case "1":
                        PrintInstructions();
                        break;
                    case "2":
                        Console.WriteLine("");
                        ValueCards = ValuePack.DealCards(2);
                        ValueCards.ElementAt(0).PrintCard();
                        OperationPack.DealOneCard().PrintCard();
                        ValueCards.ElementAt(1).PrintCard();
                        break;
                    case "3":
                        Console.WriteLine("");
                        ValueCards = ValuePack.DealCards(3);
                        OperationCards = OperationPack.DealCards(2);

                        ValueCards.ElementAt(0).PrintCard();
                        OperationCards.ElementAt(0).PrintCard();
                        ValueCards.ElementAt(1).PrintCard();
                        OperationCards.ElementAt(1).PrintCard();
                        ValueCards.ElementAt(2).PrintCard();
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
        public void PrintInstructions()
        {
            Console.WriteLine("Enter a value (from 1 to 4) in the menu for the option you would like.\nOption 1 will show you these instructions again\nOption 2 will give 2 values and an operator. It will prompt you to enter the answer. Then it will output the correct answer.\nOption 3 will give 3 values and 2 operators. It will prompt you to enter the answer (use BODMAS). Then it will output the correct answer.\nOption 4 Quit the game");
        }
    }
}