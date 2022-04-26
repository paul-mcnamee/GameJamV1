using Utils;

public class ScoreManager : Singleton<ScoreManager>
{
    public TMPro.TMP_Text scoreText;
    private string textToUpdate = "";
    private int score = 0;
    bool updateTextRequired = false;

    public int Score
    {
        get
        {
            return score;
        }
    }

    public int AddScore()
    {
        score++;
        textToUpdate = $"Score: {score}";
        updateTextRequired = true;
        // TODO: check for win conditions??

        return Score;
    }

    private void Awake()
    {
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTextRequired)
            scoreText.text = textToUpdate;
    }
}
