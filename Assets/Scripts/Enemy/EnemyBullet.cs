using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBullet : Bullet
    {
        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        private void OnEnable()
        {
            Speed = 5;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                player.TakeDamage(Damage);
                gameObject.SetActive(false);
            }

            if (collision.TryGetComponent(out Bullet bullet))
            {
                gameObject.SetActive(false);
                bullet.gameObject.SetActive(false);
            }
        }


    }
}

