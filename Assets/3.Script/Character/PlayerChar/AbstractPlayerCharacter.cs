using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbstractPlayerCharacter : AbstractMortals
{
    public delegate void CardAddedHandler(CardUI cardUi);
    public event CardAddedHandler OnCardAdded;
    public int money { get; protected set; } = 99;
    public Potion[] potions { get; protected set; } = new Potion[3];
    public List<AbstractRelic> relics { get; protected set; } = new List<AbstractRelic>();
    public List<AbstractCard> deck {get; protected set; } = new List<AbstractCard>();
    public List<AbstractCard> drawPile {get; protected set; } = new List<AbstractCard>();
    public List<AbstractCard> DiscardPile {get; protected set; } = new List<AbstractCard>();
    public virtual void AddCardToDeck(AbstractCard card)
    {
        deck.Add(card);
        //Debug.Log("Ä«µå Ãß°¡µÊ");
        card.TryGetComponent(out CardUI cardUi);

        OnCardAdded?.Invoke(cardUi);
    }
}
