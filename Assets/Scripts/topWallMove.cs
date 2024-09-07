using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topWallMove : MonoBehaviour
{
    GameObject obj;
    public float maxY, minY;
    private Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        oldPosition = obj.transform.position;
        maxY = 2; minY = -2;


    }

    // Update is called once per frame
    void Update()
    {
     
        if (obj.transform.position.x ==30)
        {
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);
        }
    }
 
}
