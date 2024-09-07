using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingPoint : MonoBehaviour
{
    public GameObject point1;
    [SerializeField] private GameObject point2;
    Sprite firstNum, lastNum;
    long point;
    // Start is called before the first frame update
    void Start()
    {
        firstNum = Resources.Load<Sprite>("Graphics_2D/Number/num0");
        lastNum = Resources.Load<Sprite>("Graphics_2D/Number/num0");
        point= GameController.instance.totalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.totalPoint > point)
        {
            changePoint();
            point =0;
        }
    }
    public void changePoint()
    {

        long first = GameController.instance.totalPoint / 10;
        long last = GameController.instance.totalPoint % 10;
        if (last==0)
        {
            firstNum = Resources.Load<Sprite>("Graphics_2D/Number/num" + first.ToString());
            lastNum = Resources.Load<Sprite>("Graphics_2D/Number/num0");
        }
        else
        {
            lastNum = Resources.Load<Sprite>("Graphics_2D/Number/num" + last.ToString());
        }
        point1.GetComponent<Image>().sprite = firstNum;
        point2.GetComponent<Image>().sprite = lastNum;

    }
}
