using System;
using UnityEngine;
using Utils;
using static Utils.Constants;

public class GameTimer : Singleton<GameTimer>
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public float GameDurationSec = DEFAULT_MINI_GAME_DURATION_SEC;
    public float CurrentTime { get; private set; } = START_TIME;

    protected override void OnAwake()
    {
        base.OnAwake();
        OnGameStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= GameDurationSec)
            GameOver();
    }

    public void GameOver()
    {
        OnGameEnd?.Invoke();
    }


    private void OnDisable()
    {
        OnGameEnd?.Invoke();
    }
}
