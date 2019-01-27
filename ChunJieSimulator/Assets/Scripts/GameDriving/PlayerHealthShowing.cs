using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthShowing : MonoBehaviour
{
    public GameObject heartObj;
    public GameObject noheartObj;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;

    private void Start()
    {
        heart1 = Instantiate(heartObj, pos1);
        heart2 = Instantiate(heartObj, pos2);
        heart3 = Instantiate(heartObj, pos3);
    }

    public void reduceHealth(int index)
    {
        if(index == 2)
        {
            Destroy(heart3);
            Instantiate(noheartObj, pos3);
        }

        if (index == 1)
        {
            Destroy(heart2);
            Instantiate(noheartObj, pos2);
        }

        if (index == 0)
        {
            Destroy(heart1);
            Instantiate(noheartObj, pos1);
        }
    }

}
