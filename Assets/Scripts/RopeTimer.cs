using DG.Tweening;
using UnityEngine;
using Utils;

public class RopeTimer : MonoBehaviour
{
    public TMPro.TMP_Text TimeRemainingText;
    public RectTransform Mask;
    public GameTimer timer;
    public Vector3 particleStartPos;
    public Vector3 particleEndPos;
    public Transform Particles;

    private float elapsedTime;
    private float updateInterval = 0.02f;

    private float timeRemainingSec;

    private void Awake()
    {
        timeRemainingSec = GameTimer.Instance.GameDurationSec;
        Particles.position = particleStartPos;
        GameTimer.Instance.OnGameEnd += DisableRope;
        Mask.DOSizeDelta(new Vector2(0f, Mask.sizeDelta.y), GameTimer.Instance.GameDurationSec);
        Particles.DOMoveX(particleEndPos.x, GameTimer.Instance.GameDurationSec);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= updateInterval)
        {
            timeRemainingSec -= elapsedTime;
            TimeRemainingText.text = $"Time Remaining: {timeRemainingSec:F0}";
            elapsedTime = 0f;
        }
    }

    private void OnDisable()
    {
        GameTimer.Instance.OnGameEnd -= DisableRope;
    }

    private void DisableRope()
    {
        // TODO: Run animation and music for game over / round finish
        timeRemainingSec = Constants.START_TIME;

        // Disable game object.
        this.gameObject.SetActive(false);
    }

}
