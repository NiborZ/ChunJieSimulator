using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 抢票窗口
/// </summary>
public class UITicket : MonoBehaviour
{
    public Transform trSoldOut;
    public Transform trQueue;
    public Transform trWait;
    public Transform trSuccess;
    public Transform trShutDown;
    public PanelValification pnValidfication;

    /// <summary>
    /// 展示票已售罄消息
    /// </summary>
    internal void ShowSoldOut() {
        trQueue.gameObject.SetActive(false);
        trSoldOut.gameObject.SetActive(true);
        Pause();
    }
    /// <summary>
    /// 展示排队消息
    /// </summary>
    internal void ShowQueue() {
        Pause();
        queueSoldOut = true;
        trQueue.gameObject.SetActive(true);
        Invoke("ShowSoldOut", 8f);
    }
    bool queueSoldOut;
    /// <summary>
    /// 展示验证码界面
    /// </summary>
    internal void ShowValification() {
        ShowWaiting(()=> {
            pnValidfication.gameObject.SetActive(true);
        });
    }
    /// <summary>
    /// 展示等待界面
    /// </summary>
    Action waitCallback;
    internal void ShowWaiting(Action callback) {
        waitCallback = callback;
        trWait.gameObject.SetActive(true);
        CancelInvoke("EndWaiting");
        Invoke("EndWaiting", UnityEngine.Random.Range(0.5f, 1f));
    }

    /// <summary>
    /// 关机
    /// </summary>
    internal void ShotDown() {
        trShutDown.gameObject.SetActive(true);
        Sequence se = DOTween.Sequence();
        se.AppendInterval(2f);
        se.AppendCallback(()=> 
        {
            trShutDown.Find("tips").gameObject.SetActive(false);
        });
    }

    internal void EndWaiting() {
        trWait.gameObject.SetActive(false);
        if (waitCallback != null) {
            waitCallback();
        }
    }

    public void OnClickSoldOutClose() {
        trSoldOut.gameObject.SetActive(false);
        trQueue.gameObject.SetActive(false);
        Continue();
        if (queueSoldOut) {
            RefreshTickets();
        }
        queueSoldOut = false;
    }

    public void Pause() {
        foreach (var ticket in GetComponentsInChildren<Ticket>()) {
            ticket.pause = true;
        }
    }
    public void Continue() {
        foreach (var ticket in GetComponentsInChildren<Ticket>()) {
            ticket.pause = false;
        }
    }
    public void RefreshTickets() {
        ShowWaiting(() => {
            foreach (var ticket in GetComponentsInChildren<Ticket>()) {
                ticket.Refresh();
            }
        });
    }

    internal void ShowSuccess() {
        ShowWaiting(() => {
            pnValidfication.gameObject.SetActive(false);
            trSuccess.gameObject.SetActive(true);
        });
    }

    public void RefreshVilication() {
        ShowWaiting(() => {
            pnValidfication.gameObject.SetActive(true);
        });
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F5)) {
            RefreshTickets();
        }
    }

    /// <summary>
    /// 牛哥我又来见您了
    /// </summary>
    public void YellowCow() {

    }

}
