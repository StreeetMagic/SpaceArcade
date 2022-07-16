using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMainWeapon _mainWeapon;

        private float _health;
        private float _armor;

        private float _startingHealth = 5;
        private float _startingArmor = 10;

        public event Action <float> HealthChanged;
        public event Action <float> ArmorChanged;

        private void Awake()
        {
            _health = _startingHealth;
            HealthChanged?.Invoke(_health);
            _armor = _startingArmor;
            ArmorChanged?.Invoke(_armor);
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
                ArmorChanged?.Invoke(_armor);
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

        public void UpgradeMainWeapon()
        {
            _mainWeapon.Upgrade();
        }
    }
}

