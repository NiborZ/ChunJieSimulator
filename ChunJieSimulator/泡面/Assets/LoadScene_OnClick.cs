using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene_OnClick : MonoBehaviour
{
    public Button btn;
    public Scene onclick_scene; 
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(loadScene);
    }

    void loadScene()
    {
        Scene active_scene = SceneManager.GetActiveScene();
        //SceneManager.UnloadSceneAsync(active_scene.name);
        if (btn.name == "Button (1)")
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (btn.name == "Button (2)")
        {
            //SceneManager.LoadScene("TestScene_2", LoadSceneMode.Single);
            SceneManager.UnloadSceneAsync(active_scene.name);
            Application.Quit(1);
            Debug.Log("quit with exit code 1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
