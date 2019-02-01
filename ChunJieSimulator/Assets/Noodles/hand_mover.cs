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
#if UNITY_EDITOR
        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);
#else
        float moveDirection = 0;
        if (Input.touchCount>0) {
            moveDirection = (Input.GetTouch(0).position.x < Screen.width / 2) ? -1 : 1;
        }
        transform.Translate(moveDirection * speed, 0, 0);
#endif
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
