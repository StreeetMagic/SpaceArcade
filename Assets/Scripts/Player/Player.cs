using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private float _health;
        private float _armor;

        private float _startingHealth = 5;
        private float _startingArmor = 0;

        public event Action <float> HealthChanged;

        private void Awake()
        {
            _health = _startingHealth;
            HealthChanged?.Invoke(_health);
            _armor = _startingArmor;
        }

        public void TakeDamage(float damage)
        {
            if (_armor >= 1)
            {
                _armor -= damage;

                if (_armor < 0)
                {
                    _armor = 0;
                }
            }
            else
            {
                _health -= damage;
                if (_health <= 0)
                {
                    _health = 0;
                    Die();
                }
                HealthChanged?.Invoke(_health);
            }

        }

        private void Die()
        {
            Debug.Log("Умер");
        }
    }
}

