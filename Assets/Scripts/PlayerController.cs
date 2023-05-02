using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load scene
using UnityEngine.UI; // Use UI for scoreText

public class PlayerController : MonoBehaviour
{
    // Variable that can be edited in the Inspector
    public float speed = 300f;
    public int health = 5;
    public Text scoreText; 
    public Text HealthText;

    // This is a reference to the Rigibody
    public Rigidbody rb;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze"); //load scene
        }
    }

    // it is called every fixed frame-rate frame.
    void FixedUpdate()
    {
        // Add speed force
        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if ( Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }

    // Manipulate Objects with the Tags
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            //  Show Score on Canvas
            SetScoreText();
            Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            // Show Score on Canvas
            SetHealthText();
            Debug.Log($"Health: {health}");
        }

        if (other.tag == "Goal")
        {
            Debug.Log($"You win!");
        }

        void SetScoreText()
        {
            scoreText.text = $"Score: {score.ToString()}";
        }

        void SetHealthText()
        {
            HealthText.text = $"Health: {health.ToString()}";
        }
    }
}
