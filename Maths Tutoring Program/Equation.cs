using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Equation
    {
        public Pack ValuePack = new Pack(true);
        public Pack OperationPack = new Pack(false);
        public List<Card> ValueCards = new List<Card>();
        public List<Card> OperationCards = new List<Card>();
        public string[] Operations = { "+", "-", "*", "/" };
        public ValueCard equationAnswer = new ValueCard();
        public void CreateEquation(int numberOfValues)
        {
            ValuePack.ShuffleCardPack();
            OperationPack.ShuffleCardPack();
            ValueCards = ValuePack.DealCards(numberOfValues);
            OperationCards = OperationPack.DealCards(numberOfValues - 1);
            PrintEquation();
            equationAnswer = CalculateAnswer();
        }

        public void PrintEquation()
        {
            Console.WriteLine("");
            for (int i = 0; i < ValueCards.Count(); i++)
            {
                ValueCards.ElementAt(i).PrintCard();
                if (i + 1 < ValueCards.Count())
                {
                    OperationCards.ElementAt(i).PrintCard();
                }
            }
            Console.WriteLine("");
        }

        public void PrintAnswer()
        {
            Console.Write("\nThe Correct Answer is: ");
            equationAnswer.PrintCard();
        }

        public ValueCard CalculateAnswer()
        {

            int originalNumOperations = OperationCards.Count();
            int numOperations = 0;
            for (int i = 0; i < OperationCards.Count();i++)
            {
                if (OperationCards.ElementAt(i).Value == 2 || OperationCards.ElementAt(i).Value == 3)// * or /
                {
                    List<Card> tempDeck = new List<Card>();
                    for (int e = 0; e < 2; e++)
                    {
                        tempDeck.Add(ValueCards.ElementAt(i));
                        ValueCards.RemoveAt(i);
                    }
                    ValueCards.Insert(i, DoOperator(tempDeck, OperationCards.ElementAt(i)));
                    OperationCards.RemoveAt(i);
                    numOperations++;
                    if (numOperations < originalNumOperations)
                    {
                        i--;
                    }
                }
            }
            for (int i = 0; i < OperationCards.Count(); i++)
            {
                if (OperationCards.ElementAt(i).Value == 0 || OperationCards.ElementAt(i).Value == 1)// + or -
                {
                    List<Card> tempDeck = new List<Card>();
                    for (int e = 0; e < 2; e++)
                    {
                        tempDeck.Add(ValueCards.ElementAt(i));
                        ValueCards.RemoveAt(i);
                    }
                    ValueCards.Insert(i, DoOperator(tempDeck, OperationCards.ElementAt(i)));
                    OperationCards.RemoveAt(i);
                    numOperations++;
                    if(numOperations < originalNumOperations)
                    {
                        i--;
                    }
                }
            }
            return (ValueCard)ValueCards.ElementAt(0);
        }

        public Card DoOperator(in List<Card> ValueCards, in Card OperationCard)
        {
            int answer = 0;
            switch (Operations[OperationCard.Value])
            {
                case "+":
                    answer = ValueCards[0].Value + ValueCards[1].Value;
                    break;
                case "-":
                    answer = ValueCards[0].Value - ValueCards[1].Value;
                    break;
                case "*":
                    answer = ValueCards[0].Value * ValueCards[1].Value;
                    break;
                case "/":
                    try 
                    {
                        answer = ValueCards[0].Value / ValueCards[1].Value;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine(" Division by zero. Answer not possible");
                    }

                    break;
                default:
                    break;
            }
            ValueCard tempValueCard = new ValueCard();
            tempValueCard.Value = answer;
            return tempValueCard;
        }
    }
}
