using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveByKeys : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private float _speed;

    void OnValidate()
    {
        _characterController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        // Vector3 direction = new Vector3(hInput, 0, vInput);

        var direction = transform.forward * vInput + transform.right * hInput;
        _characterController.SimpleMove(direction.normalized * _speed);
    }
}
