using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    public Controller player;
    public float timer = 0;
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("ube"))
        {
            print("yes");
            if(boostReady)
            {
                player.boost += 15f;
                boostReady = false;
            }
        }
    }
}
