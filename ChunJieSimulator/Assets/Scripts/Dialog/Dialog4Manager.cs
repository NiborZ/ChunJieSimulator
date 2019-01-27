using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog4Manager : MonoBehaviour
{
    public Text text1;
    public LevelManager levelManager;
    public GameObject player;
    public GameObject dialog1;
    public GameObject dialog1Obj;
    public GameObject dialog2;
    public GameObject dialog2Obj;

    void Start()
    {
        StartCoroutine(presenter1());
    }

    IEnumerator presenter1()
    {
        yield return new WaitForSeconds(3);
        dialog1Obj = Instantiate(dialog1);
        dialog1.GetComponent<DialogConfig>().Show(dialog1Finished);

    }

    public void dialog1Finished()
    {
        Debug.Log("Dialog Finished");
        Destroy(dialog1Obj);
        Instantiate(player);
        dialog2Obj = Instantiate(dialog2);
        dialog2.GetComponent<DialogConfig>().Show(dialog2Finished);
    }

    public void dialog2Finished()
    {
        Debug.Log("Dialog Finished");
        Destroy(dialog2Obj);
        LevelManager.Instance.loadNextScene();
    }
}
