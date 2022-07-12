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

        private float _elapsedTime;
        private List<Enemy> _pool = new List<Enemy>();

        private void Start()
        {
            Initialize();
        }

        protected void Initialize()
        {
            for (int i = 0; i < _capacity; i++)
            {
                Enemy spawned = Instantiate(_enemies[Random.Range(0, _enemies.Length)], _container.transform);
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out Enemy result)
        {
            result = _pool[Random.Range(0, _pool.Count - 1)];
            return result.gameObject.activeSelf == false ? result != null : result == null;
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
        }
    }
}

