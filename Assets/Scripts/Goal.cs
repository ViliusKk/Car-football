using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool scored;
    public int score;

    private float timer;
    void Start()
    {
        scored = false;
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            score++;
            scored = true;
        }
    }
}
