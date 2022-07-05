using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class Parrot : Enemy
    {
        private void Update()
        {
            Movement.StrafeX();
            Movement.StrafeY();
        }
    }
}

