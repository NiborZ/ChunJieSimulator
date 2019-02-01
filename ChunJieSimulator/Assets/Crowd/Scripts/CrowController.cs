using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrowController : MonoBehaviour
{
    public Sprite smile;
    Rigidbody2D rigid;
    RaycastHit2D[] hits = new RaycastHit2D[8];
    internal bool controllable = true;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Smile() {
        transform.Find("img").localScale = new Vector3(1, 1, 1);
        GetComponentInChildren<SpriteRenderer>().sprite = smile;
    }
    void Update() {
        if (controllable) {
#if UNITY_EDITOR
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //rigid.AddForce(input);
            rigid.velocity = input * 2;
            if (Input.GetKeyDown(KeyCode.Space)) {
                Push();
            }
#else
            if (Input.touchCount > 0) {
                foreach (var t in Input.touches) {
                    if (t.phase == TouchPhase.Began) {
                        Push();
                    }
                }
                var touch = Input.GetTouch(0);
                Vector2 direction = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                //rigid.AddForce(input);
                rigid.velocity = direction.normalized * 2;
            }
#endif
        }
    }
    void Push() {
        int hitConut = Physics2D.CircleCastNonAlloc(transform.position, 0.75f, Vector2.zero, hits);
        for (int i = 0; i < hitConut; i++) {
            if (hits[i].collider.GetComponentInParent<Rigidbody2D>() && hits[i].transform.position.x > transform.position.x) {
                var dir = (hits[i].transform.position - transform.position);
                dir.z = 0;
                dir.x *= 0.1f;
                dir = dir.normalized;
                hits[i].collider.GetComponentInParent<Rigidbody2D>().AddForce(dir * 300);
                if (hits[i].collider.GetComponentInParent<CrowMan>()) {
                    hits[i].collider.GetComponentInParent<CrowMan>().Hit();
                }
            }
        }
    }
}
