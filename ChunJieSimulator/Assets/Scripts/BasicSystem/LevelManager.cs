using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> sceneList;

    private int currentSceneNum;

    private void Start()
    {
        currentSceneNum = 0;
    }

    public int getCurrentSceneNumber()
    {
        return currentSceneNum;
    }

    public void loadNextScene()
    {
        currentSceneNum++;
        SceneManager.LoadScene(sceneList[currentSceneNum].name);
    }
    public void loadStartScene()
    {
        currentSceneNum = 0;
        SceneManager.LoadScene(sceneList[currentSceneNum].name);
    }
}
