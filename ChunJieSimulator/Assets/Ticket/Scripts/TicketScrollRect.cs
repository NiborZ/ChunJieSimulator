using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TicketScrollRect : ScrollRect
{
    /// <summary>
    /// 上滑刷新, 模拟12306APP功能
    /// </summary>
    public override void OnEndDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        if (content.anchoredPosition.y < -75) {
            GetComponentInParent<UITicket>().RefreshTickets();
        }
    }
}
