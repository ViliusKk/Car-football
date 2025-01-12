using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardAcceleration = 10f;
    public float reverseAcceleration = 5f;
    public float maxSpeed = 50f;
    public float turnAngle = 200f;
    public float gravityForce = 10f;

    float speedInput;

    float turnInput;
    bool onGround;

    public LayerMask ground;
    public float groundRayLength = 0.5f;
    public Transform groundRay;

    void Start()
    {
        rb.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0;
        turnInput = 0;
        if (Input.GetAxis("Vertical") > 0) speedInput = Input.GetAxis("Vertical") * forwardAcceleration * 1000f;
        else if (Input.GetAxis("Vertical") < 0) speedInput = Input.GetAxis("Vertical") * reverseAcceleration * 1000f;

        turnInput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnAngle * Time.deltaTime *Input.GetAxis("Vertical"), 0f));

        transform.position = rb.transform.position;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            rb.AddForce(transform.forward * speedInput);
        }
    }
}
