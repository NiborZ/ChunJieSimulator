using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button againButton;

    public void OnClick()
    {
        LevelManager.Instance.restart();
    }

}
