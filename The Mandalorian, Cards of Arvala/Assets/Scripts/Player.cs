using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Card[] cards;
    [HideInInspector] public int numCards = 0;
    private const int deckSize = 1;
    [HideInInspector] public Card[] fieldCards;
    [HideInInspector] public int fieldnumCards = 0;
    [HideInInspector] public const int sizeFieldCards = 3;
    [HideInInspector] public Card[] handCards;
    [HideInInspector] public int handnumCards = 0;
    // Start is called before the first frame update
    void Start()
    {
        fieldCards = new Card[sizeFieldCards];
        cards = new Card[deckSize];
        handCards = new Card[deckSize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddCard(Card card)
    {
        for (int i = 0; i < numCards; ++i)
        {
            if (cards[i] == card)
                return false;
        }
        cards[++numCards] = card;
        handCards[++handnumCards] = card;
        return true;
    }

    public bool PlayCard(Card card)
    {
        if(fieldnumCards >= sizeFieldCards)
            return true;

        for (int i = 0; i < numCards; ++i)
        {
            if (handCards[i] == card)
            {
                 handCards[i] = handCards[handnumCards];
                --handnumCards;

                fieldCards[++fieldnumCards] = card;
                return true;
            }
        }
        return false;
    }
}
