using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public Boosting boosting;
    AudioSource boostTaken;
    public float timer;
    public bool boostReady;
    public float boostAmount = 15f;

    void Start()
    {
        boostReady = true;
        boostTaken = GetComponent<AudioSource>();
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
                boosting.boost += boostAmount;
                boostReady = false;
                boostTaken.Play();
            }
        }
    }
}
