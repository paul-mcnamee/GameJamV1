using DG.Tweening;
using UnityEngine;

public class RopeTimer : MonoBehaviour
{
    public SpriteRenderer Left;
    public SpriteRenderer Right;
    public SpriteRenderer Middle;
    public TMPro.TMP_Text TimeRemainingText;
    public RectTransform Mask;

    private float elapsedTime;
    private float updateInterval = 0.1f;

    public float GameDurationSec;
    private float timeRemainingSec;
    private float updateIntervalSize;
    private float maskIntervalSize;
    private float maskWidth;

    private void Awake()
    {
        timeRemainingSec = GameDurationSec;
        updateIntervalSize = Middle.size.x / ( GameDurationSec / updateInterval );
        maskWidth = Mask.sizeDelta.x;
        maskIntervalSize = Mask.sizeDelta.x / (GameDurationSec / updateInterval);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= updateInterval)
        {
            timeRemainingSec -= elapsedTime;
            TimeRemainingText.text = $"Time Remaining: {timeRemainingSec:F0}";
            UpdatePositions();
            elapsedTime = 0f;
            if (timeRemainingSec <= 0)
            {
                // Game Over
                timeRemainingSec = 0f;
                Left.enabled = false;
                Right.enabled = false;
                Middle.enabled = false;
                GameTimer.Instance.GameOver();
            }
        }
    }

    private void UpdatePositions()
    {
        // Shrink the size of the middle segment by the updateIntervalSize
        Middle.size = new Vector2 (Mathf.Clamp(Middle.size.x - updateIntervalSize, 0f, float.MaxValue), Middle.size.y);
        Mask.DOSizeDelta(new Vector2(Mask.sizeDelta.x - maskIntervalSize, Mask.sizeDelta.y), updateInterval);

        // move the middle and the right segments by the amount shrunk
        Middle.transform.DOMove(new Vector2(Middle.transform.position.x - updateIntervalSize / 4, Middle.transform.position.y), updateInterval);
        Right.transform.DOMove(new Vector2(Right.transform.position.x - updateIntervalSize/2, Right.transform.position.y), updateInterval);
    }
}
