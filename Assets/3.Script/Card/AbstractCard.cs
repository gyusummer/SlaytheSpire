using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCard : MonoBehaviour
{
    [HideInInspector] public CardTypes type { get; protected set;}
    [HideInInspector] public new string name {get; protected set;}
    [HideInInspector] public int cost {get; protected set;}
    [HideInInspector] public CardColors color {get; protected set;}
    [HideInInspector] public string description {get; protected set;}
    [HideInInspector] public string illuPath {get; protected set;}
    [HideInInspector] public Sprite illust {get; protected set;}
    [HideInInspector] public TargetTypes targetType {get; protected set;}
    [HideInInspector] public int mainValue {get; protected set;}
    [HideInInspector] public int subValue {get; protected set;}

    public abstract void Awake();
    public abstract void Init();
    public abstract void SetDescription();
    public abstract void PlayCard();
}
