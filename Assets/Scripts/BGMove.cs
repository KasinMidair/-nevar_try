using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    GameObject obj;
    private float backgroundResetPoint;
    private Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {

        obj =this.gameObject;
        oldPosition=obj.transform.position;
        backgroundResetPoint = -113.4f;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(-1 * Time.deltaTime* GameController.instance.gameSpeed, 0, 0);
        
        if (obj.transform.position.x < backgroundResetPoint)
        {

            obj.transform.position = oldPosition;
        }
    }
    
}
