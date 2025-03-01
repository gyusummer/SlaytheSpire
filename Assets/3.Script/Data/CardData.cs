using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects / Card", order = 1)]
public class CardData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private CardTypes _cardType;
    public CardTypes CardType => _cardType;
    [SerializeField] private int _baseCost;
    public int BaseCost => _baseCost;
    [SerializeField] private int _upgCost;
    public int UpgCost => _upgCost;
    [SerializeField] private CardColors _color;
    public CardColors Color => _color;
    [SerializeField] Sprite _illust;
    public Sprite Illust => _illust;

    public List<Effect> Effects;
}
