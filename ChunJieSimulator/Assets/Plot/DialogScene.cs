using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogScene : DialogConfig
{
    public string targetScene;
    public override void Show(Action onComplete) {
        SceneManager.LoadScene(targetScene);
    }
}
