using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    
    [SerializeField] float movementSpeed = 12f;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] float gravity = -9.81f;
    float altitudeSpeed = 0.0f;

    public CharacterController controller;

    // Update is called once per frame
    void Update()
    {
        float altitudeInput = Input.GetAxis("Altitude");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        
        
        
        Vector3 move = transform.right * horizontalInput*movementSpeed + transform.forward * verticalInput * movementSpeed + transform.up * altitudeInput * movementSpeed;
        
        controller.Move(move * Time.deltaTime);
        
        
        
    }
}
