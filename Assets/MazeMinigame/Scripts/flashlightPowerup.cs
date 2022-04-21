using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPowerup : MonoBehaviour, Powerup
{
    public int flashlightDuration = 5;
    private SpriteMask mask;

    public  void powerup(GameObject character) 
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false ;
        gameObject.GetComponent<BoxCollider2D>().enabled = false ;
        mask = character.GetComponentInChildren<SpriteMask>();
        mask.transform.localScale = mask.transform.localScale * 2;
        StartCoroutine(FlashActive());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    IEnumerator FlashActive()
    {
        yield return new WaitForSeconds(flashlightDuration);
        mask.transform.localScale = mask.transform.localScale / 2;

    }
}

 
