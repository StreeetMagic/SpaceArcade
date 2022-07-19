using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffucultySingleton : MonoBehaviour
{
    public static DiffucultySingleton Instance { get; private set; }
    
    [SerializeField] private float _defaultValue = .1f;

    [SerializeField] private float _moveSpeedMultiplier;
    [SerializeField] private float _maxMoveSpeedMultiplier = 2f;
    [SerializeField] private float _moveSpeedMultiplierDelta = .1f;
    [SerializeField] private float _moveSpeedCooldown = 30;

    
    public float MoveSpeedMultiplier => _moveSpeedMultiplier;

    private void OnEnable()
    {
        Initialize();
        _moveSpeedMultiplier = _defaultValue;
        StartCoroutine(IncreaseEnemyMoveSpeedMultiplier());
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    
    private void Initialize()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            Debug.LogError(nameof(DiffucultySingleton));
        }
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
