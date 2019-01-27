using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotater : MonoBehaviour
{
    public float wait = 2.0f;
    private float clock = 0.0f;
    public float rotate_freq = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if(clock >= wait)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

    }
}
