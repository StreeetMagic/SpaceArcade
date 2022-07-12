using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Сrow : Enemy
    {
        private void Update()
        {
            Movement.StrafeX();
            Movement.StrafeY();

        }
    }
}

