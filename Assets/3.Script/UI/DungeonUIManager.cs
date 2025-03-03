using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUIManager : MonoBehaviour
{
    //public AbstractPlayerCharacter Player;
    public GameObject MapPanel;
    public GameObject DeckPanel;
    public GameObject DeckUI;
    public GameObject DrawPileUI;
    public GameObject DiscardPileUI;
    public Text playerHp;
    public Text playerMoney;
    public Text deckCount;
    public Text drawCount;
    public Text discardCount;

    private void Start()
    {
        Player.Instance.OnHpChanged += UpdatePlayerHp;
        Player.Instance.OnMoneyChanged += UpdatePlayerMoney;
        Player.Instance.OnCardPileChenged += UpdatePlayerCardCount;
        UpdatePlayerMoney();
    }
    public void ToggleMap()
    {
        if (MapPanel.activeSelf)
        {
            MapPanel.SetActive(false);
        }
        else
        {
            DeckPanel.SetActive(false);
            MapPanel.SetActive(true);
        }
        //MapPanel.SetActive(!MapPanel.activeSelf);
    }
    public void ToggleDeck(string cardPile)
    {
        if (DeckPanel.activeSelf && DeckUI.activeSelf)
        {
            DeckPanel.SetActive(false);
        }
        else
        {
            MapPanel.SetActive(false);
            DeckPanel.SetActive(true);
            ChooseCardPile(cardPile);
        }
        //DeckPanel.SetActive(!DeckPanel.activeSelf);
    }
    void ChooseCardPile(string cardPile)
    {
        switch (cardPile)
        {
            case "Deck":
                DeckUI.SetActive(true);
                DrawPileUI.SetActive(false);
                DiscardPileUI.SetActive(false);
                break;
            case "DrawPile":
                DeckUI.SetActive(false);
                DrawPileUI.SetActive(true);
                DiscardPileUI.SetActive(false);
                break;
            case "DiscardPile":
                DeckUI.SetActive(false);
                DrawPileUI.SetActive(false);
                DiscardPileUI.SetActive(true);
                break;
        }
    }
    public void UpdatePlayerHp()
    {
        playerHp.text = $"{Player.Instance.CurHp}/{Player.Instance.MaxHp}";
    }
    public void UpdatePlayerMoney()
    {
        playerMoney.text = Player.Instance.Money.ToString();
    }
    public void UpdatePlayerCardCount()
    {
        deckCount.text = Player.Instance.Deck.Count.ToString();
        drawCount.text = Player.Instance.DrawPile.Count.ToString();
        discardCount.text = Player.Instance.DiscardPile.Count.ToString();
    }
}
