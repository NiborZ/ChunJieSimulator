 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog1ManagerBad : MonoBehaviour
{
    public Text text1;
    public LevelManager levelManager;
    void Start()
    {
        buyTicketBadResult();
    }

    public void buyTicketBadResult()
    {
        StartCoroutine(textPresenterBad());
    }

    IEnumerator textPresenterBad()
    {
        text1.text = "王力红没能抢到票，只能在黄牛那里花五倍的价格买了一张20个小时的特快绿皮站票，难过的踏上了回家的旅程。";
        yield return new WaitForSeconds(5);
        text1.text = "几天后，我骑着心爱的三蹦子，奔向火车站。";
        LevelManager.Instance.loadScene("S4_GameDriving");
    }
}
