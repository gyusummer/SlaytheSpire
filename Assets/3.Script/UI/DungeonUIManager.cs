using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUIManager : MonoBehaviour
{
    public AbstractPlayerCharacter Player;
    public GameObject MapPanel;
    public GameObject DeckPanel;
    public GameObject DeckContent;
    public Text playerHp;
    public Text playerMoney;
    public Text deckCount;

    private void Start()
    {
        Player.OnCardAdded += AddCardToPlayerDeck;
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
    public void ToggleDeck()
    {
        if (DeckPanel.activeSelf)
        {
            DeckPanel.SetActive(false);
        }
        else
        {
            MapPanel.SetActive(false);
            DeckPanel.SetActive(true);
        }
        //DeckPanel.SetActive(!DeckPanel.activeSelf);
    }
    public void AddCardToPlayerDeck(CardUI cardUi)
    {
        //Debug.Log("카드 추가 이벤트 호출됨");
        cardUi.SetParent(DeckContent.transform);
        cardUi.transform.localScale *= 0.45f;
    }
    public void UpdatePlayerHp()
    {
        playerHp.text = Player.curHp.ToString();
    }
    public void UpdatePlayerMoney()
    {
        playerMoney.text = Player.money.ToString();
    }
    public void UpdatePlayerDeckCount()
    {
        deckCount.text = Player.deck.Count.ToString();
    }
}
