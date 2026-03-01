using UnityEngine;
using TMPro; // Needed for UI text

public class GameManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI scoreText;
    public BallController ball;

    public void AddScore(int playerID)
    {
        if (playerID == 1)
        {
            player1Score++;
        }
        else if (playerID == 2)
        {
            player2Score++;
        }

        // Update the UI
        scoreText.text = player1Score + " - " + player2Score;
        
        // Reset the ball after a point is scored
        ball.ResetBall();
    }
}