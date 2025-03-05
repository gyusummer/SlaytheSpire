using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningBlood : Relic
{
    int value = 6;
    private new void Awake()
    {
        name = "불타는 혈액";
        description = $"전투 시작시 체력 {value} 회복";
        imagePath = "Relics/burningBlood.png";
        base.Awake();
    }
    public override void GetEffect()
    {
        Player.Instance.OnBattleStart += Heal;
    }
    void Heal(Player p)
    {
        p.GetHeal(value);
    }
}
