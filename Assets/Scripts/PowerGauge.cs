using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGauge : MonoBehaviour
{
    public RectTransform Mask;
    public float animationTimeSec = 0.2f;
    private float initialHeight;
    public float CurrentPowerPercentage { get; private set; }

    private void Awake()
    {
        initialHeight = Mask.sizeDelta.y;
    }

    public void SetHeightPercentage(float percent)
    {
        CurrentPowerPercentage = percent;
        Mask.DOSizeDelta(new Vector2(Mask.sizeDelta.x, initialHeight * percent), animationTimeSec);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveRandomly());
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
