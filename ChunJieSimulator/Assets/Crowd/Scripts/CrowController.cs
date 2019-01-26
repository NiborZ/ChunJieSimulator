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
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //rigid.AddForce(input);
            rigid.velocity = input * 2;
            if (Input.GetKeyDown(KeyCode.Space)) {
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
    }
}
