using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool playerSide;
    public bool botScored;
    public bool playerScored;


    private float timer;
    void Start()
    {
        botScored = false;
        playerScored = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            if (!playerSide)
            {
                playerScored = true;
                print("good");
            }
            else
            {
                botScored = true;
            }
        }
    }
}
