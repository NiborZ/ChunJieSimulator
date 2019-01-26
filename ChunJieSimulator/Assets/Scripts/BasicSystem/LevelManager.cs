using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] sceneNames;

    private int currentSceneNum;

    public int getCurrentSceneNumber()
    {
        return currentSceneNum;
    }

    public void loadNextScene()
    {
        currentSceneNum++;
        SceneManager.LoadScene(sceneNames[currentSceneNum]);
    }
    public void loadStartScene()
    {
        currentSceneNum = 0;
        SceneManager.LoadScene(sceneNames[currentSceneNum]);
    }
}
