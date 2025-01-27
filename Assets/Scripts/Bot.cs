using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Transform ballTarget;
    public Ball ballScript;
    public Rigidbody playerRb;
    public Gamemanager gamemanager;
    Rigidbody rb;
    NavMeshAgent agent;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, ballTarget.position);

        if (gamemanager.canMove)
        {
            agent.SetDestination(ballTarget.position);
        }
        
        if (distance <= 8f)
        {
            ballScript.kickBall = true;
        }
        else
        {
            ballScript.kickBall = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Cube"))
        {
            playerRb.AddExplosionForce(2000f, transform.position, 100f, 0f, ForceMode.Impulse);
            rb.AddExplosionForce(13000f, playerRb.transform.position, 100f, 0f, ForceMode.Impulse);
        }
    }
}
