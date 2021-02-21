using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	// Start is called before the first frame update
	// 2-14
	public int value;
	//clubs, spades, hearts, diamonds
	public string suit;
	//11 12 13 14 have name different from value
	public string cardName;

	public GameObject cardUI;

	public void set(int newValue, int newSuit)
	{
		value = newValue;
		switch (newSuit)
		{
			case 0:
				suit = "Diamonds";
				break;
			case 1:
				suit = "Spades";
				break;
			case 2:
				suit = "Clubs";
				break;
			case 3:
				suit = "Hearts";
				break;

		}
		if (value <= 10)
		{
			name = value + " of " + suit;
		}
		else
		{
			switch (value)
			{
				case 11:
					name = "Jack of " + suit;
					break;
				case 12:
					name = "Queen of " + suit;
					break;
				case 13:
					name = "King of " + suit;
					break;
				case 14:
					name = "Ace of " + suit;
					break;
			}
		}

	}
}
