using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Mover
{
    private PlayerControls playerControls;
    private float speed = 50f;

    public void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Move.Enable();
    }
    private void FixedUpdate()
    {
        //Get input
        Vector2 inputVector = playerControls.Player.Move.ReadValue<Vector2>();
        Vector3 input = new Vector3(inputVector.x, inputVector.y, 0);
        Debug.Log("InputVector: " + inputVector);
        Debug.Log("Input: " + input);
        UpdateMotor(input, speed);
    }
}