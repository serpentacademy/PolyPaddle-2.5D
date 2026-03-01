using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    private Rigidbody rb;
    public GameManager gameManager; // We will link this in the Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector3(x * initialSpeed, y * initialSpeed, 0f);
    }

    public void ResetBall()
    {
        // Stop the ball and move it back to the center
        rb.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        
        // Launch again after 1 second
        Invoke(nameof(LaunchBall), 1f); 
    }

    // This detects when the ball hits our invisible goal zones
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftGoal"))
        {
            gameManager.AddScore(2); // Player 2 gets a point
        }
        else if (other.CompareTag("RightGoal"))
        {
            gameManager.AddScore(1); // Player 1 gets a point
        }
    }
}