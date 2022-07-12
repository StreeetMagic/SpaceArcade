using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MainWeapon : MonoBehaviour
    {
        [SerializeField] private Transform[] _shootPoints;
        [SerializeField] private MainBullet _bullet;
        [SerializeField] private float _bulletsPerSecond = 1;
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        [SerializeField] private List<MainBullet> _pool = new List<MainBullet>();

        public GameObject Container { get { return _container; } }

        private bool _isShooting = true;

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

        private void FireBullet(MainBullet bullet, Transform shootingPoint)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = shootingPoint.position;
            bullet.transform.SetParent(null);
        }

        private IEnumerator Shooting(float cooldown)
        {
            bool isShooted;

            WaitForSeconds waitForSeconds = new WaitForSeconds(cooldown);
            yield return waitForSeconds;
            
            while (_isShooting)
            {
                if (_container.transform.childCount <= _shootPoints.Length)
                {
                    yield return waitForSeconds;
                }
                else
                {
                    for (int i = 0; i < _shootPoints.Length; i++)
                    {
                        isShooted = false;

                        if (_shootPoints[i].gameObject.activeSelf)
                        {
                            while (isShooted == false)
                            {
                                if (TryGetObject(out MainBullet bullet))
                                {
                                    FireBullet(bullet, _shootPoints[i]);
                                    isShooted = true;
                                }
                            }
                        }
                    }
                    yield return waitForSeconds;
                }
            }
        }

        protected bool TryGetObject(out MainBullet result)
        {
            result = _pool[Random.Range(0, _pool.Count)];
            return result.gameObject.activeSelf == false ? result != null : result == null;
        }
    }
}


