using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : Buff
{
    protected override void Upgrade(Player.Player player)
    {
        player.GainHealth();
    }
}
