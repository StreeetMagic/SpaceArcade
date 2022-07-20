using UnityEngine;

namespace Enemy
{
    public class Movement : MonoBehaviour
    {
        private StatUpgrader _statUpgrader;

        [field: SerializeField] public float DefaultXMoveSpeed { get; private set; } = 3;
        [field: SerializeField] public float DefaultYMoveSpeed { get; private set; } = 2;
        [field: SerializeField] public float CurrentXMoveSpeed { get; private set; }
        [field: SerializeField] public float CurrentYMoveSpeed { get; private set; }

        public int YBorder { get; private set; } = 4;
        public int XBorder { get; private set; } = 7;
        public bool GoesTop { get; private set; } = true;
        public bool GoesLeft { get; private set; } = true;


        private void OnEnable()
        {
            if (_statUpgrader)
            {
                CurrentXMoveSpeed = DefaultXMoveSpeed * _statUpgrader.MoveSpeedMultiplier;
                CurrentYMoveSpeed = DefaultYMoveSpeed * _statUpgrader.MoveSpeedMultiplier;
            }
        }

        public void MoveLeft()
        {
            transform.position -= new Vector3(CurrentXMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveRight()
        {
            transform.position += new Vector3(CurrentXMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveDown()
        {
            transform.position -= new Vector3(0, CurrentYMoveSpeed * Time.deltaTime, 0);
        }

        public void MoveTop()
        {
            transform.position += new Vector3(0, CurrentYMoveSpeed * Time.deltaTime, 0);
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

