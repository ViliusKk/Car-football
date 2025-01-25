using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool kickBall;
    AudioSource ballHit;
    Rigidbody rb;
    void Start()
    {
        ballHit = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Cube"))
        {
            ballHit.Play();
        }
    }

    void FixedUpdate()
    {
        if (kickBall)
        {
            rb.AddForce(transform.up * 2000f);
            rb.AddForce(transform.forward * 7000f);
        }
    }
}
