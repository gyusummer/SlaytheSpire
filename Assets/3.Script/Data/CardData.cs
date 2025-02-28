using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private int _baseEffValue;
    public int BaseEffValue => _baseEffValue;
    [SerializeField] private int _upgEffValue;
    public int UpgEffValue => _upgEffValue;
    [SerializeField] private CardColors _color;
    public CardColors Color => _color;
    [SerializeField] private TargetTypes _targetType;
    public TargetTypes TargetType => _targetType;
    [SerializeField] private string _description;
    public string Description => _description;
    [SerializeField] Sprite _illust;
    public Sprite Illust => _illust;
}
