using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float flip_interval = 0.9f;
    private float clock = 0.0f;
    private int direction = -1;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        this.gameObject.transform.Translate(direction * speed, 0, 0);
        if (clock >= flip_interval)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = !this.gameObject.GetComponent<SpriteRenderer>().flipX;
            direction = -direction;
            clock = 0.0f;
        }
    }
}
