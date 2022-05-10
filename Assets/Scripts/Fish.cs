using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Fish : MonoBehaviour
{
    public float animationTimeSec = 0.5f;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Vector3 initialPosition;

    private float initialWidth;
    public float CurrentPowerPercentage { get { return transform.localPosition.x / initialWidth; } }
    private IEnumerator moveFishCoroutine;
    private GameTimer gameTimer;

    private void Awake()
    {
        initialPosition = this.transform.position;
        initialWidth = maxPosition.x - minPosition.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameTimer.Instance;
        gameTimer.OnGameEnd += StopFish;
        moveFishCoroutine = MoveContinuously();
        StartCoroutine(moveFishCoroutine);
    }

    private void StopFish()
    {
        StopCoroutine(moveFishCoroutine);
    }

    private void OnDestroy()
    {
        if (gameTimer != null)
        {
            gameTimer.OnGameEnd -= StopFish;
        }
    }

    public void SetWidthPercentage(float percent)
    {
        this.transform.DOMove(new Vector2(minPosition.x + (initialWidth * percent), initialPosition.y), animationTimeSec);
    }

    private IEnumerator MoveContinuously()
    {
        yield return new WaitForSeconds(animationTimeSec);
        SetWidthPercentage(0f);
        yield return new WaitForSeconds(animationTimeSec);
        SetWidthPercentage(1f);
        yield return MoveContinuously();
    }
}
