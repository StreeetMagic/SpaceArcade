using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _DefaultXMoveSpeed = 3;
        [SerializeField] private float _DefaultYMoveSpeed = 2;

        private float _xMoveSpeed;
        private float _yMoveSpeed;

        private bool _goesTop = true;
        private bool _goesLeft = true;
        private int _YBorder = 4;
        private int _XBorder = 7;

        public float XMoveSpeed => _xMoveSpeed;

        private void OnEnable()
        {
             _xMoveSpeed = _DefaultXMoveSpeed * DiffucultySingleton.Instance.MoveSpeedMultiplier;
             _yMoveSpeed = _DefaultYMoveSpeed * DiffucultySingleton.Instance.MoveSpeedMultiplier;
        }

        public void MoveLeft()
        {
            transform.position -= new Vector3(_xMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveRight()
        {
            transform.position += new Vector3(_xMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveDown()
        {
            transform.position -= new Vector3(0, _yMoveSpeed * Time.deltaTime, 0);
        }

        public void MoveTop()
        {
            transform.position += new Vector3(0, _yMoveSpeed * Time.deltaTime, 0);
        }

        public void StrafeY()
        {
            if (_goesTop)
            {
                MoveTop();

                if (transform.position.y >= _YBorder)
                {
                    _goesTop = false;
                }
            }
            else
            {
                MoveDown();

                if (transform.position.y <= -_YBorder)
                {
                    _goesTop = true;
                }
            }
        }

        public void StrafeX()
        {
            if (_goesLeft)
            {
                MoveLeft();

                if (transform.position.x <= -_XBorder)
                {
                    _goesLeft = false;
                }
            }
            else
            {
                MoveRight();

                if (transform.position.x >= _XBorder)
                {
                    _goesLeft = true;
                }
            }
        }

        public void Rotate()
        {
            transform.Rotate(0, 0, .5f);
        }
    }
}

