using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Card[] cards;
    [HideInInspector] public int numRegisteredCards = 0;
    private const int deckSize = 1;
    [HideInInspector] public Card[] fieldCards;
    [HideInInspector] public int fieldnumCards = 0;
    [HideInInspector] public const int sizeFieldCards = 3;
    [HideInInspector] public Card[] handCards;
    [HideInInspector] public int handnumCards = 0;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: ?? (array C#)
        fieldCards = new Card[sizeFieldCards];
        cards = new Card[deckSize];
        handCards = new Card[deckSize];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AllDeckDrawed()
    {
        return numRegisteredCards >= deckSize;
    }
    public bool FullHand()
    {
        return handnumCards >= deckSize;
    }
    public bool EmptyHand()
    {
        return handnumCards <= 0;
    }
    public bool AddCard(Card card)
    {
        if (FullHand() || AllDeckDrawed())
            return true;

        for (int i = 0; i < numRegisteredCards; ++i)
        {
            if (cards[i] == card)
                return false;
        }
        cards[(++numRegisteredCards) - 1] = card;
        handCards[(++handnumCards) - 1] = card;
        return true;
    }

    public bool EmptyField()
    {
        return fieldnumCards <= 0;
    }
    public bool FullField()
    {
        return fieldnumCards >= sizeFieldCards;
    }
    public bool PlayCard(Card card)
    {
        if(FullField())
            return true;

        for (int i = 0; i < handnumCards; ++i)
        {
            if (handCards[i] == card)
            {
                 handCards[i] = handCards[handnumCards-1];
                --handnumCards;

                fieldCards[(++fieldnumCards)-1] = card;
                return true;
            }
        }
        return false;
    }
}
