using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Transform ballTarget;
    public Ball ballScript;
    NavMeshAgent agent;
    //public Transform goalTarget;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, ballTarget.position);
        
        agent.SetDestination(ballTarget.position);
        if (distance <= 8f)
        {
            ballScript.kickBall = true;
        }
        else ballScript.kickBall = false;
    }
}
