using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMesh scoreText; 

    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
            scoreText.text = "" + score;
    }
}
