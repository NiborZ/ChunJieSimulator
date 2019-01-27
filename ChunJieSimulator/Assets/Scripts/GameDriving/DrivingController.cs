using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingController : MonoBehaviour
{
    public GameController gameController;
    public PlayerDrivingMovement playerDrivingMovement;
    public PlayerDrivingAcceleration playerDrivingAcceleration;
    public PlayerHealthShowing playerHealthShowing;
    public List<GameObject> spawnedCars;
    public GameObject station;
    
    public List<EnemySpawing> enemySpawingPointList;
    public Animator crushAnimator;
    private Animator roadAnimator;
    public int playerHealth;
    public bool playerCarStopped = false;
    public float playTime = 30f;
    private bool enemySpawned = false;
    private float spawingTime = 1.8f;
    private float secondsCounter = 0f;
    private float playTimeCounter = 0f;
    private GameObject spawnedCarObj = null;
    public int usedSpawner;

    void Start()
    {
        enemySpawingPointList = new List<EnemySpawing>();
        playerHealth = 3;
        playTime = 30f;
        roadAnimator = GameObject.FindWithTag("Road").GetComponent<Animator>();
        roadAnimator.SetBool("SlowMoveStart", true);
        roadAnimator.SetBool("QuickMoveStart", true);
        playerDrivingAcceleration.startAccelerate();

        GameObject[] enemySpawingPointObjs = GameObject.FindGameObjectsWithTag("CarSpawingPoint");
        foreach(GameObject enemySpawingPointObj in enemySpawingPointObjs)
        {
            enemySpawingPointList.Add(enemySpawingPointObj.GetComponent<EnemySpawing>());
        }
    }

    private void Update()
    {
        driving();
    }

    public void playerLoseHealth()
    {
        enemyMoveForward();
        StartCoroutine(adjustRoadSpeed());
    }

    private void enemyMoveForward()
    {
        foreach( GameObject car in spawnedCars)
        {
            if(car != null)
                car.GetComponent<EnemyDrivingMovement>().inverseDirection();
        }
    }

    public void driving()
    {
        if(playTimeCounter >= playTime)
        {
            StartCoroutine(gameFinish());
        }
        else
        {
            if (!playerCarStopped)
            {
                playerDrivingAcceleration.controlPlayerAcceleration();
                playerDrivingMovement.controlPlayerMovement();
                spawnEnemy();
                playTimeCounter += Time.deltaTime;
            }
        }
    }

    private void spawnEnemy()
    {
        if(spawnedCarObj == null)
        {
            usedSpawner = -1;
        }

        if (secondsCounter <= spawingTime)
        {
            secondsCounter += Time.deltaTime;
        }
        else
        {
            enemySpawned = false;
        }

        if (!enemySpawned)
        {
            int randomNumber = (int)Random.Range(0, enemySpawingPointList.Count);
            while(randomNumber==usedSpawner)
            {
                randomNumber = (int)Random.Range(0, enemySpawingPointList.Count);
            }
            //Debug.Log("Random Number is" + randomNumber);
            spawnedCarObj = enemySpawingPointList[randomNumber].SpawnAnEnemyCar();
            spawnedCars.Add(spawnedCarObj);
            usedSpawner = randomNumber;
            secondsCounter = 0f;
            enemySpawned = true;
        }
    }

    IEnumerator adjustRoadSpeed()
    {
        playerHealth -= 1;
        crushAnimator.SetBool("CarCrush", true);
        playerHealthShowing.reduceHealth(playerHealth);
        playerCarStopped = true;
        roadAnimator.SetBool("QuickMoveEnd", true);
        roadAnimator.SetBool("QuickMoveStart", false);
        yield return new WaitForSeconds(1);
        crushAnimator.SetBool("CarCrush", false);

        roadAnimator.SetBool("SlowMoveEnd", true);
        roadAnimator.SetBool("SlowMoveStart", false);
        yield return new WaitForSeconds(3);

        if (playerHealth <= 0)
        {

            gameController.playerDead();
        }
        else
        {
            roadAnimator.SetBool("SlowMoveStart", true);
            roadAnimator.SetBool("SlowMoveEnd", false);
            yield return new WaitForSeconds(1);

            roadAnimator.SetBool("QuickMoveStart", true);
            roadAnimator.SetBool("QuickMoveEnd", false);
            playerDrivingAcceleration.resetPosition();
            playerCarStopped = false;
        }
    }

    IEnumerator gameFinish()
    {
        playerCarStopped = true;
        roadAnimator.SetBool("QuickMoveEnd", true);
        roadAnimator.SetBool("QuickMoveStart", false);
        yield return new WaitForSeconds(1);

        Instantiate(station);

        roadAnimator.SetBool("SlowMoveEnd", true);
        roadAnimator.SetBool("SlowMoveStart", false);
        yield return new WaitForSeconds(1);
    }

}
