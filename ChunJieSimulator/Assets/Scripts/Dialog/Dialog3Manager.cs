using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog3Manager : MonoBehaviour
{
    public Text text1;
    void Start()
    {
        StartCoroutine(textPresenter());
    }

    IEnumerator textPresenter()
    {
        text1.text = "时间快到了，要准备上火车了。";
        yield return new WaitForSeconds(3);
        text1.text = "看到面前茫茫人海，我不禁皱起了眉头。";
        yield return new WaitForSeconds(3);
        LevelManager.Instance.loadNextScene();
    }
}
