using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Speed;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
   // public RewardProvider reward;

    public float walkSpeed = 6f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public float leftBound = -5f;  // Left boundary
    public float rightBound = 5f;  // Right boundary
    public float speed = 5f;

    public float catCounter = 0f;

    private float moveInput;

    public int hasHS = 0;
 
    public int score = 0;

    Rigidbody rb;

    Vector3 moveDirection = Vector3.zero;
    
    public bool canMove = true;

    CharacterController characterController;
    
    void Start()
    {
        Debug.Log("Start() running in FPSController");
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        gameObject.tag = "Player";
        rb = GetComponent<Rigidbody>();
        if (scoreText == null) // If it’s not assigned manually
        {
            scoreText = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        }
        //if (highscoreText == null) // If it’s not assigned manually
        //{
          //  highscoreText = GameObject.Find("highscore").GetComponent<TextMeshProUGUI>();
        //}
        highscoreText.text = "highscore: " + PlayerPrefs.GetInt("SavedHS");
        Debug.Log("Updated highscore text!");
        GameObject rewardManagerObject = GameObject.Find("rewardmgr");
        /*
        rewardProvider = rewardManagerObject.GetComponent<RewardProvider>();
        if(rewardProvider == null)
        {
            Debug.LogWarning("RewardManager GameObject not found!");
        }
        */
        //rewardProvider = GameObject.Find("RewardManager").GetComponent<RewardProvider>();

        UpdateScoreDisplay();
        HighScoreUpdate();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector3(0, rb.velocity.y, moveX);
        #region player movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        moveInput = Input.GetAxisRaw("Horizontal");

        float movePar = moveInput * speed * Time.deltaTime;
        float pos = 0.0f;

        transform.position += new Vector3(0, 0, movePar);
        pos = transform.position.z;
        if (pos <= leftBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftBound);
        }
        else if (pos >= rightBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, rightBound);
        }

        #endregion

        #region player score
        score+=2;
        int scoreCheck = 3000;
        if (score - scoreCheck == 0) {
            scoreCheck *= 2;
            SharedSpeed.speed *= 1.2f;
        }
        UpdateScoreDisplay();
        //HighScoreUpdate();
        //Debug.Log(score); //want this to be printed somewhere in the display screen in game

        #endregion

    }
    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHS")) {
            if (score > PlayerPrefs.GetInt("SavedHS"))
            {
                Debug.Log($"highscore: {PlayerPrefs.GetInt("SavedHS")}");
                PlayerPrefs.SetInt("SavedHS",score);
                hasHS = 1; //when this is 1 i want to show one random pic of a cat
                Debug.Log("HERE");
                //FindObjectOfType<RewardProvider>().ShowRandomCat(4f);
                //rewardProvider.ShowRandomCat(4f);
                /*
                if (RewardProvider.Instance != null)
                {
                    RewardProvider.Instance.ShowRandomCat(4f);
                }
                Debug.Log("Called it");
                */
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHS", score);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Detects Object2 with "Enemy" tag
        {
            Debug.Log("Player hit an enemy!");
            SceneManager.LoadSceneAsync(0);
            HighScoreUpdate();
            if(hasHS == 1)
            {
                SceneManager.LoadSceneAsync(3);
            }

        }
        else if (other.CompareTag("Cat")) 
        {
            catCounter++;
            Debug.Log($"player hit cat {3 - catCounter} times to run on a cat remaining");
            score -= 100;
            UpdateScoreDisplay();
            if (catCounter == 3) {
                SceneManager.LoadSceneAsync(0);
                HighScoreUpdate();
                if (hasHS == 1)
                {
                    SceneManager.LoadSceneAsync(3);
                }
            }
        
        }

    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "score: " + score.ToString(); // Updates the Text UI with the score
        scoreText.ForceMeshUpdate();
    }
}