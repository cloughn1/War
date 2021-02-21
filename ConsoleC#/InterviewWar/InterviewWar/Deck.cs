using System;
using System.Collections.Generic;

public class Deck
{
	protected Queue<Card> Cards = new Queue<Card>();
    public string playerName;
    public Deck()
    {
    }
    public Deck(string name)
	{
        playerName = name;
	}

    public int hasRemaining()
    {
        return Cards.Count;
    }
	public void add(Card newCard)
    {
		Cards.Enqueue(newCard);
    }
	public Card Draw()
    {
		return Cards.Dequeue();
    }
}

public class Dealer : Deck
{
    public void Deck()
    {
        List<Card> hand = new List<Card>();
        for (var suit = 0; suit < 4; suit++)
        {
            for (var number = 2; number <= 14; number++)
            {
                Card newCard = new Card(number, suit);
                hand.Add(newCard);
            }
        }
        //shuffle list
        var rand = new Random();
        for (var cards = hand.Count-1; cards >= 0; cards--)
        {
            var swapValue = hand[cards];
            var swapPlace = rand.Next(0, hand.Count-1);
            hand[cards] = hand[swapPlace];
            hand[swapPlace] = swapValue;
        }
        for (var cards = hand.Count-1; cards >= 0; cards--)
        {
            Cards.Enqueue(hand[cards]);
        }
    }
    public void Deal(Deck target)
    {
        while (hasRemaining() > 0)
        {
            target.add(Draw());
        }
    }
    public void Deal(Deck player1, Deck player2)
    {
        while (hasRemaining() > 0)
        {
            player1.add(Draw());
            if(hasRemaining()>0)
            player2.add(Draw());
        }
    }
}
