using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMan : MonoBehaviour
{
    public Transform door;
    Rigidbody2D rigid;
    Sprite normalSprite;
    SpriteRenderer renderer;
    int hitTimes;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<SpriteRenderer>();
        normalSprite = GetComponentInParent<CrowEmoji>().GetNormalSprite();
        renderer.sprite = normalSprite;
    }

    public void Hit() {
        hitTimes++;
        renderer.sprite = GetComponentInParent<CrowEmoji>().GetHitSprite(hitTimes);
        CancelInvoke("HitBack");
        Invoke("HitBack", Random.Range(0.75f, 1.5f));
    }
    void HitBack() {
        hitTimes = 0;
        renderer.sprite = normalSprite;
    }
    public void Smile() {
        renderer.sprite = GetComponentInParent<CrowEmoji>().smileSprite;
    }

    void Update() {
        var dir = (door.position - transform.position);
        dir.z = 0;
        dir = dir.normalized * 4;
        rigid.AddForce(dir);
    }
}
