using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Deck
    {
        public Card[] deck;
        private const int Number_Of_Cards = 52;
        public int cardcount;

        public Deck()
        {
            cardcount = 0;
            string[] Faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] Suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            deck = new Card[Number_Of_Cards];

            int index = 0;
            for (int i = 0; i < Suits.Length; i++)
            {
                for (int j = 0; j < Faces.Length; j++)
                {
                    deck[index] = new Card(Faces[j], Suits[i]);
                    index++;
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            Card temp;
            for (int x = 0; x < 1000; x++)
            {
                for (int i = 0; i < Number_Of_Cards; i++)
                {
                    int rnd = random.Next(0, 52);
                    temp = deck[i];
                    deck[i] = deck[rnd];
                    deck[rnd] = temp;
                }
            }
        }

        public Card Deal()
        {
            if (cardcount > 51)
                return null;

            return deck[cardcount++];
        }
    }
}