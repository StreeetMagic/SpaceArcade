using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class MainBullet : MonoBehaviour
    {
        private GameObject _parent;
        private int _damage = 1;
        public float Speed { get; private set; } = 15;

        private void Awake()
        {
            _parent = transform.parent.gameObject;
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
            while (transform.parent != null)
            {
                transform.SetParent(null);
            }
        }

        private void OnDisable()
        {
            Invoke(nameof(ReAttachParent), .001f);
        }

        private void ReAttachParent()
        {
            transform.SetParent(_parent.transform);
        }

    }
}

