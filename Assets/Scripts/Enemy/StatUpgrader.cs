using System.Collections;
using UnityEngine;

public class StatUpgrader : MonoBehaviour
{
    [field:Header("Move Speed")]
    [field: SerializeField] public float MoveSpeedDefaultValue { get; private set; } = .1f;
    [field: SerializeField] public float MoveSpeedMultiplier { get; private set; }
    [field: SerializeField] public float MaxMoveSpeedMultiplier { get; private set; } = 2f;
    [field: SerializeField] public float MoveSpeedMultiplierDelta { get; private set; } = .1f;
    [field: SerializeField] public float MoveSpeedCooldown { get; private set; } = 30;

    private void OnEnable()
    {
        MoveSpeedMultiplier = MoveSpeedDefaultValue;
        StartCoroutine(IncreaseMoveSpeedMultiplier());
    }

    private IEnumerator IncreaseMoveSpeedMultiplier()
    {
        WaitForSeconds cooldown = new WaitForSeconds(MoveSpeedCooldown);

        while (MoveSpeedMultiplier <= MaxMoveSpeedMultiplier)
        {
            yield return cooldown;
            MoveSpeedMultiplier += MoveSpeedMultiplierDelta;

            if (MoveSpeedMultiplier > MaxMoveSpeedMultiplier)
            {
                MoveSpeedMultiplier = MaxMoveSpeedMultiplier;
            }
            yield return null;
        }
    }

}
