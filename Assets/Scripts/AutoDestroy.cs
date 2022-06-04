using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime;

    void Start() => Destroy(gameObject, _lifeTime);


}
