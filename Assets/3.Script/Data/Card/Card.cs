using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public event Action OnCardUpdated;
    [HideInInspector] public CardTypes type { get; protected set;}
    private new string name;
    [HideInInspector] public string Name
    {
        get { return name; }
        protected set
        {
            name = value;
            OnCardUpdated?.Invoke();
        }
    }
    [HideInInspector] public int cost {get; protected set;}
    [HideInInspector] public CardColors color {get; protected set;}
    private string description;
    [HideInInspector] public string Description
    {
        get { return description; }
        protected set
        {
            description = value;
            OnCardUpdated?.Invoke();
        }
    }
    [HideInInspector] public string illuPath {get; protected set;}
    [HideInInspector] public Sprite illust {get; protected set;}
    [HideInInspector] public TargetTypes targetType {get; protected set;}
    [HideInInspector] public int mainValue {get; protected set;}
    [HideInInspector] public int subValue {get; protected set;}
    private int indicatedValue;
    [HideInInspector] public int IndicatedValue
    {
        get { return indicatedValue; }
        protected set
        {
            indicatedValue = value;
            OnCardUpdated?.Invoke();
        }
    }
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
    public abstract void PredictValue();
    public virtual void PredictValue(Monster target) { }
    public virtual void Play() { }
    public virtual void Play(Mortals target) { }
    public virtual void Play(List<Mortals> targets) { }
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
