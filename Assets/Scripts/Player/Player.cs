using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int _health;
        //private int _maxHealth = 10;

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }
}

