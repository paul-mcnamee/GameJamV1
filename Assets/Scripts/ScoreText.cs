using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TMPro.TMP_Text currentScoreText;
    private ScoreManager scoreManager;

    private void OnEnable()
    {
        currentScoreText = GetComponentInChildren<TMPro.TMP_Text>(true);
        scoreManager = ScoreManager.Instance;
        scoreManager.scoreText = currentScoreText;
        scoreManager.scoreText.text = $"Score: {scoreManager.Score}";
    }

}
