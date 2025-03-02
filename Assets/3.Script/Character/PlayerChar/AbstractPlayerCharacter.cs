using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayerCharacter : AbstractMortals
{
    protected int money = 99;
    protected Potion[] potions = new Potion[3];
    protected List<AbstractRelic> relics;
    public List<AbstractCard> deck;
    protected List<AbstractCard> drawPile;
    protected List<AbstractCard> DiscardPile;
}
