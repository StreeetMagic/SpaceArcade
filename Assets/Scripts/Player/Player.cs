using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public event Action <float> HealthChanged;
        public event Action <float> ArmorChanged;

        [SerializeField] private PlayerMainWeapon _mainWeapon;

        [field: SerializeField] public float StartingHealth { get; private set; } = 5;
        [field: SerializeField] public float StartingArmor { get; private set; } = 10;
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Armor { get; private set; }

        private void Awake()
        {
            Health = StartingHealth;
            Armor = StartingArmor;
        }

        public void TakeDamage(float damage)
        {
            if (Armor >= 1)
            {
                Armor -= damage;

                if (Armor < 0)
                {
                    Armor = 0;
                }
                ArmorChanged?.Invoke(Armor);
            }
            else
            {
                Health -= damage;
                if (Health <= 0)
                {
                    Health = 0;
                    Die();
                }
                HealthChanged?.Invoke(Health);
            }
        }

        public void GainArmor()
        {
            Armor++;
            ArmorChanged?.Invoke(Armor);
        }

        public void GainHealth()
        {
            float maxHealth = StartingHealth;
            
            if (Health < maxHealth)
            {
                Health++;
                HealthChanged?.Invoke(Health);
            }
            else
            {
                Armor++;
                ArmorChanged?.Invoke(Armor);
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

