using UnityEngine;
using System.Collections;

public class RatBossEnemyCS : MonoBehaviour
{

    private BossEnemyState state;
    public Transform[] popEnemyPos = new Transform[3];
    public int posNum;
    private Vector3 toMove;
    private bool isMove;
    private float moveSpeed = 0.2f;
    private float waitTime;
    private float recastTime;
    private int life;
    private Animator anim;
    public GameObject animChild;

    public GameObject[] summonEnemy = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        state = BossEnemyState.Idle;
        isMove = false;
        posNum = 1;
        waitTime = 0.0f;
        life = 3;

        anim = animChild.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BossEnemyState.Idle:
                Idle();
                break;
            case BossEnemyState.Move:
                Move();
                break;
            case BossEnemyState.Summon:
                Summon();
                break;
            case BossEnemyState.Dead:
                Dead();
                break;

        }

    }
    public void ChangeState(BossEnemyState state)
    {
        this.state = state;
    }
    public BossEnemyState GetState()
    {
        return state;
    }

    void Idle()
    {
        waitTime += Time.deltaTime;
        recastTime += Time.deltaTime;
        // 10秒経ったら
        if (waitTime > 10.0f)
        {
            ChangeState(BossEnemyState.Move);    // 移動する
            waitTime = 0.0f;
        }
        if (recastTime > 7.0f)
        {
            ChangeState(BossEnemyState.Summon);  // 召喚
            recastTime = 0.0f;
        }

    }
    void Move()
    {
        if (!isMove)
        {
            if (posNum == 1)
                posNum++;
            else
                posNum--;
            toMove = new Vector3(transform.position.x, popEnemyPos[posNum].position.y, popEnemyPos[posNum].position.z - 5.0f);
            isMove = true;
            return;
        }

        Vector3 offset = toMove - this.transform.position;      // 現在位置との距離  
        float distance = offset.magnitude;                               // 移動幅
        Vector3 moveDir = offset.normalized;                             // 移動方向  

        // 移動幅が一定距離より小さくなったら
        if (distance <= this.moveSpeed)
        {
            // 移動完了
            this.transform.position = toMove;
            isMove = false;
            ChangeState(BossEnemyState.Idle);              // 待機状態へ
            return;
        }

        // 移動
        this.transform.position += moveDir * this.moveSpeed;
    }
    void Summon()
    {
        int rndm = Random.Range(0, summonEnemy.Length);
        Instantiate(summonEnemy[rndm], new Vector3(transform.position.x, popEnemyPos[posNum].position.y, popEnemyPos[posNum].position.z), transform.rotation);
        ChangeState(BossEnemyState.Idle);
    }
    void Dead()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            life--;
            if (life < 0)
            {
                ChangeState(BossEnemyState.Dead);
                GetComponent<BlinkerCS>().StartBink();
                GetComponent<Collider2D>().enabled = false;
                anim.SetTrigger("Dead");
            }
        }
    }
}
