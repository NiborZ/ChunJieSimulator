using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelValification : MonoBehaviour
{
    int refreshCount;
    int currentIndex;
    List<int> funnyIndexes = new List<int>() {
        0, 1, 2
    };
    List<int> normalIndexes = new List<int>() {
        3, 4
    };
    Transform trValificationRoot;
    Transform trValidateError;
    internal List<ValifyTag> validTags = new List<ValifyTag>();
    private void Awake() {
        trValificationRoot = transform.Find("content");
        trValidateError = transform.Find("validate_error");
        Refresh();
    }
    public void Refresh() {
        foreach (var tag in validTags) {
            Destroy(tag.gameObject);
        }
        validTags.Clear();
        refreshCount++;
        if (refreshCount < 3) {
            currentIndex = funnyIndexes[Random.Range(0, funnyIndexes.Count)];
            funnyIndexes.Remove(currentIndex);
        } else if (normalIndexes.Count > 0) {
            currentIndex = normalIndexes[Random.Range(0, normalIndexes.Count)];
            normalIndexes.Remove(currentIndex);
        } else {
            GetComponentInParent<UITicket>().ShotDown();
        }
        for (int i = 0; i < trValificationRoot.childCount; i++) {
            trValificationRoot.GetChild(i).gameObject.SetActive(i == currentIndex);
        }
    }

    public bool IsValidate() {
        if (trValificationRoot.GetChild(currentIndex).GetComponentsInChildren<ValifyImage>().Length == 0) {
            trValidateError.gameObject.SetActive(true);
            return false;
        } else {
            bool valid = true;
            foreach (var validImage in trValificationRoot.GetChild(currentIndex).GetComponentsInChildren<ValifyImage>()) {
                valid &= validImage.IsValidate(validTags);
            }
            trValidateError.gameObject.SetActive(!valid);
            return valid;
        }
    }

    public void OnClickValidate() {
        bool valid = IsValidate();
        trValidateError.gameObject.SetActive(!valid);
        Debug.Log("Valid:" + valid);
        if (valid) {
            GetComponentInParent<UITicket>().ShowSuccess();
        } else {
            Refresh();
        }
    }

    public void OnClickImage() {
        var tag = Instantiate<GameObject>(Resources.Load<GameObject>("valify_tag"), transform);
        tag.transform.localScale = Vector2.one;
        tag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        validTags.Add(tag.GetComponent<ValifyTag>());
    }

}
