using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{
    static Color Green = new Color(0.2235294f, 0.6196079f, 0.2588235f, 1);
    static Color Gray = new Color(0.627451f, 0.6196079f, 0.627451f, 1);


    public bool valid;
    bool hasTickey;
    int hardSeat;
    int noSeat;
    int buyTime;
    internal Text txHardSeat;
    internal Text txNoSeat;

    private void Awake() {
        txHardSeat = transform.Find("hardseat_ticket").GetComponentInChildren<Text>();
        txNoSeat = transform.Find("noseat_ticket").GetComponentInChildren<Text>();
        if (valid) {
            SetHardSeat(1);
            SetNoSeat(100);
        } else {
            SetHardSeat(0);
            SetNoSeat(0);
        }
    }

    public void Refresh() {
        if (valid && noSeat != 100) {
            SetHardSeat(0);
            SetNoSeat(Random.Range(0, 10) < 6 ? 1 : 0);
            if (noSeat == 1) {
                if ((buyTime > 1 && Random.Range(0, 5) < buyTime) || buyTime > 4) {
                    hasTickey = true;
                } else {
                    hasTickey = false;
                }
            }
            //sellingCountDown = Random.Range(0.25f, 1f);
            pause = false;
        }
    }

    public void SetHardSeat(int count) {
        hardSeat = count;
        txHardSeat.text = count > 10 ? "有" : count > 0 ? count.ToString() : "无";
        txHardSeat.color = count > 0 ? Green : Gray;
    }
    public void SetNoSeat(int count) {
        noSeat = count;
        txNoSeat.text = count > 10 ? "有" : count > 0 ? count.ToString() : "无";
        txNoSeat.color = count > 0 ?  Green: Gray;
    }

    public void OnClickTicket() {
        if (hardSeat == 0 && noSeat == 0) {
            GetComponentInParent<UITicket>().ShowSoldOut();
        } else {
            if (noSeat == 100) {
                hardSeat = 0;
                noSeat = 1;
                GetComponentInParent<UITicket>().ShowQueue();
            } else {
                if (hasTickey) {
                    GetComponentInParent<UITicket>().ShowValification();
                } else {
                    buyTime++;
                    GetComponentInParent<UITicket>().ShowSoldOut();
                }
            }
        }
    }

    internal bool pause;
    //float sellingCountDown = 0f;
    //private void Update() {
    //    if (!pause) {
    //        if (noSeat > 0 && noSeat < 10) {
    //            sellingCountDown -= Time.deltaTime;
    //            if (sellingCountDown < 0) {
    //                sellingCountDown = Random.Range(0.25f, 1f);
    //                SetNoSeat(noSeat - 1);
    //            }
    //        }
    //    }
    //}
}
