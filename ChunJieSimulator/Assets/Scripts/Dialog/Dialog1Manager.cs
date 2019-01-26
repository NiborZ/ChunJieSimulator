using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog1Manager : MonoBehaviour
{
    public Text text1;
    public LevelManager levelManager;
    void Start()
    {
        StartCoroutine(textPresenter());
    }

    IEnumerator textPresenter()
    {
        text1.text = "我叫王力红，现在在深圳北极熊科技有限公司做码农，今年攒了八千八百八十八，准备过年回家发发发。";
        yield return new WaitForSeconds(5);
        text1.text = "这天凌晨三点下班回家，我却突然想到......";
        yield return new WaitForSeconds(3);
        text1.text = "过年回家的车票还没买";
        yield return new WaitForSeconds(3);
        //levelManager.loadNextScene();
    }
}
