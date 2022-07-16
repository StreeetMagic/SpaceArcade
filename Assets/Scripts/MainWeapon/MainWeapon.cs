using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : MonoBehaviour
{
    [SerializeField] private Transform[] _barrels;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletsPerSecond = 1;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private List<Bullet> _pool = new List<Bullet>();

    private Coroutine _shooting;

    private bool _isShooting = true;

    public float BulletsPerSecond => _bulletsPerSecond;

    private void OnEnable()
    {
        Initialize();

        _shooting = StartCoroutine(Shooting());
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
        bullet.transform.SetPositionAndRotation(shootingPoint.position, shootingPoint.rotation);
        bullet.transform.SetParent(null);
    }

    private IEnumerator Shooting()
    {
        float cooldown = 1 / _bulletsPerSecond;
        bool isShooted;

        WaitForSeconds waitForSeconds = new WaitForSeconds(cooldown);
        yield return waitForSeconds;

        while (_isShooting)
        {
            if (_container.transform.childCount <= _barrels.Length)
            {
                yield return waitForSeconds;
            }
            else
            {
                for (int i = 0; i < _barrels.Length; i++)
                {
                    isShooted = false;

                    if (_barrels[i].gameObject.activeSelf)
                    {
                        while (isShooted == false)
                        {
                            if (TryGetObject(out Bullet bullet))
                            {
                                FireBullet(bullet, _barrels[i]);
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

    protected void SetBarrelStatus(int number, bool status)
    {
        _barrels[number].gameObject.SetActive(status);
    }

    protected void SetFireRate(float fireRate)
    {
        _bulletsPerSecond = fireRate;

        if (_shooting != null)
        {
            StopCoroutine(_shooting);
        }
        _shooting = StartCoroutine(Shooting());
    }
}


