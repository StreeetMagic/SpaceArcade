public class ArmorBuff : Buff
{
    protected override void Upgrade(Player.Player player)
    {
        player.GainArmor();
    }
}
