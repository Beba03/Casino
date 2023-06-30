using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    internal class Player
    {
        public string name;
        public int number;
        public int money;
        public Card[] hand;
        public const int CardsCount = 5;
        public int handvalue;

        public Player(int anumber, Deck deck, string aname,string amoney)
        {
            name= aname;
            money=Convert.ToInt32(amoney);
            number = anumber;
            hand = new Card[CardsCount];

            for (int i = 0; i < CardsCount; i++)
            {
                hand[i] = deck.Deal();
            }
        }

        public void SortHand()
        {
            for (int i = 0; i < CardsCount - 1; i++)
                for (int j = 0; j < CardsCount - i - 1; j++)
                    if ((hand[j].FaceValue) < (hand[j + 1].FaceValue))
                    {
                        var tempVar = hand[j];
                        hand[j] = hand[j + 1];
                        hand[j + 1] = tempVar;
                    }
            handvalue = GetHand_Value();
        }

        public void ShowHand()
        {
            for (int i = 0; i < 5; i++)
                Console.Write("{0,-19}", hand[i]);
            Console.Write("\nStrengh: ");
            switch (handvalue)
            {
                case 1: Console.Write(Enums.Hand_Values.High_Card); break;
                case 2: Console.Write(Enums.Hand_Values.Pair); break;
                case 3: Console.Write(Enums.Hand_Values.Two_Pairs); break;
                case 4: Console.Write(Enums.Hand_Values.Three_Of_A_Kind); break;
                case 5: Console.Write(Enums.Hand_Values.Straight); break;
                case 6: Console.Write(Enums.Hand_Values.Flush); break;
                case 7: Console.Write(Enums.Hand_Values.Full_House); break;
                case 8: Console.Write(Enums.Hand_Values.Four_Of_A_Kind); break;
                case 9: Console.Write(Enums.Hand_Values.Stright_Flush); break;
                case 10: Console.Write(Enums.Hand_Values.Full_House); break;
            }
        }

        public int GetHand_Value()
        {
            if (hand[0].SuitValue == hand[1].SuitValue && hand[1].SuitValue == hand[2].SuitValue && hand[2].SuitValue == hand[3].SuitValue && hand[3].SuitValue == hand[4].SuitValue)//F
            {
                if (hand[0].FaceValue == 14 && hand[1].SuitValue == 13 && hand[2].SuitValue == 12 && hand[3].SuitValue == 11 && hand[4].SuitValue == 10)
                { return (int)Enums.Hand_Values.Royal_Flush; }//RF

                if (hand[1].FaceValue == hand[0].FaceValue - 1 && hand[2].FaceValue == hand[1].FaceValue - 1 && hand[3].FaceValue == hand[2].FaceValue - 1 && hand[4].FaceValue == hand[3].FaceValue - 1 || hand[0].FaceValue == 14 && hand[1].FaceValue == 5 && hand[2].FaceValue == 4 && hand[3].FaceValue == 3 && hand[4].FaceValue == 2)
                { return (int)Enums.Hand_Values.Stright_Flush; }//SF

                return (int)Enums.Hand_Values.Flush;//F
            }

            if (hand[1].FaceValue == hand[0].FaceValue - 1 && hand[2].FaceValue == hand[1].FaceValue - 1 && hand[3].FaceValue == hand[2].FaceValue - 1 && hand[4].FaceValue == hand[3].FaceValue - 1 || hand[0].FaceValue == 14 && hand[1].FaceValue == 5 && hand[2].FaceValue == 4 && hand[3].FaceValue == 3 && hand[4].FaceValue == 2)//S
            { return (int)Enums.Hand_Values.Straight; }

            if (hand[0].FaceValue == hand[1].FaceValue && hand[1].FaceValue == hand[2].FaceValue && hand[2].FaceValue == hand[3].FaceValue || hand[1].FaceValue == hand[2].FaceValue && hand[2].FaceValue == hand[3].FaceValue && hand[3].FaceValue == hand[4].FaceValue)//4K
            { return (int)Enums.Hand_Values.Four_Of_A_Kind; }

            if (hand[0].FaceValue == hand[1].FaceValue && hand[1].FaceValue == hand[2].FaceValue || hand[1].FaceValue == hand[2].FaceValue && hand[2].FaceValue == hand[3].FaceValue || hand[2].FaceValue == hand[3].FaceValue && hand[3].FaceValue == hand[4].FaceValue)//3K
            { return (int)Enums.Hand_Values.Three_Of_A_Kind; }

            if (hand[0].FaceValue == hand[1].FaceValue && hand[1].FaceValue == hand[2].FaceValue && hand[3].FaceValue == hand[4].FaceValue || hand[0].FaceValue == hand[1].FaceValue && hand[2].FaceValue == hand[3].FaceValue && hand[3].FaceValue == hand[4].FaceValue)//FH
            { return (int)Enums.Hand_Values.Full_House; }

            if (hand[0].FaceValue == hand[1].FaceValue && hand[2].FaceValue == hand[3].FaceValue || hand[0].FaceValue == hand[1].FaceValue && hand[3].FaceValue == hand[4].FaceValue || hand[1].FaceValue == hand[2].FaceValue && hand[3].FaceValue == hand[4].FaceValue)//2P
            { return (int)Enums.Hand_Values.Two_Pairs; }

            if (hand[0].FaceValue == hand[1].FaceValue || hand[1].FaceValue == hand[2].FaceValue || hand[2].FaceValue == hand[3].FaceValue || hand[3].FaceValue == hand[4].FaceValue)//P
            { return (int)Enums.Hand_Values.Pair; }

            else
                return (int)Enums.Hand_Values.High_Card; //HC
        }

    }
}