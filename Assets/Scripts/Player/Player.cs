using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private float _health;

        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
    }
}

