using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleManger : Singleton<BattleManger>
{
    public List<Monster> monsters = new List<Monster>();
    public int turn = 0;
    public bool isPlayerTurn = false;
    bool isOnGoing = false;
    public GameObject BattleUI;
    public GameObject hpBar;
    public GameObject hpBarPanel;
    private void Update()
    {
        if (isOnGoing)
        {
            foreach (Monster mob in monsters)
            {
                if (!mob.IsDead) return;
            }
            EndBattle();
        }
    }
    public void PrepareBattle(Room room)
    {
        foreach(GameObject obj in room.contents)
        {
            obj.TryGetComponent(out Monster mob);
            GameObject _hpBar = Instantiate(hpBar, hpBarPanel.transform);
            _hpBar.TryGetComponent(out HpBar bar);
            bar.Init(obj);
            monsters.Add(mob);
        }
        Player.Instance.GetReadyForTheNextBattle();
        isOnGoing = true;
        BattleUI.SetActive(true);
        turn = 0;
        PreparePlayerTurn();
    }
    public void PreparePlayerTurn()
    {
        isPlayerTurn = true;
        turn++;
        Player.Instance.CurEnergy = Player.Instance.MaxEnergy;
        Player.Instance.LoseBlock(Player.Instance.Block);
        Player.Instance.Draw(Player.Instance.DrawATurn);
    }
    public void EndPlayerTurn()
    {
        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            Player.Instance.EndTurn();
            ActMonsters();
        }
    }
    public void ActMonsters()
    {
        foreach(Monster mob in monsters)
        {
            mob.LoseBlock(mob.Block);
            mob.Behave();
            mob.EndTurn();
        }
        PreparePlayerTurn();
    }
    void EndBattle()
    {
        isOnGoing = false;
        isPlayerTurn = false;
        BattleUI.SetActive(false);
        Player.Instance.EndBattle();
    }
    public static bool FindTarget()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (rayHit.transform != null)
        {
            if (rayHit.transform.TryGetComponent(out Monster mob))
            {
                return true;
            }
        }
        return false;
    }
    public static bool FindTarget(out Monster target)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (rayHit.transform != null)
        {
            if (rayHit.transform.TryGetComponent(out Monster mob))
            {
                target = mob;
                return true;
            }
        }
        target = null;
        return false;
    }
}