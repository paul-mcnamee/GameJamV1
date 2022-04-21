using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTimer : MonoBehaviour
{
    public SpriteRenderer Left;
    public SpriteRenderer Right;
    public SpriteRenderer Middle;

    private void Awake()
    {
        Vector2 initialMiddleSize = Middle.size;
        Middle.size = new Vector2(0f, initialMiddleSize.y);
        Middle.transform.position = new Vector2(Left.transform.position.x, Left.transform.position.y);
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
