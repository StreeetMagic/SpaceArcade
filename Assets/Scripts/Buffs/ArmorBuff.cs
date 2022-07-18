using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBuff : Buff
{
    protected override void Upgrade(Player.Player player)
    {
        player.GainArmor();
    }
}
