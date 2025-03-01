using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    DungeonUIManager ui;
    Text[] textBoxes;
    Text descriptT;
    Text typeT;
    Text nameT;
    Text costT;
    private void Start()
    {
        ui = FindAnyObjectByType<DungeonUIManager>();
        transform.SetParent(ui.transform, false);
        if (TryGetComponent(out Card c))
        {
            RawImage cardIllust = GetComponentInChildren<RawImage>();
            cardIllust.texture = c.illust.texture;
            textBoxes = GetComponentsInChildren<Text>();
            descriptT = textBoxes[0];
            typeT = textBoxes[1];
            nameT = textBoxes[2];
            costT = textBoxes[3];
            descriptT.text = c.description;
            typeT.text = Enum.GetName(typeof(CardTypes),c.type);
            nameT.text = c.name;
            costT.text = c.curCost.ToString();
        }
    }
}
