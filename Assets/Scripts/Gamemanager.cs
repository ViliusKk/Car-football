using System;
using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Boosting boostScript;
    public TMP_Text boostText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boostText.text = Convert.ToInt32(boostScript.boost).ToString();
    }
}
