using System.IO;
namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("{0,55}","CASINO");
            if (!File.Exists("Members.txt"))
            {
                Stream stream = File.Create("Members.txt");
                stream.Close();
            }
 
            int c = Login();
            Menu(c);
        }
        
        static int Login()
        {
            string filepath = "Members.txt";
            int c = -1;
            
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();
            foreach (string line in lines)
            {
                c++;
                string[] feild = line.Split(',');
                if (feild[0] == username && feild[1] == password)
                {
                    Console.WriteLine("Logged in Successfully!\n");
                    return c;
                }
            }
            Console.WriteLine("Incorrect UserName or Password\n1- Login\t2- Register");
            int choice = 0;
            try
            {
                choice = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (choice < 1 || choice > 2)
            {
                if (choice < 1 || choice > 2)
                    Console.WriteLine("Error! Please make a Valid selecion\n");

                Console.WriteLine("\n1- Login\t2- Register");
                try
                {
                    choice = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (choice == 1)
                return Login();
            else
            {
                Console.Write("Enter Username: ");
                username = Console.ReadLine();
                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                Console.WriteLine("Registertion Complete!");
                lines.Add(username + "," + password + ",1000");
                File.WriteAllLines(filepath, lines);
                return c + 1;
            }

        }

        static void Menu(int c)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧ ♠ ♥ ♦ ♣ ♤ ♡ ♢ ♧\n");           
            Console.WriteLine("1- Single-Player\t2- Multiplayer");
            int choice1 = 0;
            try
            {
                choice1 = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (choice1 < 1 || choice1 > 2)
            {
                if (choice1 < 1 || choice1 > 2)
                    Console.WriteLine("Error! Please make a Valid selecion\n");

                Console.WriteLine("\n1- Single-Player\t2- Multiplayer");
                try
                {
                    choice1 = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (choice1 == 1) SinglePlayer(c);
            else Multiplayer();

            Console.WriteLine("\nPlay again?\n1- Yes\t2- No");
            int choice2 = 0;
            try
            {
                choice2 = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (choice2 < 1 || choice2 > 2)
            {
                if (choice2 < 1 || choice2 > 2)
                    Console.WriteLine("Error! Please make a Valid selecion\n");

                Console.WriteLine("Play again?\n1- Yes\t2- No");
                try
                {
                    choice2 = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (choice2 == 1)
            {
                if (choice1 == 1)
                {
                    SinglePlayer(c);
                    Menu(c);
                }
                else
                {
                    Multiplayer();
                    Menu(c);
                }
            }
            else return;
        }

        static void SinglePlayer(int p)
        {
            string filepath = "Members.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();           
            string[] field = lines[p].Split(',');
                
            Deck deck1 = new Deck();
            deck1.Shuffle();
            int players = 2;

            Player[] player = new Player[players];
            for (int i = 1; i <= players; i++)
            {
                if (i == 2)
                    Console.WriteLine("Computer's Hand:");
                else
                    Console.WriteLine("\n" + field[0] + "'s Hand:");

                player[i - 1] = new Player(i, deck1, field[0], field[2]);
                player[i - 1].SortHand();
                player[i - 1].ShowHand();
                Console.WriteLine("\n");
            }

            GetWinnersingle(player);
        }

        static void Multiplayer()
        {
            Deck deck1 = new Deck();
            deck1.Shuffle();
            int players = 0;

            Console.Write("Enter number of Players(2~9): ");
            try
            {
                players = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            while (players < 2 || players > 9)
            {
                if (players < 2 || players > 9)
                    Console.WriteLine("\aError! Please enter a valid number of Players\n");

                Console.Write("Enter number of Players(2~9): ");
                try
                {
                    players = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine();

            Player[] player = new Player[players];
           /* for (int i = 1; i <= players; i++)
            {
                Console.WriteLine("Player " + i + " Hand:");
                player[i - 1] = new Player(i, deck1);
                player[i - 1].SortHand();
                player[i - 1].ShowHand();
                Console.WriteLine("\n");
            }*/

            GetWinner(player);
        }

        static void GetWinnersingle(Player[] player)
        {
            if (player[0].handvalue > player[1].handvalue)
            {
                Console.WriteLine(player[0].name + " Win!");
                return;
            }
            if (player[0].handvalue == player[1].handvalue)
            {
                bool Q = GetHighCard(player[0], player[1]);
                if (Q)
                {
                    Console.WriteLine(player[0].name + " Win!");
                    return;
                }
                else
                {
                    Console.WriteLine("You Lose!");
                    return;
                }
            }
            Console.WriteLine("You Lose!");
        }

        static void GetWinner(Player[] player)
        {
            int c = 1;
            var tempvar = 0;
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i].handvalue > tempvar)
                {
                    tempvar = player[i].handvalue;
                    c = i;
                }

                if (player[i].handvalue == tempvar)
                {
                    bool Q = GetHighCard(player[i], player[c]);
                    if (Q)
                    {
                        tempvar = player[i].handvalue;
                        c = i;
                    }
                }

            }
            Console.WriteLine("Player " + (c + 1) + " Wins!");
        }

        static bool GetHighCard(Player p1, Player p2)
        {
            for (int i = 0; i < Player.CardsCount; i++)
            {
                if (p1.hand[i].FaceValue > p2.hand[i].FaceValue)
                    return true;
            }
            return false;
        }
    }
}