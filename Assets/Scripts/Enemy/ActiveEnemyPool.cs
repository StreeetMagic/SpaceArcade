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
        Debug.Log("Противник умер и покинул пул");
    }

    /*
    [SerializeField] private List<Enemy.Enemy> _pool;

   
    
    public void AddEnemy(Enemy.Enemy enemy)
    {
        _pool.Add(enemy);
    }

    public void RemoveEnemy(Enemy.Enemy enemy)
    {
        _pool.Remove(enemy);
    }

    */
}
