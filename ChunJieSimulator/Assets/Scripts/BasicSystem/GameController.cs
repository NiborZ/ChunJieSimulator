using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LevelManager levelManager;
    public PlayerManager playerManager;

    public DrivingController drivingController;

    private bool pause= false;
    private bool playerIsDead = false;

    public void pauseGame()
    {
        pause= true;
    }
    public void continueGame()
    {
        pause = false;
    }

    public bool getPauseStatus()
    {
        return this.pause;
    }

    
    void Start()
    {
        pause = false;
    }

    void Update()
    {
        if(!pause && !playerIsDead)
        {
            //Game Play
            drivingController.driving();
            //if (levelManager.getCurrentSceneNumber() == 3)
            //{

            //}
        }
    }

    public void gameStartDelay()
    {
        pause = true;
        //PlayAnimation
    }

    public void playerDead()
    {
        //Show Player dead Infos

        Debug.Log("Player Dead!");
        gameStartDelay();
        //levelManager.loadStartScene();
    }

}
