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

        protected void OnEnable()
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

        }


    }
}

