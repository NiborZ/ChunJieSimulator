using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMan : MonoBehaviour
{
    public Transform door;
    Rigidbody2D rigid;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        var dir = (door.position - transform.position);
        dir.z = 0;
        dir = dir.normalized * 4;
        rigid.AddForce(dir);
    }
}
