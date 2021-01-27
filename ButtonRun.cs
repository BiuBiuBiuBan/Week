using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRun : MonoBehaviour
{
    public Button ButtonChick;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ButtonChick.onClick.AddListener(() =>
        {
            GameObject bear = GameObject.Find("Bear");
            GameObject Cube = GameObject.Find("CubeBoss");
            GameObject Boy = GameObject.Find("Boy");

            if (bear)
            {
                ManagerDate.GetT().playername = "bear";
                ManagerDate.GetT().hp = 500;
                ManagerDate.GetT().move = 1;
                ManagerDate.GetT().select = 3;
            }
            if (Cube)
            {
                ManagerDate.GetT().playername = "CubeBoss";
                ManagerDate.GetT().hp = 300;
                ManagerDate.GetT().move = 5;
                ManagerDate.GetT().select = 3;
            }
            if (Boy)
            {
                ManagerDate.GetT().playername = "Boy";
                ManagerDate.GetT().hp = 100;
                ManagerDate.GetT().move = 10;
                ManagerDate.GetT().select = 2;
            }
            SceneManager.LoadScene("Game");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
