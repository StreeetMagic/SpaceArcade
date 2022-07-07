using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }
}

