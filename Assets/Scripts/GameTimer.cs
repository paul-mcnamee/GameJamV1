using System;
using UnityEngine;
using Utils;
using static Utils.Constants;

public class GameTimer : Singleton<GameTimer>
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public event Action OnGamePause;
    public event Action OnGameResume;
    public bool DoNotStartImmediately = false;

    private bool gameIsEnded = false;
    public bool GameIsEnded { get { return gameIsEnded; } }

    private bool gameIsStarted = false;
    public bool GameIsStarted { get { return gameIsStarted; } }

    private bool gameIsPaused = true;
    public bool GameIsPaused { get { return gameIsPaused; } }
    public float GameDurationSec = DEFAULT_MINI_GAME_DURATION_SEC;
    public float CurrentTime { get; private set; } = START_TIME;

    protected override void OnAwake()
    {
        base.OnAwake();
    }

    private void Start()
    {
        if (DoNotStartImmediately)
            return;

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsEnded || GameIsPaused)
            return;

        CurrentTime += Time.deltaTime;
        if (CurrentTime >= GameDurationSec)
            EndGame();
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        OnGamePause?.Invoke();
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        OnGameResume?.Invoke();
    }

    public void StartGame()
    {
        if (gameIsStarted)
            return;

        gameIsStarted = true;
        gameIsPaused = false;
        gameIsEnded = false;
        CurrentTime = START_TIME;
        OnGameStart?.Invoke();
    }

    public void EndGame()
    {
        if (GameIsEnded)
            return;

        Debug.Log("GAME OVER!!");
        gameIsStarted = false;
        gameIsEnded = true;
        OnGameEnd?.Invoke();
    }
}
