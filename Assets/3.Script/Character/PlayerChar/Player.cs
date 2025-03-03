using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : AbstractMortals
{
    public static Player Instance = null;

    public delegate void CardAddedHandler(CardUI cardUi);
    public event CardAddedHandler OnCardAdded;
    public event Action OnMoneyChanged;
    private int money = 99;

    public int x = -1, y = -1;
    public int Money
    {
        get
        {
            return money;
        }
        protected set
        {
            money = value;
            OnMoneyChanged?.Invoke();
        }
    }
    public Potion[] Potions { get; protected set; } = new Potion[3];
    public List<AbstractRelic> Relics { get; protected set; } = new List<AbstractRelic>();
    public List<AbstractCard> Deck {get; protected set; } = new List<AbstractCard>();
    public List<AbstractCard> DrawPile {get; protected set; } = new List<AbstractCard>();
    public List<AbstractCard> DiscardPile {get; protected set; } = new List<AbstractCard>();
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //Debug.Log("Player Awake");
    }
    public virtual void AddCardToDeck(AbstractCard card)
    {
        Deck.Add(card);
        //Debug.Log("Ä«µå Ãß°¡µÊ");
        card.TryGetComponent(out CardUI cardUi);

        OnCardAdded?.Invoke(cardUi);
    }
}
