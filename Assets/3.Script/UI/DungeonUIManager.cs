using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUIManager : MonoBehaviour
{
    public GameObject MapCanvas;
    GameObject curUI;
    public void OnOffMap()
    {
        MapCanvas.SetActive(!MapCanvas.activeSelf);
    }
    public void OpenWholeDeck()
    {

    }
}
