using System.Collections;
using UnityEngine;

public class StatUpgrader : MonoBehaviour
{
    [field:Header("Enemy Move Speed")]
    [field: SerializeField] public float MoveSpeedDefault { get; private set; } = .1f;
    [field: SerializeField] public float MoveSpeedDelta { get; private set; } = .1f;
    [field: SerializeField] public float MoveSpeedMax { get; private set; } = 2f;
    [field: SerializeField] public float MoveSpeedChangeCooldown { get; private set; } = 30;
    [field: SerializeField] public float MoveSpeedCurrent { get; private set; }

    [field: Header("Spawner")]

    [field: SerializeField] public float EnemySpawnDefault { get; private set; } = 10f;
    [field: SerializeField] public float EnemySpawnDelta { get; private set; } = .1f;
    [field: SerializeField] public float EnemySpawnMax { get; private set; } = .5f;
    [field: SerializeField] public float EnemySpawnChangeCooldown { get; private set; } = 5;
    [field: SerializeField] public float EnemySpawnCurrent { get; private set; } = .1f;


    private void OnEnable()
    {
        MoveSpeedCurrent = MoveSpeedDefault;
        EnemySpawnCurrent = EnemySpawnDefault;
        StartCoroutine(IncreaseMoveSpeedMultiplier());
        StartCoroutine(IncreaseSpawnRate());
    }

    private IEnumerator IncreaseMoveSpeedMultiplier()
    {
        WaitForSeconds cooldown = new WaitForSeconds(MoveSpeedChangeCooldown);

        while (MoveSpeedCurrent <= MoveSpeedMax)
        {
            yield return cooldown;
            MoveSpeedCurrent += MoveSpeedDelta;

            if (MoveSpeedCurrent > MoveSpeedMax)
            {
                MoveSpeedCurrent = MoveSpeedMax;
            }
            yield return null;
        }
    }

    private IEnumerator IncreaseSpawnRate()
    {
        WaitForSeconds cooldown = new WaitForSeconds(EnemySpawnChangeCooldown);

        while (EnemySpawnCurrent >= EnemySpawnMax)
        {
            yield return cooldown;
            EnemySpawnCurrent -= EnemySpawnDelta;

            if (EnemySpawnCurrent < EnemySpawnMax)
            {
                EnemySpawnCurrent = EnemySpawnMax;
            }
            yield return null;
        }
    }
}
