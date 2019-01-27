using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_mover : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);
    }

    //void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.character == 'a')
    //    {
    //        this.gameObject.transform.Translate(-speed, 0, 0);
    //    }
    //    if (e.character == 'd')
    //    {
    //        this.gameObject.transform.Translate(speed, 0, 0);
    //    }
    //}
}
