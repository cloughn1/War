using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardUi : MonoBehaviour
{
    // Start is called before the first frame update
    public Text cardName;

    public void setCard(string input, bool hidden = false)
    {
        if (hidden)
        {
            cardName.text = "";
        }
        else
        {
            cardName.text = input;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
