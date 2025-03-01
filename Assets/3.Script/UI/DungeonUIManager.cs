using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUIManager : MonoBehaviour
{
    GameObject curUI;
    public GameObject MapCanvas;
    public GameObject Player;
    AbstractPlayerCharacter player;

    private void Start()
    {
        player = Player.GetComponent<AbstractPlayerCharacter>();
    }
    public void OnOffMap()
    {
        MapCanvas.SetActive(!MapCanvas.activeSelf);
    }
    public void OpenWholeDeck()
    {
        Debug.Log(player.deck.Count);
    }
}
