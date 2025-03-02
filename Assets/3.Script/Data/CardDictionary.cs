using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDictionary : MonoBehaviour
{
	public Dictionary<RedCommonCard, Type> redCommonCards;
    private void Awake()
    {
		redCommonCards = new Dictionary<RedCommonCard, Type>
        {
            {RedCommonCard.Strike,typeof(Strike)},
            {RedCommonCard.Defend,typeof(Defend)},
            {RedCommonCard.Bash,typeof(Bash)},
        };
    }
}
