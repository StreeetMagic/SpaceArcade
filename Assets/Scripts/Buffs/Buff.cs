using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player.Player>(out Player.Player Player))
        {
            Debug.Log("Игрок взял баф");
            Upgrade();
            gameObject.SetActive(false);
        }
    }

    protected abstract void Upgrade();
}
