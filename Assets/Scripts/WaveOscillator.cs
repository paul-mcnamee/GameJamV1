using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveOscillator : MonoBehaviour
{
    public List<Transform> WaveSets;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveWaves());
    }

    private IEnumerator MoveWaves()
    {
        WaveSets.ForEach(w =>
        {
            w.DOMove(new Vector3(Random.Range(-3f, 3f), Random.Range(-0.2f, 0.2f)), 3f);
        });
        yield return new WaitForSeconds(1f);

        yield return MoveWaves();
    }
}
