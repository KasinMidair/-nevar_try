using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SoundsManager;

public class SubGameController : MonoBehaviour
{

    [SerializeField] private GameObject endPannel;
    private static readonly int hashOnOff=Animator.StringToHash("OnOff");
    bool isOpenEndMenu;
    // Start is called before the first frame update
    void Start()
    {
        isOpenEndMenu = false;  

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isEndGame && isOpenEndMenu==false)
        { 
            OpenEndMenu();
        }
    }
    public void OpenEndMenu()
    {
        isOpenEndMenu = true;
        endPannel.GetComponent<Animator>().SetTrigger(hashOnOff);
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        GameController.instance.isEndGame = false;
        SceneManager.LoadScene(0);
    }
    public void BackToMainMenu()
    {
        GameController.instance.OriginDigital(1);

    }

    public void TwoMenuTrans()
    {
        if (isOpenEndMenu)
        {
            endPannel.GetComponent<Animator>().SetTrigger(hashOnOff);

        }
    }
    public void RestartAfterAnimation()
    {
        StartCoroutine(PlayAnimationAndReload());
    }

    private IEnumerator PlayAnimationAndReload()
    {
        endPannel.GetComponent<Animator>().SetTrigger(hashOnOff);
        yield return null;
        AnimatorStateInfo animationState = endPannel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float currentStateDuration = animationState.length;
        Debug.Log(currentStateDuration);
        yield return new WaitForSecondsRealtime(currentStateDuration);
        GameController.instance.OriginDigital(0);
       
    }

    public void HoverButton()
    {
        SoundsManager.instance.PlayOneShot(SoundType.playerUp_HoverSound);
    }
    public void ButtonClick()
    {
        SoundsManager.instance.PlayOneShot(SoundType.buttonsSound);
    }
    

}

