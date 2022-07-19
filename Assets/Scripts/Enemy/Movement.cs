using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Movement : MonoBehaviour
    {
        private StatUpgrader _statUpgrader;

        [field: SerializeField] public float DefaultXMoveSpeed { get; private set; } = 3;
        [field: SerializeField] public float DefaultYMoveSpeed { get; private set; } = 2;
        [field: SerializeField] public float XMoveSpeed { get; private set; }
        [field: SerializeField] public float YMoveSpeed { get; private set; }

        [field: SerializeField] public int YBorder { get; private set; } = 4;
        [field: SerializeField] public int XBorder { get; private set; } = 7;
        [field: SerializeField] public bool GoesTop { get; private set; } = true;
        [field: SerializeField] public bool GoesLeft { get; private set; } = true;


        private void OnEnable()
        {
            if (_statUpgrader)
            {
                XMoveSpeed = DefaultXMoveSpeed * _statUpgrader.MoveSpeedMultiplier;
                YMoveSpeed = DefaultYMoveSpeed * _statUpgrader.MoveSpeedMultiplier;
            }
        }

        public void MoveLeft()
        {
            transform.position -= new Vector3(XMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveRight()
        {
            transform.position += new Vector3(XMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveDown()
        {
            transform.position -= new Vector3(0, YMoveSpeed * Time.deltaTime, 0);
        }

        public void MoveTop()
        {
            transform.position += new Vector3(0, YMoveSpeed * Time.deltaTime, 0);
        }

        public void StrafeY()
        {
            if (GoesTop)
            {
                MoveTop();

                if (transform.position.y >= YBorder)
                {
                    GoesTop = false;
                }
            }
            else
            {
                MoveDown();

                if (transform.position.y <= -YBorder)
                {
                    GoesTop = true;
                }
            }
        }

        public void StrafeX()
        {
            if (GoesLeft)
            {
                MoveLeft();

                if (transform.position.x <= -XBorder)
                {
                    GoesLeft = false;
                }
            }
            else
            {
                MoveRight();

                if (transform.position.x >= XBorder)
                {
                    GoesLeft = true;
                }
            }
        }

        public void GetStatUpgrader(StatUpgrader statUpgrader)
        {
            _statUpgrader = statUpgrader;
        }
    }
}

