using System;
using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Boosting boostScript;
    public TMP_Text boostText;
    public Transform ball;
    public Transform player;
    public Transform bot;
    void Start()
    {
        player.transform.position = new Vector3(380f, 0.85f, 288.85f);
        player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        bot.transform.position = new Vector3(269f, 0.85f, 288.85f);
        bot.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        ball.transform.position = new Vector3(324.85f, 1.65f, 289f);
    }

    // Update is called once per frame
    void Update()
    {
        boostText.text = Convert.ToInt32(boostScript.boost).ToString();
    }
}
