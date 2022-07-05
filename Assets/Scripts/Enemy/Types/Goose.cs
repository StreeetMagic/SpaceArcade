using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Goose : Enemy
    {
        private void Update()
        {
            Movement.MoveLeft();
        }
    }
}

