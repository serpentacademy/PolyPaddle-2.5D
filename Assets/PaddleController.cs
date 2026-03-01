using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 15f;
    public KeyCode moveUp;
    public KeyCode moveDown;
    
    // Set these in the Inspector based on where your walls are
    public float yMax = 8.5f; 
    public float yMin = -8.5f;

    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(moveDown))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Clamp the Y position so the paddle doesn't go through the walls
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        transform.position = clampedPosition;
    }
}   