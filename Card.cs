using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Card
    {
        public string Face;
        public string Suit;
        public int FaceValue;
        public int SuitValue;

        public Card(string aFace, string aSuit)
        {

            Face = aFace;
            Suit = aSuit;
            switch (Face)
            {
                case "Two": FaceValue = 2; break;
                case "Three": FaceValue = 3; break;
                case "Four": FaceValue = 4; break;
                case "Five": FaceValue = 5; break;
                case "Six": FaceValue = 6; break;
                case "Seven": FaceValue = 7; break;
                case "Eight": FaceValue = 8; break;
                case "Nine": FaceValue = 9; break;
                case "Ten": FaceValue = 10; break;
                case "Jack": FaceValue = 11; break;
                case "Queen": FaceValue = 12; break;
                case "King": FaceValue = 13; break;
                case "Ace": FaceValue = 14; break;
            }
            switch (Suit)
            {
                case "Spades": SuitValue = 4; break;
                case "Hearts": SuitValue = 3; break;
                case "Diamonds": SuitValue = 2; break;
                case "Clubs": SuitValue = 1; break;
            }
        }

        public override string ToString()
        {
            return Face + " of " + Suit;
        }

    }
}