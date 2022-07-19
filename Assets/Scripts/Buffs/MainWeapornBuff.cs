using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapornBuff : Buff
{
    protected override void Upgrade(Player.Player player)
    {
        player.UpgradeMainWeapon();
    }
}
