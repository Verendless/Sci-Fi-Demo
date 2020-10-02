using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseX : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 1.01f;
    
    // Update is called once per frame
    void Update()
    {
        LookAtMouseX();
    }
    
    private void LookAtMouseX()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * _mouseSensitivity;
        transform.localEulerAngles = newRotation;
    }
}
