using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayerCharacter : AbstractMortals
{
    protected int money = 99;
    protected Potion[] potions = new Potion[3];
    protected List<AbstractRelic> relics;
    public List<Card> deck;
    protected List<Card> drawPile;
    protected List<Card> DiscardPile;
}
