using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 1.01f;

    // Update is called once per frame
    void Update()
    {
        LookAtMouseY();
    }
    
    private void LookAtMouseY()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotaion = transform.localEulerAngles;
        newRotaion.x -= mouseY * _mouseSensitivity;
        transform.localEulerAngles = newRotaion;
    }
}
