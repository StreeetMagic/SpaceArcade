using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Enemy _enemy;

        private float _recoveryRate = 50;
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _enemy.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _enemy.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = StartCoroutine(Draw(value));
        }

        private IEnumerator Draw(float value)
        {
            while (_slider.value != value)
            {
                _slider.value = (Mathf.MoveTowards(_slider.value, value, Time.deltaTime * _recoveryRate));
                yield return null;
            }
        }
    }
}
