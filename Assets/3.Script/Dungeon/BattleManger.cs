using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleManger : Singleton<BattleManger>
{
    public List<AbstractMonster> monsters = new List<AbstractMonster>();
    public int turn = 0;
    public bool isPlayerTurn = false;
    public void StartBattle(AbstractRoom room)
    {
        Player.Instance.GetReadyForTheNextBattle();
        isPlayerTurn = true;
        foreach(GameObject obj in room.contents)
        {
            obj.TryGetComponent(out AbstractMonster mob);
            monsters.Add(mob);
        }
        turn = 0;
    }
}