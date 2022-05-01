using System;
using UnityEngine;
using Utils;
using static Utils.Constants;

public class GameTimer : Singleton<GameTimer>
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public bool GameIsEnded = false;
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
        if (GameIsEnded)
            return;

        CurrentTime += Time.deltaTime;
        if (CurrentTime >= GameDurationSec)
            GameOver();
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!!");
        GameIsEnded = true;
        OnGameEnd?.Invoke();
    }

    private void OnDisable()
    {
        OnGameEnd?.Invoke();
    }
}
