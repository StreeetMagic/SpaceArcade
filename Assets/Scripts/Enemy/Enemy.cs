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
        private int _collisionDamage = 1;
        private int _health = 5;
        private int _maxHealth = 5;
        
        public Movement Movement { get; private set; }
        public int XPosition { get; protected set; }
       
        private void Awake()
        {
            Movement = GetComponent<Movement>();
            _parent = transform.parent;
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
