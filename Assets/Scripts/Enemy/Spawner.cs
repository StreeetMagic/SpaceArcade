using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemies;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _inactivePool;
        [SerializeField] private ActiveEnemyPool _activePool;
        [SerializeField] private Transform _activeBulletPool;
        [SerializeField] private StatUpgrader _statUpgrader;

        private List<List<Enemy>> _pools = new List<List<Enemy>>();
        
        [field: SerializeField] public float DefaultSpawnCooldown { get; private set; } = 1;
        
        public float CurrentSpawnCooldown
        {
            get
            {
                return DefaultSpawnCooldown * _statUpgrader.EnemySpawnCurrent;
            }
        }



        [field: SerializeField] public int EnemiesAvaliable { get; private set; } = 1;
        [field: SerializeField] public int NewEnemyCooldown { get; private set; } = 30;
        public float ElapsedTime { get; private set; }

        private void Start()
        {
            FillPools();
            Initialize();
            StartCoroutine(NewEnemiesTimer());
        }


        private void Update()
        {
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= CurrentSpawnCooldown)
            {
                if (TryGetObject(out Enemy enemy))
                {
                    ElapsedTime = 0;
                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                }
            }
        }

        private void FillPools()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                _pools.Add(new List<Enemy>());
            }
        }

        protected void Initialize()
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                for (int j = 0; j < _enemies[i].MaxCount; j++)
                {
                    Enemy spawned = Instantiate(_enemies[i], _inactivePool.transform);
                    spawned.GetActiveBulletPool(_activeBulletPool);
                    spawned.GetComponent<Movement>().GetStatUpgrader(_statUpgrader);
                    spawned.gameObject.SetActive(false);
                    _pools[i].Add(spawned);
                }
            }
        }

        private bool TryGetObject(out Enemy result)
        {
            int randomEnemyPool = Random.Range(0, EnemiesAvaliable);
            int randomEnemy = Random.Range(0, _pools[randomEnemyPool].Count);
            result = _pools[randomEnemyPool][randomEnemy];
            return result.gameObject.activeSelf == false;
        }

        private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
        {
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            enemy.SetAliveContainer(_activePool);
        }

        private IEnumerator NewEnemiesTimer()
        {
            int enemyCount = _enemies.Count();
            WaitForSeconds cooldown = new WaitForSeconds(NewEnemyCooldown);
            yield return cooldown;

            while (EnemiesAvaliable < enemyCount)
            {
                EnemiesAvaliable++;
                yield return cooldown;
            }
        }
    }
}

