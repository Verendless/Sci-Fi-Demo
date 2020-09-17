using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 3.0f;   
    private float _gravity = 9.81f;
    


    // Start is called before the first frame update
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if(_characterController == null)
        {
            Debug.LogError("Character Controller is Null");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _characterController.Move(velocity * Time.deltaTime);
    }




}
