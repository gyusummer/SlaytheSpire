using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : Room
{
    private new void Awake()
    {
        base.Awake();
    }
    private new void Start()
    {
        base.Start();
        roomType = RoomType.Battle;
        int n = Random.Range(1, 3);
        for(int k = 0; k < n; k++)
        {
            AddMonster();
        }
    }
    void AddMonster()
    {
        contents.Add(MonsterLibrary.Instance.Slime_Prefabs);
    }
}
