using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    DungeonUIManager ui;
    RawImage cardIllust;
    Text descriptT;
    Text typeT;
    Text nameT;
    Text costT;
    private void Start()
    {
        ui = FindAnyObjectByType<DungeonUIManager>();
        transform.SetParent(ui.transform, false);
        if (TryGetComponent(out AbstractCard c))
        {
            cardIllust = GetComponentInChildren<RawImage>();

            Addressables.LoadAssetAsync<Texture2D>(c.illuPath).Completed += ChangeIllust;
            Text[] textBoxes = GetComponentsInChildren<Text>();
            descriptT = textBoxes[0];
            typeT = textBoxes[1];
            nameT = textBoxes[2];
            costT = textBoxes[3];
            descriptT.text = c.description;
            typeT.text = Enum.GetName(typeof(CardTypes),c.type);
            nameT.text = c.name;
            costT.text = c.cost.ToString();
        }
    }
    void ChangeIllust(AsyncOperationHandle<Texture2D> op)
    {
        if (op.Result == null)
        {
            Debug.LogError("no sprites here.");
            return;
        }
        cardIllust.texture = op.Result;
    }
}
