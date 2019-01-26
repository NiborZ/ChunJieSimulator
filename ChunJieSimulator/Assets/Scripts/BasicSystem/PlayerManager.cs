using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameController gameController;
    public string playerName;
    public string playerCurrentState;

    private int playerMoney;

    public void gainMoney(int gainedMoney)
    {
        playerMoney += gainedMoney;
    }

    public void loseMoney(int lostMoney)
    {
        if((playerMoney - lostMoney) <= 0)
        {
            playerMoney = 0;
            gameController.playerDead();
        }
        else
        {
            playerMoney -= lostMoney;
        }
    }

}
