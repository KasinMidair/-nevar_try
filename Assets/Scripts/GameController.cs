using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float gameSpeed;
    public bool isEndGame;
    public long totalPoint ;
    long speedUpTimes = 1;
    GameObject obj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            totalPoint = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    
        }

    }
    void Start()
    {
        gameSpeed = 8;
        isEndGame = false;
        obj = gameObject;
    }
    private void Update()
    {
        if ((totalPoint / 20) == speedUpTimes)
        {
            SpeedUp();
        }
    }
    public void PlusPoint()=>++totalPoint;
    public void OriginDigital(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        isEndGame = false;
        totalPoint = 0;
        Time.timeScale = 1;
    }
    void SpeedUp()
    {
        gameSpeed+=2 ;
        ++speedUpTimes;
    }
    public void StopTime() =>  Time.timeScale = 0.0f; 
    public void ContinueTime()
    {
        if (!isEndGame)
        {
            Time.timeScale = 1;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
