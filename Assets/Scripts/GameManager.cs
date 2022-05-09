using System;
using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    public Camera Camera => General.MainCamera;
    [HideInInspector] private GameTimer GameTimer;
    [HideInInspector] private ScoreManager ScoreManager;
    [HideInInspector] private MenuManager MenuManager;

    protected override void OnAwake()
    {
        base.OnAwake();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameTimer = GameTimer.Instance;

        GameTimer.OnGameStart += OnGameStart;
        GameTimer.OnGameEnd += OnGameEnd;

        ScoreManager = ScoreManager.Instance;
        MenuManager = MenuManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGameEnd()
    {
        // TODO: Show a score summary
    }

    private void OnGameStart()
    {
        // TODO: Play an animation or something
    }

    private void OnDestroy()
    {
        if (GameTimer != null)
        {
            GameTimer.OnGameStart -= OnGameStart;
            GameTimer.OnGameEnd -= OnGameEnd;
        }
    }
}
