using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemy
{   
    [RequireComponent(typeof(Movement))]

    public abstract class Enemy : MonoBehaviour
    {
        private Transform _parent;
        private Spawner _spawner;
        private float _collisionDamage = 1f;
        private float _health = 5f;
        private float _maxHealth = 5f;
        
        public Movement Movement { get; private set; }
        public int XPosition { get; protected set; }
       
        private void Awake()
        {
            Movement = GetComponent<Movement>();
            _parent = transform.parent;
            _spawner = _parent.transform.parent.GetComponent<Spawner>();
        }

        private void OnEnable()
        {
            
            XPosition = GetRandomXposition();

            while (transform.parent != null)
            {
                transform.SetParent(null);
            }
        }

        private void OnDisable()
        {
            Invoke(nameof(ReAttachParent), .001f);
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player.Player player))
            {
                player.TakeDamage(_collisionDamage);
                Die();
            }
        }

        private int GetRandomXposition()
        {
            int minX = 2;
            int maxX = 7;
            return Random.Range(minX, maxX);
        }

        private void ReAttachParent()
        {
            transform.SetParent(_parent.transform);
        }

        private void Die()
        {
            gameObject.SetActive(false);
            _health = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Die();
            }
        }
    }
}
