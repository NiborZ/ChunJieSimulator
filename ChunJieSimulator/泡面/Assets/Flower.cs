using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float change_dir_interval = 0.9f;
    private float clock = 0.0f;
    private int direction = -1;//-1 down 1 up
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0, direction * speed, 0);
        clock += Time.deltaTime;
        if(clock >= change_dir_interval)
        {
            direction = -direction;
            clock = 0.0f;
        }
    }
}
