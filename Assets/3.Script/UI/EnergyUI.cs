using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Player player;
    public Text energyT;
    private void Update()
    {
        energyT.text = $"{player.CurEnergy}/{player.MaxEnergy}";
    }
}
