using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadscene : MonoBehaviour
{
    
    public float display_interval = 2.0f;
    private float clock = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= display_interval)
        {
            Debug.Log("Just above Level Manager");
            LevelManager.Instance.loadNextScene();
        }
    }
}
