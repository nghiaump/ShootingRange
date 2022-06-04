using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzleFlash;

    [SerializeField]
    private GameObject _flashLight;

    [SerializeField]
    private float _duration;

    private float _lastShowTime;

    private void OnEnable() => Hide();

    public void Show()
    {
        _muzzleFlash.gameObject.SetActive(true);
        _flashLight.SetActive(true);

        // Xoay hieu ung
        RotateMuzzle();

        _lastShowTime = Time.time;
    }

    private void RotateMuzzle()
    {
        float angle = Random.Range(0f, 360f);
        _muzzleFlash.localRotation = Quaternion.Euler(0, 0, angle);
        
    }

    private void Update()
    {
        if (!_muzzleFlash.gameObject.activeSelf) return;

        if(Time.time - _lastShowTime >= _duration)
        {
            Hide();
        }
    }

    private void Hide()
    {
        _muzzleFlash.gameObject.SetActive(false);
        _flashLight.SetActive(false);
    }
}
