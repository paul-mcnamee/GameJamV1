using System;
using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    // TODO: Score
    // TODO: Player Controls

    public Camera Camera => General.MainCamera;
    public GameTimer GameTimer => GameTimer.Instance;
    public ScoreManager ScoreManager => ScoreManager.Instance;

    protected override void OnAwake()
    {
        base.OnAwake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameTimer.OnGameStart += OnGameStart;
        GameTimer.OnGameEnd += OnGameEnd;
    }

    private void OnGameEnd()
    {
        // TODO: Show a score summary
    }

    private void OnGameStart()
    {
        // TODO: Play an animation or something
    }

    private void OnDisable()
    {
        GameTimer.OnGameStart -= OnGameStart;
        GameTimer.OnGameEnd -= OnGameEnd;
    }

}
