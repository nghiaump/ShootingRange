using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _guns;

    private void Update()
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchToGun(i);
                break;
            }
        }
    }

    private void SwitchToGun(int gunIndex)
    {
        for(int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(i == gunIndex);
        }
    }
}
