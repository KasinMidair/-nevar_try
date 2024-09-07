using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneSetup : MonoBehaviour
{
    public Button SettingButton;
    public Button ContinueButton;

    private void Start()
    {
        GameController gameController = GameController.instance;

        if (gameController != null)
        {
            // Gán phương thức của GameController vào các nút
           SettingButton.onClick.AddListener(gameController.StopTime);
            ContinueButton.onClick.AddListener(gameController.ContinueTime);
        }
        else
        {
            Debug.LogError("GameController instance is not available.");
        }
    }
}

