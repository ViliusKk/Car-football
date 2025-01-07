using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PrometeoCarController controller;

    void Start()
    {
        controller.accelerationMultiplier = 5;
        controller.maxSteeringAngle = 45;
        controller.steeringSpeed = 1f;
        controller.handbrakeDriftMultiplier = 3;
        controller.maxSpeed = 45;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) controller.GoForward();
        if (Input.GetKey(KeyCode.S)) controller.GoReverse();
        if (Input.GetKey(KeyCode.A)) controller.TurnLeft();
        if (Input.GetKey(KeyCode.D)) controller.TurnRight();
    }
}
