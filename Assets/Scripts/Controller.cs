using UnityEngine;

public class Controller : MonoBehaviour
{
    public Gamemanager gamemanager;
    
    public Rigidbody rb;

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

    public Boosting boosting;
    
    public AudioSource carSound;
    private bool carSoundPlayed;
    bool boostSoundPlayed;

    void Start()
    {
        rb.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0;
        turnInput = 0;
        if (gamemanager.canMove)
        {
            if (Input.GetAxis("Vertical") > 0) speedInput = Input.GetAxis("Vertical") * forwardAcceleration * 1000f;
            else if (Input.GetAxis("Vertical") < 0) speedInput = Input.GetAxis("Vertical") * reverseAcceleration * 1000f;

            turnInput = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnAngle * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        

            wheelFL.localRotation = Quaternion.Euler(wheelFL.localRotation.eulerAngles.x, turnInput * maxWheelTurn, wheelFL.localRotation.eulerAngles.z);
            wheelFR.localRotation = Quaternion.Euler(wheelFR.localRotation.eulerAngles.x, turnInput * maxWheelTurn, wheelFR.localRotation.eulerAngles.z);
            
        }
        transform.position = rb.transform.position;
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
                if (!carSoundPlayed)
                {
                    carSound.Play();
                    carSoundPlayed = true;
                }
            }
            else
            {
                carSoundPlayed = false;
                carSound.Stop();
            }
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * (-gravityForce * 100f));
        }
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * (jumpStrength * 100f));
        }
        if(Input.GetKey(KeyCode.LeftShift) && boosting.boost > 0 && speedInput > 0)
        {
            rb.AddForce(transform.forward * (speedInput+boosting.boostStrength));
            boosting.boost -= Time.deltaTime * 60;
            if (!boostSoundPlayed)
            {
                boosting.boostSound.Play();
                boostSoundPlayed = true;
            }
            boosting.ActivateParticles();
        }
        else
        {
            boosting.boostSound.Stop();
            boostSoundPlayed = false;
            boosting.DeactivateParticles();
        }
    }
}
