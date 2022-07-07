using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Movement : MonoBehaviour
    {
        private float _xMoveSpeed = 3;
        private float _yMoveSpeed = 2;
        private bool _goesTop = true;
        private bool _goesLeft = true;
        private int _YBorder = 4;
        private int _XBorder = 7;

        public void MoveLeft()
        {
            transform.Translate(Vector3.up * _xMoveSpeed * Time.deltaTime);
        }        
        
        public void MoveRight()
        {
            transform.Translate(Vector3.down * _xMoveSpeed * Time.deltaTime);
        }

        public void StrafeY()
        {
            if (_goesTop)
            {
                transform.Translate(Vector3.right * _yMoveSpeed * Time.deltaTime);

                if (transform.position.y >= _YBorder)
                {
                    _goesTop = false;
                }
            }

            if (_goesTop == false)
            {
                transform.Translate(Vector3.left * _yMoveSpeed * Time.deltaTime);

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

            if (_goesLeft == false)
            {
                MoveRight();

                if (transform.position.x >= _XBorder)
                {
                    _goesLeft = true;
                }
            }
        }
    }
}

