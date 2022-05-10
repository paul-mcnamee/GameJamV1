using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerGauge : MonoBehaviour
{
    public RectTransform Mask;
    public float animationTimeSec = 0.5f;
    private float initialHeight;
    public float CurrentPowerPercentage { get { return Mask.sizeDelta.y / initialHeight; } }
    private IEnumerator moveGagueCoroutine;
    private GameTimer gameTimer;

    private void Awake()
    {
        initialHeight = Mask.sizeDelta.y;
        Mask.DOSizeDelta(new Vector2(Mask.sizeDelta.x, 0f), 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameTimer.Instance;
        gameTimer.OnGameEnd += StopGague;
        moveGagueCoroutine = MoveOnce();
    }

    private void OnDestroy()
    {
        if (gameTimer != null)
        {
            gameTimer.OnGameEnd -= StopGague;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (GameTimer.Instance.GameIsEnded)
                return;

            StartCoroutine(moveGagueCoroutine);
        }

        if (context.canceled)
        {
            Mask.DOKill();
            StopCoroutine(moveGagueCoroutine);
            moveGagueCoroutine = MoveOnce();
        }
    }

    private void StopGague()
    {
        StopCoroutine(moveGagueCoroutine);
    }

    public void SetHeightPercentage(float percent)
    {
        Mask.DOSizeDelta(new Vector2(Mask.sizeDelta.x, initialHeight * percent), animationTimeSec);
    }

    private IEnumerator MoveOnce()
    {
        Mask.DOSizeDelta(new Vector2(Mask.sizeDelta.x, initialHeight * 0f), 0f);

        SetHeightPercentage(1f);
        yield return null;
    }

    private IEnumerator MoveContinuously()
    {
        yield return new WaitForSeconds(animationTimeSec);
        SetHeightPercentage(0f);
        yield return new WaitForSeconds(animationTimeSec);
        SetHeightPercentage(1f);
        yield return MoveContinuously();
    }

    /// <summary>
    /// Code for testing, probably would not actually be using this
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveRandomly()
    {
        SetHeightPercentage(Random.Range(0.0f, 1.0f));
        yield return new WaitForSeconds(3);
        SetHeightPercentage(Random.Range(0.0f, 1.0f));
        yield return new WaitForSeconds(3);
        SetHeightPercentage(Random.Range(0.0f, 1.0f));
        yield return new WaitForSeconds(3);
        SetHeightPercentage(Random.Range(0.0f, 1.0f));
    }
}
