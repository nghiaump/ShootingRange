using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : Shooting
{
    private readonly int FireStateHash = Animator.StringToHash("AlternateSingleFire");

    [SerializeField]
    private float _rpm;

    // lay camera cho tia
    [SerializeField]
    private Transform _aimingCamera;

    [SerializeField]
    private GameObject _hitEffectPrefab;

    private bool _isFiring;
    private float lastShotTime;

    private void Update()
    {
        _isFiring = Input.GetButton("Fire1");

        if (_isFiring)
        {
            UpdateFiring();
        }
    }


    private void UpdateFiring()
    {
        float interval = 60f / _rpm;
        if(Time.time - lastShotTime >= interval)
        {
            Shoot();
            lastShotTime = Time.time;
        }

    }

    protected override void Shoot()
    {
        _animator.Play(FireStateHash, layer: 0, normalizedTime: 0);
        PerformRaycasting();
        base.Shoot();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo)) {
            CreateHitEffect(hitInfo);
        }
    }

    private void CreateHitEffect(RaycastHit hitInfo)
    {
        Quaternion holeRotation = Quaternion.LookRotation(hitInfo.normal);
        Instantiate(_hitEffectPrefab, hitInfo.point, holeRotation, hitInfo.collider.transform);
    }
}
