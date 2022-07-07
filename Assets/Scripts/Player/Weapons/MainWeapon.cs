using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MainWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private MainBullet _bullet;
        [SerializeField] private float _bulletsPerSecond = 1;
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        public GameObject Container { get { return _container; } }

        private bool _isShooting = true;
        private List<MainBullet> _pool = new List<MainBullet>();

        private void Start()
        {
            Initialize();
            float cooldown = 1 / _bulletsPerSecond;
            StartCoroutine(Shooting(cooldown));
        }

        private void Initialize()
        {
            for (int i = 0; i < _capacity; i++)
            {
                MainBullet spawned = Instantiate(_bullet, _container.transform);
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }

        private void Shoot(MainBullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.SetParent(null);
            bullet.transform.position = _shootPoint.position;
        }

        private IEnumerator Shooting(float cooldown)
        {
            while (_isShooting)
            {
                if (TryGetObject(out MainBullet bullet))
                {
                    Shoot(bullet);
                    yield return new WaitForSeconds(cooldown);
                }
                else
                {
                    yield return null;
                }
            }
        }

        protected bool TryGetObject(out MainBullet result)
        {
            result = _pool[Random.Range(0, _pool.Count - 1)];
            return result.gameObject.activeSelf == false ? result != null : result == null;
        }
    }
}


