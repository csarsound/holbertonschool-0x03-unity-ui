using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2000f;
    private int score = 0;
    public int health = 5;

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
    }
        // Update is called once per frame
        void FixedUpdate ()
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("Score: " + score.ToString());
        }
        
        if (other.gameObject.CompareTag("Trap"))
        {
            
            health--;
            Debug.Log("Health: " + health.ToString());
        
        }
        
        if (other.gameObject.CompareTag("Goal"))
        {
         
            Debug.Log("You win!");
       
        }
       
    }

}
