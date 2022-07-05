using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Owl : Enemy
    {
        private void Update()
        {
            Movement.StrafeY();
            Movement.MoveLeft();
        }
    }
}

