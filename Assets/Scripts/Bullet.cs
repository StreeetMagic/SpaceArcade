using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;


public abstract class Bullet : MonoBehaviour
{
    private GameObject _parent;
    public float Speed { get; protected set; } = 15;

    public int Damage { get; protected set; }

    private void Awake()
    {
        _parent = transform.parent.gameObject;
    }

    private void OnEnable()
    {
        while (transform.parent != null)
        {
            transform.SetParent(null);
        }
    }

    private void OnDisable()
    {
        Invoke(nameof(ReAttachParent), .001f);
    }

    private void ReAttachParent()
    {
        transform.SetParent(_parent.transform);
    }

}


