using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValifyImage : MonoBehaviour
{
    public bool isTrue;
    public bool IsValidate(List<ValifyTag> tags) {
        var bounds = GetComponent<Collider2D>().bounds;
        if (isTrue) {
            foreach (var tag in tags) {
                if (bounds.Contains(tag.GetComponent<RectTransform>().position)) {
                    return true;
                }
            }
            return false;
        } else {
            foreach (var tag in tags) {
                if (bounds.Contains(tag.GetComponent<RectTransform>().position)) {
                    return false;
                }
            }
            return true;
        }
    }
}
