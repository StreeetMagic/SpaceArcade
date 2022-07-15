using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBullet : Bullet
    {
        protected override void OnEnable()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(Damage);
                gameObject.SetActive(false);
            }
        }
        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

    }
}

