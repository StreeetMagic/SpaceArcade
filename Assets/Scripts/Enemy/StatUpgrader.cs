using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpgrader : MonoBehaviour
{
    [SerializeField] private float _defaultValue = .1f;
    [SerializeField] private float _moveSpeedMultiplier;
    [SerializeField] private float _maxMoveSpeedMultiplier = 2f;
    [SerializeField] private float _moveSpeedMultiplierDelta = .1f;
    [SerializeField] private float _moveSpeedCooldown = 30;

    public float MoveSpeedMultiplier => _moveSpeedMultiplier;

    private void OnEnable()
    {
        _moveSpeedMultiplier = _defaultValue;
        StartCoroutine(IncreaseEnemyMoveSpeedMultiplier());
    }

    private IEnumerator IncreaseEnemyMoveSpeedMultiplier()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_moveSpeedCooldown);

        while (_moveSpeedMultiplier <= _maxMoveSpeedMultiplier)
        {
            yield return cooldown;
            _moveSpeedMultiplier += _moveSpeedMultiplierDelta;

            if (_moveSpeedMultiplier > _maxMoveSpeedMultiplier)
            {
                _moveSpeedMultiplier = _maxMoveSpeedMultiplier;
            }
            yield return null;
        }
    }

}
