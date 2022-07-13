using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Сrow : Enemy
    {
        private void Update()
        {
            
            Movement.StrafeY();

            if (transform.position.x - XPosition > 0.1)
            {
                Movement.MoveLeft();
            }
            
        }
    }
}

