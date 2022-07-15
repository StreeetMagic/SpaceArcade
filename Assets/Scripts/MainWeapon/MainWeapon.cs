using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : MonoBehaviour
{
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletsPerSecond = 1;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private List<Bullet> _pool = new List<Bullet>();

    private bool _isShooting = true;

    private void OnEnable()
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

    private void FireBullet(Bullet bullet, Transform shootingPoint)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shootingPoint.position;
        bullet.transform.rotation = shootingPoint.rotation;
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
                            if (TryGetObject(out Bullet bullet))
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

    protected bool TryGetObject(out Bullet result)
    {
        result = _pool[Random.Range(0, _pool.Count)];
        return result.gameObject.activeSelf == false ? result != null : result == null;
    }
}


