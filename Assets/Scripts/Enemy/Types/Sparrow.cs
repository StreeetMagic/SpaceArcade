using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Sparrow : Enemy
    {
        private void Update()
        {
            Movement.StrafeX();
            Movement.StrafeY();
        }
    }
}

