using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class RavenMove : MonoBehaviour
{
    GameController GCtrl;
    GameObject obj;
    float forceRange;
    AudioSource audioSource;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isDead", false);
        obj = gameObject;
        forceRange = 100;
        if (GCtrl == null)
        {
            GCtrl = GameController.instance;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) )&& Time.timeScale==1) 
            && GCtrl.GetComponent<GameController>().isEndGame == false )
        {

            FlyUp();
        }

        anim.SetFloat("force", obj.GetComponent<Rigidbody2D>().velocity.y);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GCtrl.GetComponent<GameController>().PlusPoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsDead();
       EndGame();

    }
    void FlyUp()
    {
        SoundsManager.instance.PlayOneShot(SoundsManager.SoundType.playerUp_HoverSound);
        obj.GetComponent<Rigidbody2D>().AddForce(Vector3.up* forceRange);

    }
    void EndGame()
    {
        
        if (!GCtrl.GetComponent<GameController>().isEndGame)
        {
            GCtrl.GetComponent<GameController>().isEndGame = true;
            GCtrl.GetComponent<GameController>().StopTime();
            SoundsManager.instance.PlayOneShot(SoundsManager.SoundType.playerDieSound);
        }
      

    }
    void IsDead()=> anim.SetBool("isDead", true);
}
