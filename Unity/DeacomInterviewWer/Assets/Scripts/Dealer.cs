using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dealer : Deck
{
    public GameObject cardData;
    public GameObject cardObject;
    public GameObject cardHiddenObject;
    private Queue<GameObject> cardStack = new Queue<GameObject>();
    public void Deck()
    {
        List<GameObject> hand = new List<GameObject>();
        for (var suit = 0; suit < 4; suit++)
        {
            for (var number = 2; number <= 14; number++)
            {
                var newCard = Instantiate(cardData,gameObject.transform);
                newCard.GetComponent<Card>().set(number, suit);
                hand.Add(newCard);
            }
        }
        //shuffle list
        for (var cards = hand.Count - 1; cards >= 0; cards--)
        {
            var swapValue = hand[cards];
            var swapPlace = (int)Random.Range(0, hand.Count - 1);
            hand[cards] = hand[swapPlace];
            hand[swapPlace] = swapValue;
        }
        for (var cards = hand.Count - 1; cards >= 0; cards--)
        {
            Cards.Enqueue(hand[cards]);
        }
    }
    private void visualize(GameObject info, bool hidden = false)
    {
        GameObject instance = cardObject;
        if (hidden)
        {
            instance = cardHiddenObject;
        }
        //cards always alternate between who is giving the card
        if(cardStack.Count % 2 == 1)
        {
            var obj = Instantiate(instance, new Vector3(8 - (cardStack.Count * .5f), 1.5f + (cardStack.Count *.05f), -6f), transform.rotation);
            obj.GetComponent<CardUi>().setCard(info.GetComponent<Card>().name, hidden);
            cardStack.Enqueue(obj);

        }
        else
        {
            var obj = Instantiate(instance, new Vector3(-8 + (cardStack.Count *.5f), 1.5f + (cardStack.Count * .05f), -10f), transform.rotation);
            obj.GetComponent<CardUi>().setCard(info.GetComponent<Card>().name, hidden);
            cardStack.Enqueue(obj);
        }
    }
    public void add(GameObject newCard, bool hidden = false)
    {
        visualize(newCard, hidden);
        Cards.Enqueue(newCard);
        deckCount.GetComponent<Text>().text = " " + Cards.Count + " ";
    }
    public void Deal(Deck target)
    {
        while (hasRemaining() > 0)
        {
            Destroy(cardStack.Dequeue());
            target.add(Draw());
        }
    }
    public void Deal(Deck player1, Deck player2)
    {
        while (hasRemaining() > 0)
        {
            player1.add(Draw());
            if (hasRemaining() > 0)
                player2.add(Draw());
        }
    }
}
