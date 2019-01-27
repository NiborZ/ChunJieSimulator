using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrivingAcceleration : MonoBehaviour
{
    private float accelerateSpeed;
    private Vector3 aMovement;
    private Rigidbody2D speedometerRigidbody;
    private Vector3 originPos;

    public bool enableMove;
    public DrivingController drivingController;
    public float accelerateAmount;
    public float speedFast;
    public float speedMid;
    public float speedSlow;


    private void Awake()
    {
        enableMove = true;
        accelerateAmount = 50f;
        speedFast = 3f;
        speedometerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        speedometerRigidbody.Sleep();
        originPos = transform.position;
    }

    public void startAccelerate()
    {
        speedometerRigidbody.WakeUp();
    }

    public void controlPlayerAcceleration()
    {

        if(Input.GetKey(KeyCode.Space) && enableMove)
        {
            accelerateAmount += Time.deltaTime * speedFast;
            aMovement.Set(0f, accelerateAmount, 0f);
            aMovement = aMovement.normalized * speedFast * Time.deltaTime;
            speedometerRigidbody.MovePosition(transform.position + aMovement);
        }
    }

    public void resetPosition()
    {
        transform.position = originPos;
        speedometerRigidbody.gravityScale = 0.1f;
        enableMove = true;
    }

    public void gameFinish()
    {
        speedometerRigidbody.velocity = Vector3.zero;
        speedometerRigidbody.angularVelocity = 0f;
        speedometerRigidbody.gravityScale = 0f;
        enableMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string zoneTag = other.transform.tag;
        if(zoneTag == "RedZone" && !drivingController.playerCarStopped)
        {
            speedometerRigidbody.velocity = Vector3.zero;
            speedometerRigidbody.angularVelocity = 0f;
            speedometerRigidbody.gravityScale = 0f;
            enableMove = false;
            drivingController.playerLoseHealth();
        }
        else if (zoneTag == "RedZone" && drivingController.playerCarStopped)
        {
            speedometerRigidbody.velocity = Vector3.zero;
            speedometerRigidbody.angularVelocity = 0f;
            speedometerRigidbody.gravityScale = 0f;
        }
        else if (zoneTag == "YellowZone")
        {
            //PlayWarning Audio
            Debug.Log("Enter yellow zone");
        }
        else
        {
            //Do Nothing
        }
    }

}
