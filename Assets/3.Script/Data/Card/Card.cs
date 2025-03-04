using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
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
    private CardUI ui;
    [HideInInspector]
    public CardUI Ui
    {
        get
        {
            if(ui == null)
            {
                TryGetComponent(out ui);
            }
            return ui;
        }
    }
    public abstract void Awake();
    public abstract void Init();
    public abstract void SetDescription();
    //public abstract int PredictValue();
    public virtual void Play() { }
    public virtual void Play(AbstractMortals target) { }
    public virtual void Play(List<AbstractMortals> targets) { }
    public virtual Card MakeReplica()
    {
        return (Card)Instantiate(gameObject);
    }

    public static explicit operator Card(GameObject v)
    {
        v.TryGetComponent(out Card c);
        return c;
    }
}
