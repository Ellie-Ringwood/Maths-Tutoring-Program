using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths_Tutoring_Program
{
    internal class Pack
    {
        private List<Card> _pack = new List<Card>();

        //Properties
        public List<Card> pack
        {
            get { return _pack; }
            set { }
        }

        public Pack(bool _isAValue) // Constructor for pack class
        {
            if (_isAValue == true)
            {
                for (int value = 0; value < 12; value++) // creates pack of 13 cards of numbers
                {
                    ValueCard valueCard = new ValueCard();
                    valueCard.Value = value;
                    _pack.Add(valueCard);
                }
            }
            else
            {
                for (int operation = 0; operation < 3; operation++) // creates pack of 4 cards of operations
                {
                    OperationCard operationCard = new OperationCard();
                    operationCard.Value = operation;
                    _pack.Add(operationCard);
                }
            }
        }

        public void ShuffleCardPack()
        {
            Random random = new Random();
            //Fisher-Yates shuffle
            List<Card> tempPack = new List<Card>();
            while (_pack.Count() > 0) // until the pack is empty, pick a random card and add to the temporary list, then remove it from the original pack
            {
                int num = random.Next(0, _pack.Count());
                tempPack.Add(_pack.ElementAt(num));
                _pack.RemoveAt(num);
            }
            _pack = tempPack;
        }
        public Card DealOneCard()
        {
            Card tempCard = _pack.ElementAt(0);
            return tempCard;
        }

        public List<Card> DealCards(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> deltCards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                deltCards.Add(_pack.ElementAt(i));
            }
            return deltCards;
        }
    }
}

