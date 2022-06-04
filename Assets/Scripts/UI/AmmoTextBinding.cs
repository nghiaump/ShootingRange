using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextBinding : MonoBehaviour
{
    [SerializeField]
    private GunAmmo _gunAmmo;

    [HideInInspector]
    [SerializeField]
    private TMP_Text _ammoText;

    private void OnValidate()
    {
        _ammoText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        _gunAmmo.OnAmmoChanged += UpdateAmmo;
        UpdateAmmo();
    }

    private void UpdateAmmo() => _ammoText.text = $"Ammo: {_gunAmmo.LoadedAmmo} / {_gunAmmo.RemainingAmmo}";
}
