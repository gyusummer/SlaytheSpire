using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : AbstractMortals
{
    public static Player Instance = null;

    public event Action OnCardPileChenged;
    public event Action OnMoneyChanged;
    private int money = 99;

    public bool isBattle;
    public int x = -1, y = -1;
    public AbstractRoom curRoom;
    public AbstractCard selectedCard;
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
    public List<AbstractCard> Hand {get; protected set; } = new List<AbstractCard>();
    public List<AbstractCard> DiscardPile {get; protected set; } = new List<AbstractCard>();

    public GameObject DeckUI;
    public GameObject DrawPileUI;
    public GameObject HandUI;
    public GameObject DiscardPileUI;
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
    public void MakeDrawPile()
    {
        foreach (AbstractCard card in Deck)
        {
            AddCardTo(card, DrawPile);
        }
    }
    protected void AddCardTo(AbstractCard c, List<AbstractCard> pile,bool destroyOriginal = false)
    {
        AbstractCard replica = c.MakeReplica();
        //if (destroyOriginal) // TODO: ���߿� Ǯ������ ��ü
        //{
        //    Destroy(c.gameObject);
        //}
        pile.Add(replica);
        replica.TryGetComponent(out CardUI uI);
        GameObject targetUI = null;
        if(pile == Deck)
        {
            targetUI = DeckUI;
        }
        else if(pile == DrawPile)
        {
            targetUI = DrawPileUI;
        }
        else if (pile == Hand)
        {
            targetUI = HandUI;
        }
        else if(pile == DiscardPile)
        {
            targetUI = DiscardPileUI;
        }
        Debug.Log(targetUI);
        uI.SetParent(targetUI.transform);

        OnCardPileChenged?.Invoke();
    }
    public void GetReadyForTheNextBattle()
    {
        isBattle = true;
        MakeDrawPile();
    }
}
