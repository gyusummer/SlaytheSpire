using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public static DungeonMaster Instance = null;
    AbstractRoom[,] dungeon;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GenerateDungeon()
    {
        dungeon = new AbstractRoom[7, 15];
        int numofStartpoint = Random.Range(2, 5);
        for (int i = 0; i <= numofStartpoint; i++)
        {

        }
    }
}
