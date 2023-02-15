using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

// Edit the PlayerController.cs script so that when the Player touches the Goal:
//You Win! displays in the WinLoseText UI element
//WinLoseText‘s color changes to black
//WinLoseBG’s color changes to green



public class PlayerController : MonoBehaviour
{
    // declare public/private variables
    public Rigidbody rb;
    // rigidbody is a component of the player
    private int score = 0;
    // score and health text
    public Text scoreText;
    public Text healthText;
    // sensetivity is still 2000f?
    public float speed = 3000f;
    public int health = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }
    
    
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    
    
    
    // trigger for when the player collects or collides into traps or coins
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            //Debug.Log("Score: " + score);
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            other.gameObject.SetActive(true);
            health -= 1;
            //Debug.Log("Health: " + health);
            SetHealthText();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
                
    }
    // implementing the score and health text
    void Update()
    {
        if (health == 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
                
    }
    
}
