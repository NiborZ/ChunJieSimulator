using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog5Manager : MonoBehaviour
{
    public Text text1;
    public GameObject dialog1;
    public GameObject dialog1Obj;
    public GameObject background;
    public GameObject endground;

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
        Destroy(background);
        StartCoroutine(presenter2());
    }

    IEnumerator presenter2()
    {
        yield return new WaitForSeconds(3);
        text1.text = "据《春运报告》显示，我国每年有接近30亿人次的春运旅客量，每位旅客春运平均出行距离约700公里。";
        yield return new WaitForSeconds(4);
        text1.text = "人们就像归乡的候鸟，为了生计往返于神州大地。";
        yield return new WaitForSeconds(4);
        text1.text = "而王力红就是这芸芸众生中，最最普通的那一个。";
        yield return new WaitForSeconds(4);
        text1.text = "但无论是谁，无论路途上有多少磨难，我们都将回到，那个属于每个人，最温暖的地方。";
        yield return new WaitForSeconds(4);
        text1.text = "家";
        yield return new WaitForSeconds(4);
        Instantiate(endground);
        text1.text = "";
        yield return new WaitForSeconds(10);

    }

}
