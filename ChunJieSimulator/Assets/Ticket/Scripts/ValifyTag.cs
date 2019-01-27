using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValifyTag : MonoBehaviour
{
    public void OnClick() {
        if (GetComponentInParent<PanelValification>() && GetComponentInParent<PanelValification>().validTags.Contains(this)) {
            GetComponentInParent<PanelValification>().validTags.Remove(this);
        }
        Destroy(gameObject);
    }
}
