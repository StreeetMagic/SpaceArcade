using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MainWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _bulletsPerSecond = 1;
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        private bool _isShooting = true;
        private List<Bullet> _pool = new List<Bullet>();

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
                Bullet spawned = Instantiate(_bullet, _container.transform);
                spawned.gameObject.SetActive(false);
                _pool.Add(spawned);
            }
        }

        private void Shoot(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = _shootPoint.position;
        }

        private IEnumerator Shooting(float cooldown)
        {
            while (_isShooting)
            {
                if (TryGetObject(out Bullet bullet))
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

        protected bool TryGetObject(out Bullet result)
        {
            result = _pool[Random.Range(0, _pool.Count - 1)];
            return result.gameObject.activeSelf == false ? result != null : result == null;
        }
    }
}


