using Utils;

public class ScoreManager : Singleton<ScoreManager>
{
    public TMPro.TMP_Text scoreText;
    private string textToUpdate = "";
    private int score;
    public bool UpdateTextRequired = false;

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
        UpdateTextRequired = true;
        return Score;
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        score = 0;
    }

    private void Start()
    {
        scoreText.text = $"Score: {score}";
        textToUpdate = scoreText.text;
    }

    void Update()
    {
        if (UpdateTextRequired)
            scoreText.text = textToUpdate;
    }
}
