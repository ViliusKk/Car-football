using System;
using UnityEngine;

public class Boosting : MonoBehaviour
{
    public float boost = 100f;
    public float boostStrength = 15f;
    public AudioSource boostSound;
    public GameObject boostParticles1;
    public GameObject boostParticles2;

    void Start()
    {
        boostParticles1.SetActive(false);
        boostParticles2.SetActive(false);
    }

    void Update()
    {
        if (boost < 0) boost = 0;
        else if (boost > 100f) boost = 100f;
    }

    public void ActivateParticles()
    {
        boostParticles1.SetActive(true);
        boostParticles2.SetActive(true);
    }

    public void DeactivateParticles()
    {
        boostParticles1.SetActive(false);
        boostParticles2.SetActive(false);
    }
}
