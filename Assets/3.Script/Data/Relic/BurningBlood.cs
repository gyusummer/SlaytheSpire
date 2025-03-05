using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningBlood : Relic
{
    int value = 6;
    private new void Awake()
    {
        name = "��Ÿ�� ����";
        description = $"���� ���۽� ü�� {value} ȸ��";
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
