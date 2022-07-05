using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        private int _damage = 1;

        public float Speed { get; protected set; } = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}


