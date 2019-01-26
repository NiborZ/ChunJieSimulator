using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private static DialogController _Instance;
    public static DialogController Instance {
        get {
            if (!_Instance) {
                var canvasGo = GameObject.Find("Canvas");
                if (canvasGo) {
                    if (canvasGo.GetComponent<DialogController>()) {
                        _Instance = canvasGo.GetComponent<DialogController>();
                    } else {
                        _Instance = canvasGo.AddComponent<DialogController>();
                    }
                }
            }
            return _Instance;
        }
    }

    internal DialogConfig currentDialog;

    public void ShowOptions(List<DialogConfig> dialogs, Action onComplete) {
        CreateDialogOptions(dialogs, onComplete);
    }
    public void ShowDialog(string dialog) {
        CreateDialogMask(dialog);
    }
    public void ShowDialog(Transform npc, string dialog) {
        var mask = CreateDialogMask(dialog);
        mask.transform.position = mask.GetComponent<RectTransform>().InverseTransformPoint(npc.transform.position);
    }
    public void ShowDialog(string npcName, string dialog) {
        CreateDialogMask(dialog);
    }
    /// <summary>
    /// 创建单个对话的隐式Button
    /// </summary>
    GameObject CreateDialogMask(string dialog) {
        var mask = Instantiate<GameObject>(Resources.Load<GameObject>("btn_mask"), transform);
        mask.tag = "Dialog";
        mask.transform.Find("text").GetComponent<Text>().text = dialog;
        mask.GetComponent<Button>().onClick.RemoveAllListeners();
        mask.GetComponent<Button>().onClick.AddListener(()=> {
            if (currentDialog) {
                currentDialog.Trigger();
            }
        });
        return mask;
    }
    /// <summary>
    /// 创建带有多个选项的对话
    /// </summary>
    void CreateDialogOptions(List<DialogConfig> dialogs, Action onComplete) {
        var options = Instantiate<GameObject>(Resources.Load<GameObject>("btn_options"), transform);
        options.tag = "Dialog";
        var root = options.transform.Find("root");
        var proto = root.GetChild(0).gameObject;
        foreach (var dialog in dialogs) {
            var tempDialog = dialog;
            var go = Instantiate<GameObject>(proto, root);
            go.SetActive(true);
            go.GetComponentInChildren<Text>().text = dialog.name;
            go.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            go.GetComponentInChildren<Button>().onClick.AddListener(()=> {
                tempDialog.Show(onComplete);
            });
        }
    }
    public void ClearAllDialogs() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).CompareTag("Dialog")) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

}
