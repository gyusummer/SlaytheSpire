using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicMaker : Singleton<RelicMaker>
{
    [SerializeField] GameObject relicPrefab;
    public Relic MakeARelic(int id = -1)
    {
        if(id == -1)
        {
            id = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Relics)).Length);
        }
        Type t = RelicDictionary.relicDict[(Relics)id];
        GameObject g = Instantiate(relicPrefab);
        Relic r = g.AddComponent(t) as Relic;
        return r;
    }
}
