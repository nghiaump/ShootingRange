using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private float _explosionRadius;

    [SerializeField]
    private float _explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowUp();
    }

    private void BlowUp()
    {
        Collider[] victims = Physics.OverlapSphere(transform.position, _explosionRadius);
        for(int i = 0; i < victims.Length; i++)
        {
            Rigidbody victimRigid = victims[i].attachedRigidbody;
            if (victimRigid == null) continue;
            victimRigid.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1, ForceMode.Impulse);

        }
    }
}
