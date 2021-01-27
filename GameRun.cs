using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameRun : MonoBehaviour
{
    public Text HPtext;
    public float HP;
    private void Awake()
    {
        GameObject player = GameObject.Instantiate(Resources.Load<GameObject>(ManagerDate.GetT().playername));

        player.gameObject.name = "player";

        player.AddComponent<GameMessage>();
        HP = ManagerDate.GetT().hp;
        HPtext.text = HP.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
