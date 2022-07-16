using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmorText : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private TextMeshProUGUI _armor;
         
    private void OnEnable()
    {
        _player.ArmorChanged += OnArmorChanged;
    }

    private void OnDisable()
    {
        _player.ArmorChanged -= OnArmorChanged;

    }

    private void OnArmorChanged(float value)
    {
        string text = value.ToString();
        _armor.text = text;
    }
}
