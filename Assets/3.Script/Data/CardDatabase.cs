using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CardDatabase", menuName = "ScriptableObjects / CardDatabase", order = 2)]
public class CardDatabase : ScriptableObject
{
    public List<CardData> cardList;
}
