using System;
using System.Collections.Generic;

namespace InterviewWar
{
    class Program
    {

        public static Deck Player1 = new Deck("Player 1");
        public static Deck Player2 = new Deck("Player 2");
        public static Dealer Dealer = new Dealer();
        static void Main(string[] args)
        {
            Console.WriteLine("The Game of War \n -----------------------\n 2/19/2021 Connor Loughnane");

            bool exit = false;
            string input;
            //Simple Loop to act as main menu
            while (!exit)
            {
                Console.WriteLine("\nMain Menu \n -Press 1 to play \n \n -Press 3 to exit");
                input = Console.ReadLine();
                input.Trim();
                switch (input)
                {
                    case "1": Play();
                        break;
                    case "3":
                        exit = true;
                        break;
                }
            }
        }
        static void Play()
        {
            
            Console.WriteLine("\nStarting Game.....\n ....\n ...");
            //create deck, 2 hands, deal cards to each hand, and then prompt player to draw
            string input;
            bool gameEnd = false;
            Console.WriteLine("\nDealing Cards");
            Dealer.Deck();
            Dealer.Deal(Player1, Player2);
            Console.WriteLine("\nGame has started");

            while (!gameEnd)
            {
                Console.WriteLine("\nType 1 to draw, type 3 to quit");
                input = Console.ReadLine();
                input.Trim();
                switch (input)
                {
                    case "1": var result = Turn();
                        if (result == null) break;
                        Console.WriteLine(result.playerName + " has won the draw!");
                        Dealer.Deal(result);
                        break;
                    case "3":
                        gameEnd = true;
                        break;
                }
                var won = winner();
                if(won == null)
                {
                    Console.WriteLine(Player1.playerName + " has " + Player1.hasRemaining() + " cards remaining. " + Player2.playerName + " has " + Player2.hasRemaining() + " cards remaining");
                }
                else
                {
                    Console.WriteLine(won.playerName + " has won the game!");
                    gameEnd = true;
                }
            }


        }
        public static Deck winner()
        {
            if (Player1.hasRemaining() == 52 | Player2.hasRemaining() == 0)
            {
                return Player1;
            }
            else if (Player2.hasRemaining() == 52 | Player1.hasRemaining() == 0)
            {
                return Player2;
            }
            else return null;
        }
        static Card Draw(Deck source, bool hidden = false)
        {
            if (source.hasRemaining() > 0)
            {
                var card = source.Draw();
                if (hidden)
                {
                    Console.WriteLine(source.playerName + " drew a face-down card");
                }
                else
                {
                    Console.WriteLine(source.playerName + " drew a " + card.name + " " + card.value + "!");
                }
                Dealer.add(card);
                return card;
            }
            else return null;
        }
        static Deck Turn()
        {
            //draws two cards from both decks, then displays the value and the winner
            var card1 = Draw(Player1);
            var card2 = Draw(Player2);
            if (card1 == null | card2 == null)
            {
                return null;
            }

            if (card1.value == card2.value)
            {
                return war();
            }
            else
            {
                if (card1.value > card2.value)
                {
                    return Player1;
                }
                else
                {
                    return Player2;
                }
            }
        }

        static Deck war()
        {

            string input;
            Card card1;
            Card card2;
            Console.WriteLine("WAR! ");
            for( var i = 0; i<3; i++)
                {
                Console.WriteLine("Type anything to draw a facedown card");
                input = Console.ReadLine();
                card1 = Draw(Player1, true);
                card2 = Draw(Player2, true);
                if (card1 == null | card2 == null)
                {
                    return null;
                }

            }

            Console.WriteLine("Type anything to draw");
            input = Console.ReadLine();
            card1 = Draw(Player1);
            card2 = Draw(Player2);

            if (card1 == null | card2 == null)
            {
                return null;
            }

            if (card1.value == card2.value)
            {
                return war();
            }
            else
            {
                if (card1.value > card2.value)
                {
                    return Player1;
                }
                else
                {
                    return Player2;
                }
            }
        }
    }
}
