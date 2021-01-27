using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessage : MonoBehaviour
{
    public Transform Cam;
    public Rigidbody camd;
    public CharacterController playerChar;
    private Vector3 fangx;
    private float m, n;
    private float speed;
    
    private void Awake()
    {
      
        Cam = Camera.main.transform;
        playerChar = GetComponent<CharacterController>();   
    }

    // Start is called before the first frame update
    void Start()
    {


        //player.transform.position = Vector3.zero;

        
        camd = GetComponent<Rigidbody>();
       
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        m = Input.GetAxis("Horizontal");
        n = Input.GetAxis("Vertical");
        fangx = new Vector3(m, 0, n);
        fangx = Cam.TransformDirection(fangx);
        playerChar.Move(fangx * speed * Time.deltaTime);
    }
}
