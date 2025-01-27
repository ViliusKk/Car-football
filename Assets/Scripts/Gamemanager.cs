using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Boosting boostScript;
    public Goal playerSide;
    public Goal botSide;
    public TMP_Text boostText;
    public TMP_Text playerScoreText;
    public TMP_Text botScoreText;
    public TMP_Text scoreText;
    public Transform ball;
    public Transform player;
    public Rigidbody ballRb;
    public Rigidbody playerRb;
    public Rigidbody botRb;
    public Transform bot;

    private float timer;
    private bool startTimer;
    void Start()
    {
        SpawnPosition();
        playerScoreText.text = botSide.score.ToString();
        botScoreText.text = playerSide.score.ToString();
        //scoreText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }
        boostText.text = Convert.ToInt32(boostScript.boost).ToString();
        if (playerSide.scored)
        {
            botRb.AddExplosionForce(100f, playerSide.transform.position, 100f, 0f, ForceMode.Impulse);
            playerRb.AddExplosionForce(100f, playerSide.transform.position, 100f, 0f, ForceMode.Impulse);
            
            botScoreText.text = playerSide.score.ToString();
            scoreText.text = "Bot scored!";
            scoreText.gameObject.SetActive(true);
            
            startTimer = true;
            if (timer >= 3)
            {
                timer = 0;
                SpawnPosition();
                startTimer = false;
                playerSide.scored = false;
                scoreText.gameObject.SetActive(false);
            }
        }
        else if (botSide.scored)
        {
            botRb.AddExplosionForce(100f, botSide.transform.position, 100f, 0f, ForceMode.Impulse);
            playerRb.AddExplosionForce(100f, botSide.transform.position, 100f, 0f, ForceMode.Impulse);
            
            playerScoreText.text = botSide.score.ToString();
            scoreText.text = "You scored!";
            scoreText.gameObject.SetActive(true);
            
            startTimer = true;
            if (timer >= 3)
            {
                timer = 0;
                SpawnPosition();
                startTimer = false;
                botSide.scored = false;
                scoreText.gameObject.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetPlayer();
        }
    }

    void SpawnPosition()
    {
        playerRb.transform.position = new Vector3(380f, 0.85f, 288.85f);
        player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        boostScript.boost = 30f;
        bot.transform.position = new Vector3(269f, 0.85f, 288.85f);
        bot.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        ball.transform.position = new Vector3(324.85f, 1.65f, 289f);
        ballRb.velocity = new Vector3(0f, 0f, 0f);
        ballRb.angularVelocity = new Vector3(0f, 0f, 0f);
    }

    void ResetPlayer()
    {
        playerRb.transform.position = new Vector3(380f, 0.85f, 288.85f);
        player.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }
}
