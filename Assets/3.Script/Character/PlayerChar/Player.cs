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
    public int MaxEnergy { get; set; } = 3;
    public int CurEnergy { get; set; } = 3;
    public int DrawATurn { get; set; } = 5;

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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedCard != null)
        {
            if (selectedCard.targetType != TargetTypes.Single)
            {
                if (selectedCard.transform.position.y > 250)
                {
                    //Debug.Log("카드 사용");
                    CurEnergy -= selectedCard.cost;
                    selectedCard.Play();
                    Discard(selectedCard);
                    ReleaseCard();
                }
            }
            else
            {
                // UNDONE 싱글 타겟 카드 플레이
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selectedCard != null)
            {
                ReleaseCard();
            }
        }
    }
    public void ReleaseCard()
    {
        selectedCard.Ui.BackToHandPanel();
        selectedCard = null;
    }
    public void MakeDrawPile()
    {
        foreach (AbstractCard card in Deck)
        {
            AddCardTo(card, DrawPile);
        }
    }
    public void Draw(int n = 1)
    {
        if(n > 0) 
        {
            DrawPile.Remove(DrawPile[0]);
            AbstractCard c = AddCardTo(DrawPile[0], Hand, true);
            c.Ui.SetParent(HandUI.transform);
            Draw(n - 1);
        }
    }
    public void Discard(AbstractCard c)
    {
        if(Hand.Contains(c))
        {
            Hand.Remove(c);
            c = AddCardTo(c, DiscardPile, true);
            c.Ui.SetParent(DiscardPileUI.transform);
        }
    }
    public void DiscardAll()
    {
        foreach(AbstractCard c in Hand)
        {
            Discard(c);
        }
    }
    protected AbstractCard AddCardTo(AbstractCard c, List<AbstractCard> pile,bool destroyOriginal = false)
    {
        AbstractCard replica = c.MakeReplica();
        if (destroyOriginal) // TODO: 나중에 풀링으로 대체
        {
            Destroy(c.gameObject);
        }
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
        //Debug.Log(uI);
        //Debug.Log(targetUI);
        uI.SetParent(targetUI.transform);

        OnCardPileChenged?.Invoke();

        return replica;
    }
    public void GetReadyForTheNextBattle()
    {
        isBattle = true;
        MakeDrawPile();
    }
}
