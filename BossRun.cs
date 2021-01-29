using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public enum BossType
{
    Idle,
    Patro,
    Chase,
    AttackLevel1,
    AttackLevel2,
}
public class BossRun : MonoBehaviour
{
    private GameObject player;
    private FSMSystem fsm;
    private void Awake()
    {
        player = GameObject.Find("player");
    }
    //血条
    public Slider HPSilder;
    //经验条
    public Slider ExperSilder;
    //视野
    private float shiye = 10;
    //移动速度
    private float move = 3;
    //攻击力
    private float Attack = 50;
    //血条
    private float Hp = 1000;
    //经验值
    private float EXP = 0;
    //攻击距离
    private float AttackDis = 3;
    //动画组件
    public Animator anim;
    //寻路组件
    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeRun(1f));
        StartCoroutine(BossAttack(0.6f));
        anim = transform.GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
         fsm = new FSMSystem();
        FSMState patrolState = new PatrolState(fsm);
        FSMState chaseState = new ChaseState(fsm);
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);
        patrolState.AddTransition(Transition.FindPlayer, StateID.ChaseState);
        chaseState.AddTransition(Transition.LosePlayer, StateID.PatrolState);
    }
    IEnumerator BossAttack(float t)
    {

        //float time = 0;
        //while (true)
        //{
        //    Debug.Log("进行中");

        //    time += 1;
        //    float pos = Vector3.Distance(transform.position, player.transform.position);
        //    if (time >= 15)
        //    {
        //        BossState(BossType.Patro);
        //        time = 0;

        //    }
        //    else if (pos <= shiye)
        //    {
        //        time = 0;
        //        BossState(BossType.Chase);
        //        if (pos <= AttackDis)
        //        {
        //            if (EXP != 200)
        //            {
        //                BossState(BossType.AttackLevel1);
        //            }
        //            else
        //            {
        //                BossState(BossType.AttackLevel2);
        //            }

        //        }

        //    }

         yield return new WaitForSeconds(t);
        //}
    }
    IEnumerator TimeRun(float t)
    {
        while (EXP <= 200)
        {
            EXP += 1;
            ExperSilder.value += 0.002f;
            yield return new WaitForSeconds(t);
        }
    }
    // Update is called once per frame
    void Update()
    {



    }
    //public void BossState(BossType type)
    //{
    //    switch (type)
    //    {
    //        case BossType.Idle:
    //            Debug.Log("发呆阶段");
    //            anim.SetFloat("Run", -2);

    //            break;
    //        case BossType.Patro:
    //            Debug.Log("寻路阶段");
    //            Vector3 pos = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
    //            nav.SetDestination(pos);
    //            anim.SetFloat("Run", 2);
    //            if (Vector3.Distance(transform.position, pos) <= 0.5f)
    //            {
    //                BossState(BossType.Idle);
    //            }
    //            break;
    //        case BossType.Chase:
    //            Debug.Log("追人阶段");
    //            transform.LookAt(player.transform);
    //            anim.SetFloat("Run", 2);
    //            nav.SetDestination(player.transform.position);
    //            if (Vector3.Distance(transform.position, player.transform.position) > shiye)
    //            {

    //                BossState(BossType.Idle);

    //            }
    //            break;
    //        case BossType.AttackLevel1:
    //            Debug.Log("开始攻击");
    //            anim.SetTrigger("RunAttack");
    //            GameObject.Find("Plane").GetComponent<GameRun>().HP -= Attack;
    //            GameObject.Find("Plane").GetComponent<GameRun>().HPtext.text = GameObject.Find("Plane").GetComponent<GameRun>().HP.ToString();
    //            if (GameObject.Find("Plane").GetComponent<GameRun>().HP <= 0)
    //            {
    //                Debug.LogError("游戏结束，你挂了");
    //                Time.timeScale = 0;
    //            }
    //            break;
    //        case BossType.AttackLevel2:
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
