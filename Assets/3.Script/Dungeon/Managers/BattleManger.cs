using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleManger : Singleton<BattleManger>
{
    public List<AbstractMonster> monsters = new List<AbstractMonster>();
    public int turn = 0;
    public bool isPlayerTurn = false;
    public GameObject hpBar;
    public GameObject hpBarPanel;
    public void PrepareBattle(AbstractRoom room)
    {
        Player.Instance.GetReadyForTheNextBattle();
        isPlayerTurn = true;
        foreach(GameObject obj in room.contents)
        {
            obj.TryGetComponent(out AbstractMonster mob);
            GameObject _hpBar = Instantiate(hpBar, hpBarPanel.transform);
            _hpBar.TryGetComponent(out HpBar bar);
            bar.Init(obj);
            monsters.Add(mob);
        }
        turn = 0;
        PreparePlayerTurn();
    }
    public void PreparePlayerTurn()
    {
        Player.Instance.CurEnergy = Player.Instance.MaxEnergy;
        Player.Instance.Draw(Player.Instance.DrawATurn);
    }
    public void EndPlayerTurn()
    {
        Player.Instance.DiscardAll();
        ActMonsters();
    }
    public void ActMonsters()
    {
        foreach(AbstractMonster mob in monsters)
        {
            mob.Behave();
        }
        PreparePlayerTurn();
    }
}