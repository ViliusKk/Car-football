using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool scored;
    public int score;
    private AudioSource goalSound;

    private float timer;
    void Start()
    {
        scored = false;
        score = 0;
        goalSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            score++;
            scored = true;
            goalSound.Play();
        }
    }
}
