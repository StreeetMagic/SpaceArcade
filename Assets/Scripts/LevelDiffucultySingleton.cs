using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDiffucultySingleton : MonoBehaviour
{
    public static LevelDiffucultySingleton Instance { get; private set; }

    public float Multiplier { get; private set; } = 1f;
    private float _delta = 1.1f;
    private float _time = 15;


    private void OnEnable()
    {

        if (Instance == null)
        {
            Instance = this;
            StartCoroutine(IncreaseMultiplier());
        }
        else
        {
            Destroy(this);
            Debug.LogError(nameof(LevelDiffucultySingleton));
        }

    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private IEnumerator IncreaseMultiplier()
    {
        WaitForSeconds cooldown = new WaitForSeconds(_time);

        while (true)
        {
            yield return cooldown;
            Multiplier *= _delta;
            Debug.Log(Multiplier);
        }
    }


}
