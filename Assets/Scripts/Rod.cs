using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rod : MonoBehaviour
{
    public PowerGauge powerGague;
    public Rigidbody2D hookRb;
    public float angle = 45f;
    public float force = 2f;
    private Vector3 initPos;
    private IEnumerator hookCoroutine;
    private GameTimer gameTimer;

    private void Awake()
    {
        initPos = hookRb.gameObject.transform.position;
    }

    void Start()
    {
        gameTimer = GameTimer.Instance;
        gameTimer.OnGameEnd += StopHook;
        gameTimer.StartGame();
        DisableHook();
    }

    private void OnDestroy()
    {
        if (gameTimer != null)
        {
            gameTimer.OnGameEnd -= StopHook;
        }
    }

    private void StopHook()
    {
        if (hookCoroutine != null)
            StopCoroutine(hookCoroutine);
        DisableHook();
    }

    private void DisableHook()
    {
        hookRb.gameObject.SetActive(false);
        hookRb.gameObject.transform.position = initPos;
        hookRb.velocity = Vector2.zero;
        hookRb.gameObject.SetActive(true);
        hookRb.Sleep();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fish>(out var fish))
        {
            // TODO: WIN!
            Debug.Log("you win the game, you got the Fish");
            ScoreManager.Instance.AddScore();
            return;
        } 
        else if (collision.gameObject.TryGetComponent<Bomb>(out var bomb))
        {
            // TODO: LOSE!
            Debug.Log("you lose the game, you hit a Bomb");
            GameTimer.Instance.EndGame();
            return;
        }
        else if (collision.gameObject.TryGetComponent<Seagull>(out var seagull))
        {
            // TODO: LOSE!
            Debug.Log("you lose the game, you hit a Seagull");
            GameTimer.Instance.EndGame();
            return;
        }

        Debug.Log("you hit something, not sure what...");
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameTimer.Instance.GameIsEnded)
                return;
            hookCoroutine = LaunchHook();
            StartCoroutine(hookCoroutine);
        }
    }

    private IEnumerator LaunchHook()
    {
        hookRb.WakeUp();
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force * powerGague.CurrentPowerPercentage;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force * powerGague.CurrentPowerPercentage;
        hookRb.AddForce(new Vector2(xcomponent, ycomponent), ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);

        DisableHook();
        yield return null;
    }

}
