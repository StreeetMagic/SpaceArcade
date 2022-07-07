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
        public float Speed { get; protected set; } = 10;

        private void Awake()
        {
            _container = this.transform.parent.gameObject;
        }   

        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        public void SetParent()
        {
            transform.SetParent(_container.transform);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(_damage);
                gameObject.SetActive(false);
               // transform.SetParent(_container.transform);
            }
        }
    }
}

