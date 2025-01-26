using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Transform ballTarget;
    public Ball ballScript;
    NavMeshAgent agent;
    //public Transform goalTarget;

    float timer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, ballTarget.position);
        
        agent.SetDestination(ballTarget.position);
        if (distance <= 8f)
        {
            ballScript.kickBall = true;
        }
        else
        {
            ballScript.kickBall = false;
        }
        // if (ballScript.kickBall && timer >= 0.6f)
        // {
        //     ballScript.kickBall = false;
        //     timer = 0f;
        // }
    }
}
