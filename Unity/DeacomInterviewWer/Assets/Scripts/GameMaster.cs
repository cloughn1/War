using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public Deck Player1;
    public Deck Player2;
    public Dealer Dealer;
    private Deck result;
    public GameObject uiDrawButton;
    public GameObject uiDrawEmptyButton;
    public GameObject uiNextTurnButton;
    public GameObject uiEventText;
    private int uiCooldown;
    private int warCount;
    void Start()
    {
        Dealer.Deck();
        Dealer.Deal(Player1, Player2);
        setUiButtons(uiDrawButton);
        setText("Game has begun");
    }
    private void setUiButtons(GameObject button)
    {
        uiDrawButton.SetActive(false);
        uiDrawEmptyButton.SetActive(false);
        uiNextTurnButton.SetActive(false);
        if(button != null)
        button.SetActive(true);
    }
    private void setText(string text)
    {
        uiEventText.GetComponent<Text>().text = text;
        uiEventText.SetActive(true);
        Invoke("clearText", 1f);
        uiCooldown++;
    }
    private void clearText()
    {
        uiCooldown--;
        //since buttons can be hit in rapid succession, this ensures that the text only dissapears once all setTexts events expire
        if (uiCooldown <= 0)
        {
            uiEventText.SetActive(false);
        }
    }
    public void Play()
    {

        Debug.Log("Play");
        result = Turn();
        if (result == null) return; //either victory or a war
        setText(result.playerName + " has won the draw!");
        var win = winner();
        if (win != null)
        {
            won(win);
        }
        setUiButtons(uiNextTurnButton);
    }
    public void won(Deck winner)
    {
        setUiButtons(null);
        setText(winner.playerName + " has won the game!");
        return;
    }
    public void NextTurn()
    {
        if(result != null)
        {
            Dealer.Deal(result);
        }
        setUiButtons(uiDrawButton);
    }
    public Deck winner()
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
    private GameObject Draw(Deck source, bool hidden = false)
    {

        Debug.Log("Draw");
        if (source.hasRemaining() > 0)
        {
            var card = source.Draw();
            Dealer.add(card,hidden);
            return card;
        }
        else return null;
    }
    private Deck Turn()
    {
        Debug.Log("Turn");
        //draws two cards from both decks, then displays the value and the winner
        var card1 = Draw(Player1);
        var card2 = Draw(Player2);
        if (card1 == null | card2 == null)
        {
            Debug.Log("null cards");
            return null;
        }

        if (card1.GetComponent<Card>().value == card2.GetComponent<Card>().value)
        {
            return war();
        }
        else
        {
            if (card1.GetComponent<Card>().value > card2.GetComponent<Card>().value)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }
    }
    public void warDraw()
    {
       
        var card1 = Draw(Player1, true);
        var card2 = Draw(Player2, true);
        warCount++;
        if (card1 == null | card2 == null)
        {
            if(winner()!= null) won(winner());
        }
        else if(warCount == 3)
        {
            setUiButtons(uiDrawButton);
        }
    }
    private Deck war()
    {
        setText("War!");
        setUiButtons(uiDrawEmptyButton);
        warCount = 0;
        return null;
    }
}

