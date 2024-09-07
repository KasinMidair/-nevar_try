using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMove: MonoBehaviour
{
    [SerializeField] private float resetPoint;
    GameObject obj;
    float maxY, minY;
    Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        oldPosition = obj.transform.position;
        maxY =-27f;minY = -38f;
        resetPoint = 47.1f; ;

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(-1 * Time.deltaTime * GameController.instance.gameSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)        
    {
        obj.transform.localPosition = new Vector3(resetPoint,Random.Range(minY, maxY), 0);
        other.gameObject.transform.position=new Vector3(Random.Range(-39.3f,-37.3f), 0, 0);
    }
}
