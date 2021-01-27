using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRun : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    private float x, y;
    private float rotationx, rotationy;
    private float lingmindu;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        player = GameObject.Find("player");
        transform.position = player.transform.position + new Vector3(0,1.5f,0.05f);
        if (player != null)
        {
            offset = transform.position - player.transform.position;

        }
        lingmindu = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + player.transform.position;
        CamRotation();
    }

    private void CamRotation()
    {
        x = Input.GetAxis("Mouse Y");
        y = Input.GetAxis("Mouse X");
        rotationx += x * lingmindu;
        rotationy -= y * lingmindu;
        rotationy = Mathf.Clamp(rotationy, -180, 180);
        transform.localEulerAngles = new Vector3(-rotationx, -rotationy, 0);
    }
}
