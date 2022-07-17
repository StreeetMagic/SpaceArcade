using UnityEngine;
using System;

namespace Enemy
{
    [RequireComponent(typeof(Movement))]
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<float> HealthChanged;

        [SerializeField] private float _maxHealth;
        [SerializeField] private MainWeapon _mainWeapon;
        [SerializeField] private Transform _activeBulletPool;
        
        
        private float _currentHealth;
        private Transform _parent;
        private float _collisionDamage = 1f;

        public Movement Movement { get; private set; }
        public int XPosition { get; protected set; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
            
            Movement = GetComponent<Movement>();
            _parent = transform.parent;
        }

        public void SetAliveContainer(Transform parent)
        {
            transform.SetParent(parent);
        }

        private void OnEnable()
        {
            _mainWeapon.SetActiveBulletPool(_activeBulletPool);
            XPosition = GetRandomXposition();
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
            return UnityEngine.Random.Range(minX, maxX);
        }

        private void ReAttachParent()
        {
            transform.SetParent(_parent);
        }

        private void Die()
        {
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth / _maxHealth);
            gameObject.SetActive(false);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth / _maxHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void GetActiveBulletPool(Transform pool)
        {
            _activeBulletPool = pool;
        }

        
    }
}
