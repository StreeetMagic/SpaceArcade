using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private GameObject _container;
        [SerializeField] private float _cooldown = 1f;
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _ActiveEnemyPool;
        [SerializeField] private Transform _ActiveEnemyBulletPool;

        private float _elapsedTime;
        private int _enemiesAvaliable = 1;
        private int _newEnemyCooldown = 0;
        private List<List<Enemy>> _pools = new List<List<Enemy>>();

        private void FillPools()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _pools.Add(new List<Enemy>());
            }
        }

        private void Start()
        {
            FillPools();
            Initialize();
            StartCoroutine(NewEnemiesTimer());
        }

        protected void Initialize()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                for (int j = 0; j < _capacity; j++)
                {
                    Enemy spawned = Instantiate(_enemies[i], _container.transform);
                    spawned.GetActiveBulletPool(_ActiveEnemyBulletPool);
                    spawned.gameObject.SetActive(false);
                    _pools[i].Add(spawned);
                }
            }
        }

        private bool TryGetObject(out Enemy result)
        {
            int randomEnemyPool = Random.Range(0, _enemiesAvaliable);
            int randomEnemy = Random.Range(0, _capacity);
            result = _pools[randomEnemyPool][randomEnemy];

            return result.gameObject.activeSelf == false;

        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _cooldown)
            {
                if (TryGetObject(out Enemy enemy))
                {
                    _elapsedTime = 0;
                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                }
            }
        }

        private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
        {
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            enemy.SetAliveContainer(_ActiveEnemyPool);
        }

        private IEnumerator NewEnemiesTimer()
        {
            int enemyCount = _enemies.Count();
            WaitForSeconds cooldown = new WaitForSeconds(_newEnemyCooldown);
            yield return cooldown;

            while (_enemiesAvaliable < enemyCount)
            {
                _enemiesAvaliable++;
                yield return cooldown;
            }
        }
    }
}

