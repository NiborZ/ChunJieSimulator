using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog1ManagerGood : MonoBehaviour
{
    public Text text1;
    public LevelManager levelManager;
    void Start()
    {
        buyTicketGoodResult();
    }

    public void buyTicketGoodResult()
    {
        StartCoroutine(textPresenterGood());
    }

    IEnumerator textPresenterGood()
    {
        text1.text = "王力红顺利的抢到了20个小时的特快绿皮卧铺／硬座票，开心的踏上了回家的旅程。";
        yield return new WaitForSeconds(3);
        text1.text = "几天后，我骑着心爱的三蹦子，奔向火车站。";
        LevelManager.Instance.loadScene("S4_GameDriving");
    }

}
