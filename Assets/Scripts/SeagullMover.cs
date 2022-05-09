using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeagullMover : MonoBehaviour
{
    private Queue<Seagull> Seagulls;
    public float SeagullMovingSpeedFactor = 1f;
    public float BaseSeagullMoveTime = 3f;
    private IEnumerator moveSeagullCoroutine;
    private GameTimer gameTimer;

    private void Awake()
    {
        var gulls = this.gameObject.GetComponentsInChildren<Seagull>();
        Seagulls = new Queue<Seagull>(gulls);
        Debug.Log("seagull count: " + Seagulls.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameTimer.Instance; ;
        gameTimer.OnGameEnd += DisableGulls;
        moveSeagullCoroutine = MoveSeagull();
        StartCoroutine(moveSeagullCoroutine);
    }

    private void DisableGulls()
    {
        StopCoroutine(moveSeagullCoroutine);
    }

    private IEnumerator MoveSeagull()
    {
        Seagull gullToMove = Seagulls.Dequeue();
        var initPos = gullToMove.gameObject.transform.position;
        var camHeight = 2f * GameManager.Instance.Camera.orthographicSize;
        var camWidth = camHeight * GameManager.Instance.Camera.aspect;
        var newPos = new Vector3(initPos.x - 2 * camWidth, initPos.y + camHeight * Random.Range(-1.3f, 1.2f));
        var moveTime = (BaseSeagullMoveTime * SeagullMovingSpeedFactor) * Random.Range(0.7f, 1.0f);
        gullToMove.gameObject.SetActive(true);
        gullToMove.transform.DOMove(newPos, moveTime);
        yield return new WaitForSeconds(moveTime);

        gullToMove.gameObject.SetActive(false);
        gullToMove.gameObject.transform.position = initPos;
        Seagulls.Enqueue(gullToMove);
        yield return MoveSeagull();
    }

    private void OnDestroy()
    {
        if (gameTimer != null)
        {
            gameTimer.OnGameEnd -= DisableGulls;
        }
    }
}
