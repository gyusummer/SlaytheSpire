using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : AbstractMortals
{
    public Action<Player> OnBattleStart;

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
    public Card selectedCard;
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
    //public Potion[] Potions { get; protected set; } = new Potion[3];
    public List<Relic> Relics { get; protected set; } = new List<Relic>();
    public List<Card> Deck {get; protected set; } = new List<Card>();
    public List<Card> DrawPile {get; protected set; } = new List<Card>();
    public List<Card> Hand {get; protected set; } = new List<Card>();
    public List<Card> DiscardPile {get; protected set; } = new List<Card>();

    public GameObject DeckUI;
    public GameObject DrawPileUI;
    public GameObject HandUI;
    public GameObject DiscardPileUI;
    public GameObject RelicUI;
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
                RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if(rayHit.transform != null)
                {
                    if (rayHit.transform.TryGetComponent(out AbstractMonster mob))
                    {
                        //Debug.Log(rayHit.transform.name);
                        CurEnergy -= selectedCard.cost;
                        selectedCard.Play(mob);
                        Discard(selectedCard);
                        ReleaseCard();
                    }
                }
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
    protected void GetRelic(Relic relic)
    {
        relic.GetEffect();
        Relics.Add(relic);
        relic.transform.SetParent(RelicUI.transform);
    }
    protected override void Die()
    {
        IsDead = true;
        if(TryGetComponent(out Animator anim))
        {
            anim.SetBool("isDead", true);
        }
    }
    public void ReleaseCard()
    {
        if(selectedCard != null)
        {
            selectedCard.Ui.BackToHandPanel();
            selectedCard = null;
        }
    }
    public void MakeDrawPile()
    {
        foreach (Card card in Deck)
        {
            AddCardTo(card, DrawPile);
        }
        Shuffle(DrawPile);
    }
    public void Draw(int n = 1)
    {
        if(n > 0) 
        {
            for(int k = 0; k < n; k++)
            {
                Draw();
            }
        }
    }
    void Shuffle(List<Card> cl)
    {
        for(int i = 0; i < cl.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(i, cl.Count);
            Card c = cl[i];
            cl[i] = cl[rnd];
            cl[rnd] = c;
        }
    }
    public void Draw()
    {
        if(DrawPile.Count <= 0)
        {
            RecycleDiscard();
        }
        Card c = DrawPile[0];
        DrawPile.Remove(c);
        Card h = AddCardTo(c, Hand, true);
        h.Ui.SetParent(HandUI.transform);
    }
    public void Discard(Card c)
    {
        if(Hand.Contains(c))
        {
            Hand.Remove(c);
            Card newC = AddCardTo(c, DiscardPile, true);
            newC.Ui.SetParent(DiscardPileUI.transform);
            //Destroy(c);
        }
    }
    public void DiscardAll()
    {
        for(int n = Hand.Count - 1; n >= 0; n--)
        {
            Discard(Hand[n]);
        }
    }
    public void RecycleDiscard()
    {
        for(int n = DiscardPile.Count - 1; n >= 0; n--)
        {
            //DiscardPile.Remove(DiscardPile[n]);
            Card newC = AddCardTo(DiscardPile[n], DrawPile, true);
            DiscardPile.RemoveAt(n);
            newC.Ui.SetParent(DrawPileUI.transform);
        }
        Shuffle(DrawPile);
    }
    protected Card AddCardTo(Card c, List<Card> pile,bool destroyOriginal = false)
    {
        Card replica = c.MakeReplica();
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
        OnBattleStart?.Invoke(this);
    }
    public void EndBattle()
    {
        isBattle = false;
        ReleaseCard();
        DestroyCardPile(DrawPile);
        DestroyCardPile(Hand);
        DestroyCardPile(DiscardPile);
        DungeonUIManager.Instance.UpdatePlayerCardCount();
    }
    void DestroyCardPile(List<Card> cards)
    {
        for (int n = cards.Count - 1; n >= 0; n--)
        {
            Destroy(cards[n].gameObject);
        }
        cards.Clear();
    }
}
