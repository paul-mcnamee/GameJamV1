using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPowerup : MonoBehaviour, Powerup
{
    public int spawnRate = 35;
    public float speedModifier = 0.5f;

    public int getSpawnRate()
    {
        return spawnRate;
    }

    public void powerup(GameObject character)
    {
        character.GetComponent<Character>().speedModifier += speedModifier;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
