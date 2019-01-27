using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog2Manager : MonoBehaviour
{
    public Text text1;
    public LevelManager levelManager;
    public GameObject player;
    public GameObject dialog1;
    public GameObject dialog1Obj;
    public GameObject dialog2;
    public GameObject dialog2Obj;
    public GameObject dialog3;
    public GameObject dialog3Obj;
    public GameObject npcGirl;
    public GameObject npcMan;

    void Start()
    {
        StartCoroutine(presenter1());
    }

    IEnumerator presenter1()
    {
        yield return new WaitForSeconds(3);
        Instantiate(player);
        yield return new WaitForSeconds(2);
        dialog1Obj = Instantiate(dialog1);
        dialog1.GetComponent<DialogConfig>().Show(dialog1Finished);

    }

    public void dialog1Finished()
    {
        Debug.Log("Dialog Finished");
        Destroy(dialog1Obj);
        Instantiate(npcGirl);
        dialog2Obj = Instantiate(dialog2);
        dialog2.GetComponent<DialogConfig>().Show(dialog2Finished);
    }

    public void dialog2Finished()
    {
        Debug.Log("Dialog Finished");
        Destroy(dialog2Obj);
        StartCoroutine(presenter2());

    }
    IEnumerator presenter2()
    {
        yield return new WaitForSeconds(3);
        Instantiate(npcMan);
        yield return new WaitForSeconds(2);
        dialog3Obj = Instantiate(dialog3);
        dialog3.GetComponent<DialogConfig>().Show(dialog3Finished);
    }

    public void dialog3Finished()
    {
        Debug.Log("Dialog Finished");
        Destroy(dialog3Obj);
        LevelManager.Instance.loadNextScene();
    }
}
