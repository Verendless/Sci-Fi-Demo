using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Mouse Look Component Menu")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxis {MouseXandY = 0, MouseX = 1, MouseY = 2}

    [SerializeField] private RotationAxis _axis = RotationAxis.MouseXandY;
    [SerializeField] private float _sensitivityX = 5.0f;
    [SerializeField] private float _sensitivityY = 5.0f;

    [SerializeField] private float _minimumY = -60.0f;
    [SerializeField] private float _maximumY = 60.0f;

    private float _rotationY = 0f;

    void Update ()
    {
        if (_axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityX, 0);
        }

        else
        {
            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;
            _rotationY = Mathf.Clamp(_rotationY, _minimumY, _maximumY);
            
            transform.localEulerAngles = new Vector3(-_rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
