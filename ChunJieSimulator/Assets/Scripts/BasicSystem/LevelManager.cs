using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    private LevelManager() { }
    static private LevelManager _Instance;
    static public LevelManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                return _Instance;
            }
            return _Instance;
        }
    }

    public static string[] scenes = new string[]
    {
        "S0_MainMenu",
        "S1_Dialog1",
        "S2_GameScrambleTicket",
        "S3_Dialog1Good",
        "S3_DialogBad",
        "S4_GameDriving",
        "S5_Dialog2",
        "S6_Dialog3",
        "S7_GameCrowd",
        "S8_Dialog4",
        "S9_GameMakeInstantNoodle",
        "S10_Dialog5"
    };

    private int currentSceneNum;

    private void Start()
    {
        currentSceneNum = 0;
    }

    public int getCurrentSceneNumber()
    {
        return currentSceneNum;
    }

    public void loadScene(string targetScene)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            if (targetScene == scenes[i])
            {
                currentSceneNum = i;
            }
        }
        SceneManager.LoadScene(targetScene);
    }
    public void loadNextScene()
    {
        currentSceneNum++;
        SceneManager.LoadScene(scenes[currentSceneNum]);
    }
    public void restart()
    {
        SceneManager.LoadScene(scenes[currentSceneNum]);
    }
    public void loadStartScene()
    {
        currentSceneNum = 0;
        SceneManager.LoadScene(scenes[currentSceneNum]);
    }
}
