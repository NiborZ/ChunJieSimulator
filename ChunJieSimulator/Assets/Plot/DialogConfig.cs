using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConfig : MonoBehaviour
{
    public Transform npc;
    public string npcName;
    public string dialog;
    Action onComplete;

    public virtual void Show(Action onComplete) {
        this.onComplete = onComplete;
        DialogController.Instance.ClearAllDialogs();
        DialogController.Instance.currentDialog = this;
        if (npc) {
            DialogController.Instance.ShowDialog(npc, dialog);
        } else if (!string.IsNullOrEmpty(npcName)) {
            DialogController.Instance.ShowDialog(npcName, dialog);
        } else {
            DialogController.Instance.ShowDialog(dialog);
        }
    }
    /// <summary>
    /// 触发这个对话
    /// </summary>
    /// <returns>是否销毁自身</returns>
    public virtual void Trigger() {
        List<DialogConfig> dialogs = new List<DialogConfig>();
        foreach (var dialog in GetComponentsInChildren<DialogConfig>()) {
            if (dialog.transform.parent == transform) {
                dialogs.Add(dialog);
            }
        }
        if (dialogs.Count == 1) {
            dialogs[0].Show(onComplete);
        } else if (dialogs.Count >= 2) {
            DialogController.Instance.ShowOptions(dialogs, this.onComplete);
        } else {
            DialogController.Instance.ClearAllDialogs();
            if (onComplete != null) {
                onComplete();
            }
        }
    }

    [Button("Show This Dialog")]
    public void ShowDialogTest() {
        Show(null);
    }
}
