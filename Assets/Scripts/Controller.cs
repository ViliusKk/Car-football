using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject carModel;

    public float forwardAcceleration = 10f;
    public float reverseAcceleration = 5f;
    public float turnAngle = 200f;
    public float gravityForce = 10f;
    public float dragOnGround = 3f;

    float speedInput;

    float turnInput;
    bool onGround;

    public LayerMask ground;
    public float groundRayLength = 0.5f;
    public Transform groundRay;

    public Transform wheelFL;
    public Transform wheelFR;
    public float maxWheelTurn = 45f;

    public float jumpStrength = 2;
    bool canJump = true;

    public float boost = 100f;
    public float boostStrength = 15f;

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

        if (onGround)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnAngle * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        wheelFL.localRotation = Quaternion.Euler(wheelFL.localRotation.eulerAngles.x, turnInput * maxWheelTurn, wheelFL.localRotation.eulerAngles.z);
        wheelFR.localRotation = Quaternion.Euler(wheelFR.localRotation.eulerAngles.x, turnInput * maxWheelTurn, wheelFR.localRotation.eulerAngles.z);

        transform.position = rb.transform.position;

        if (boost < 0) boost = 0;
    }

    void FixedUpdate()
    {
        onGround = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRay.position, -transform.up, out hit, groundRayLength, ground))
        {
            onGround = true;
            canJump = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            rb.transform.rotation = transform.rotation;
        }

        if (onGround)
        {
            rb.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * -gravityForce * 100f);
        }
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpStrength * 100f);
        }
        if(Input.GetKey(KeyCode.LeftShift) && boost > 0)
        {
            rb.AddForce(transform.forward * (speedInput+boostStrength));
            boost -= Time.deltaTime * 60;
        }
    }
}
