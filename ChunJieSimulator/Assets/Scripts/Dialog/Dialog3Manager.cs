using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog3Manager : MonoBehaviour
{
    public GameObject player;
    public Text text1;
    public DialogConfig dialog;
    void Start() {
        //StartCoroutine(textPresenter());
        StartCoroutine(presenter1());
    }

    IEnumerator presenter1() {
        yield return new WaitForSeconds(2);
        Instantiate(dialog);
        dialog.GetComponent<DialogConfig>().Show(dialogFinished);
    }

    IEnumerator textPresenter() {
        Instantiate(player);
        text1.text = "时间快到了，要准备上火车了。";
        yield return new WaitForSeconds(3);
        text1.text = "看到面前茫茫人海，我不禁皱起了眉头。";
        yield return new WaitForSeconds(3);
        LevelManager.Instance.loadNextScene();
    }

    public void dialogFinished() {
        LevelManager.Instance.loadNextScene();
        Destroy(dialog);
        //Instantiate(player);
    }
}
