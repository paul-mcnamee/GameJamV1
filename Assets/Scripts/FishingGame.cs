using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGame : MonoBehaviour
{
    public float GameDuration = 60f;

    // Start is called before the first frame update
    void Awake()
    {
        GameTimer.Instance.GameDurationSec = this.GameDuration;
    }
}
