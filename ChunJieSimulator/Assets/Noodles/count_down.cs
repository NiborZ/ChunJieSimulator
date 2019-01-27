using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class count_down : MonoBehaviour
{
    public float game_time = 30.0f;
    private float clock = 0.0f;
    public Scrollbar sb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        sb.size = clock / game_time;
        if (clock >= game_time)
        {
            SceneManager.LoadScene("vic_noodle", LoadSceneMode.Single);
        }
    }
}
