using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public GameObject deckCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected Queue<GameObject> Cards = new Queue<GameObject>();
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
    public virtual void add(GameObject newCard)
    {
        Cards.Enqueue(newCard);
        deckCount.GetComponent<Text>().text = " " +Cards.Count + " ";
    }
    public GameObject Draw()
    {
        deckCount.GetComponent<Text>().text = " " + (Cards.Count-1)+ " ";
        return Cards.Dequeue();
    }
}




