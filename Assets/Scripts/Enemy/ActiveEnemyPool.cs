using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActiveEnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _enemyPosition;

    public event System.Action<Transform> EnemyDied;

    public void GetEnemyTransform(Transform position)
    {
        EnemyDied?.Invoke(position);
    }
}
