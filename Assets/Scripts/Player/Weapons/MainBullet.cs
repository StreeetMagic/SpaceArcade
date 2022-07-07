using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class MainBullet : MonoBehaviour
    {
        private GameObject _container;
        private int _damage = 1;
        public float Speed { get; private set; } = 15;

        private void Awake()
        {
            _container = transform.parent.gameObject;
        }

        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            transform.SetParent(null);
        }

        private void OnDisable()
        {
            Invoke(nameof(ReAttachParent), .001f);
        }

        void ReAttachParent()
        {
            transform.SetParent(_container.transform);
        }

    }
}

