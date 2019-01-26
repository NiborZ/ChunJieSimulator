using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrivingMovement : MonoBehaviour
{
    private Quaternion pQuaternion;
    private Vector3 pMovement;
    private float pMoveXAmount;
    private float pMoveYAmount;
    private bool carStopped;
    private Rigidbody2D playerRigidbody;

    private float pMoveXSpeed = 10f;
    public float limitX;
    public float limitY;
    public DrivingController drivingController;

    public float horizontalInput;
    public float verticalInput;

    private void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


    public void controlPlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");
        pMoveXAmount = pMoveXSpeed * horizontalInput;
        //pMoveYAmount = pMoveYSpeed * verticalInput;

        pMovement.Set(pMoveXAmount, 0f, 0f);
        pMovement = pMovement * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + pMovement);
    }
}
