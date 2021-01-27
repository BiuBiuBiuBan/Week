using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperSlider : MonoBehaviour
{
    //位置点
    public Transform point;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(point.position);
        pos.x -= Screen.width * 0.5f;
        pos.y -= Screen.height * 0.5f;
        transform.localPosition = pos;
       
    }
}
