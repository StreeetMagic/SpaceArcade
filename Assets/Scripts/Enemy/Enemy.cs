using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;



namespace Enemy
{
    [RequireComponent(typeof(Movement))]

    public abstract class Enemy : MonoBehaviour
    {
        private int _collisionDamage = 1;
        private int _health = 5;
        
        private int _maxHealth = 5;

        public Movement Movement { get; private set; }


        private void Start()
        {
            Movement = GetComponent<Movement>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                player.TakeDamage(_collisionDamage);
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
            SetHealth();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
        }

        public void SetHealth()
        {
            _health = _maxHealth;
        }
    }
}
