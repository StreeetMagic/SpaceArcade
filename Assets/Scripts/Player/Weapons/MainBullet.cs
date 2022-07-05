using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class MainBullet : Bullet
    {
        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
}

