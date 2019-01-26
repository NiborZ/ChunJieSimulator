using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDoor : MonoBehaviour
{
    RaycastHit2D[] hits = new RaycastHit2D[16];

    void Start()
    {
    }

    float timer = 2f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer += 2f;
            GameObject enterPassenger = null;
            float minDistence = float.MaxValue;
            int hitConut = Physics2D.CircleCastNonAlloc(transform.position, 2f, Vector2.zero, hits);
            for (int i = 0; i < hitConut; i++) {
                if (hits[i].transform.GetComponentInParent<CrowMan>() || hits[i].transform.GetComponentInParent<CrowController>()) {
                    float distance = Vector2.Distance(hits[i].transform.position, transform.position);
                    if (distance < minDistence) {
                        minDistence = distance;
                        enterPassenger = hits[i].transform.gameObject;
                    }
                }
            }
            if (enterPassenger) {
                //Destroy(enterPassenger);
                enterPassenger.GetComponentInChildren<Collider2D>().enabled = false;
                Sequence se = DOTween.Sequence();
                se.Append(enterPassenger.transform.DOMove(transform.position, 1f));
                se.AppendCallback(() => {
                    if (enterPassenger.GetComponent<CrowController>()) {
                        Debug.Log("Success");
                    }
                    Destroy(enterPassenger);
                });
            }
        }
    }

}

