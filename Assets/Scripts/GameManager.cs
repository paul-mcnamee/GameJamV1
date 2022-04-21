using System;
using UnityEngine;
using Utils;

public class GameManager : Singleton<GameManager>
{
    // TODO: Score
    // TODO: GameTimer
    // TODO: Player Controls

    public Camera Camera => General.MainCamera;
    private GameTimer GameTimer => GameTimer.Instance;

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
        // show a score summary
        throw new NotImplementedException();
    }

    private void OnGameStart()
    {
        // Play an animation or something
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        GameTimer.OnGameStart -= OnGameStart;
        GameTimer.OnGameEnd -= OnGameEnd;
    }

}
