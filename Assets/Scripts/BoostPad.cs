using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public Controller player;
    public float timer;
    public bool boostReady;

    void Start()
    {
        boostReady = true;
    }


    void Update()
    {
        if(!boostReady)
        {
            timer += Time.deltaTime;
            if(timer >= 7)
            {
                boostReady = true;
                timer = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Cube"))
        {
            if(boostReady)
            {
                player.boost += 15f;
                boostReady = false;
            }
        }
    }
}
