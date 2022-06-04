using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooting : Shooting
{

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private Transform _firingPos;

    [SerializeField]
    private float _launchingForce;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
        _animator.SetTrigger(ShootTrigger);
        base.Shoot();
    }

    public void AddProjectile() {
        CreateBullet();
        //
        // OnShoot?.Invoke(); => Da chuyen qua lop cha
    }

    private void CreateBullet()
    {
        /*
        GameObject bullet = new GameObject("GrenadeBullet");
        bullet.AddComponent<MeshFilter>();
        bullet.AddComponent<MeshRenderer>();
        bullet.AddComponent<CapsuleCollider>();
        bullet.AddComponent<Rigidbody>();
        */
        GameObject bullet = Instantiate(_bulletPrefab, _firingPos.position, _firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _launchingForce;
    }

}
