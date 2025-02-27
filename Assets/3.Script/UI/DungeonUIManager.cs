using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUIManager : MonoBehaviour
{
    public GameObject MapScroll;
    GameObject curUI;
    public void OnOffMap()
    {
        MapScroll.SetActive(!MapScroll.activeSelf);
    }
    public void OpenWholeDeck()
    {

    }
}
