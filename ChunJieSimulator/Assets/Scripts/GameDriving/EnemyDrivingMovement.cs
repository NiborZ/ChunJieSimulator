using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrivingMovement : MonoBehaviour
{
    public float eSpeed;
    public int enemyType;

    private Vector3 drivingForce;
    private Animator enemyAnimator;

    private void Start()
    {
        drivingForce = new Vector3(0f, -eSpeed, 0f);
        enemyAnimator = gameObject.GetComponent<Animator>();
        enemyAnimator.SetBool("CarBool" +enemyType, true);
    }

    private void Update()
    {
        transform.Translate(drivingForce);
    }

    public void inverseDirection()
    {
        if(enemyType!=6)
            drivingForce = new Vector3(0f, eSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objTag = other.transform.tag;
        if (objTag == "Player")
        {
            Debug.Log("Crash player");
            other.GetComponent<PlayerDrivingMovement>().drivingController.playerLoseHealth();
            if(enemyType == 6)
            {
                enemyAnimator.SetBool("FenceBool", true);
                drivingForce = Vector3.zero;
                Destroy(gameObject, 2f);
            }
            else
            {
                inverseDirection();
            }
        }
        else if (objTag == "DisappearZone")
        {
            //PlayWarning Audio
            Debug.Log("Enter disappear zone");
            Destroy(gameObject);
        }
        else
        {
            //Do Nothing
        }
    }
}
