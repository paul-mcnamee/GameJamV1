using System;
using Utils;
using static Utils.Constants;

public class GameTimer : Singleton<GameTimer>
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public float CurrentTime { get; private set; } = START_TIME;

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
        OnGameStart?.Invoke();
    }

    private void OnDisable()
    {
        OnGameEnd?.Invoke();
    }
}
