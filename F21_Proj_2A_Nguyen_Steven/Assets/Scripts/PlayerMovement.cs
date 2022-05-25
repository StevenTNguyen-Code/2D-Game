using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Some code was provided by Brackeys but majority of it was written by me, Steven Nguyen. 
public class PlayerMovement : MonoBehaviour
{
    //To help control our character. 
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float hMovement = 0f;
    bool jump = false;

    //For when the player collects coins. 
    static AudioSource coinSound;
    public static AudioClip coinCollectibleSound; 

    
    [SerializeField] private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    void Start()
    {
        coinCollectibleSound =  Resources.Load<AudioClip>("Coins_Few_16"); 
        coinSound = GetComponent<AudioSource>(); 
    }

    //Helps play music when collecting coins
    public static void soundMaker(string song)
    {
        switch (song)
        {
            case "Coins_Few_16": 
            coinSound.PlayOneShot(coinCollectibleSound); 
            break;
        }
    }

    //Helps our Player move. 
    void Update()
    {
       hMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(hMovement));
      
       if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


    }

    //When we land, we want our jump to be false. 
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    //more player movement
    void FixedUpdate()
    {
        controller.Move(hMovement * Time.fixedDeltaTime, false, jump);
        jump = false;

    }


    //For when we touch the evil bricks and our spaceship + coins. 
    private void OnTriggerEnter2D(Collider2D collisionOcccurred)
    {
        if(collisionOcccurred.tag == "Main Menu Area")
        {
            SceneManager.LoadScene("MainMenu");
        }   
        else if (collisionOcccurred.tag == "Spaceship Credit")
        {
            SceneManager.LoadScene("CreditScene");
        }     
        else if (collisionOcccurred.tag == "Collectible")
        {
            Destroy(collisionOcccurred.gameObject);
            coins = coins + 1;
            coinText.text = coins.ToString();
            soundMaker("Coins_Few_16"); 
            
        }
    }

    //For when we touch a snail + coins. 
    private void OnCollisionEnter2D(Collision2D randomObject)
    {
        if (randomObject.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("MainMenu"); 
        }

        /*if (other.gameObject.tag == "Collectible")
        {
            //coinSound.Play(); 
            Destroy(other.gameObject);
            coins = coins + 1;
            coinText.text = coins.ToString();
        } */
    }


}