using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private float _sensitivity = 9.0f;


    [SerializeField]
    private float _minPitch = -45.0f;
    [SerializeField]
    private float _maxPitch = 45.0f;

    [SerializeField]
    private Transform _cameraHolder;

    // Khoi dong cham de tranh vi tri chuot ban dau
    private bool allowRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Hen gio
        Invoke(nameof(EnableRotation), 1f);

    }

    private void EnableRotation() => allowRotation = true;

    private void Update()
    {

        if (!allowRotation) return;
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdateYaw()
    {
        float mouseDx = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseDx * _sensitivity, 0);
    }
    
    private void UpdatePitch()
    {
        float mouseDy = Input.GetAxis("Mouse Y");
        _cameraHolder.Rotate(-mouseDy * _sensitivity, 0, 0);
        ClampPitchAngle();
    }

    private void ClampPitchAngle()
    {
        float pitch = _cameraHolder.localEulerAngles.x;
        if(pitch > 180)
        {
            pitch -= 360;
        }
        if(pitch < -180)
        {
            pitch += 360;
        }
        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);
        _cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
