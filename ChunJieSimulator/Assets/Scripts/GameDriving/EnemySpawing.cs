using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawing : MonoBehaviour
{
    public List<GameObject> enemyCarList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject SpawnAnEnemyCar()
    {
        int randomNumber = (int)Random.Range(0, enemyCarList.Count);
        GameObject spawnedCar = Instantiate(enemyCarList[randomNumber], transform);
        return spawnedCar;
    }
}
