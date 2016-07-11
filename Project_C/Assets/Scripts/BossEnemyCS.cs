using UnityEngine;
using System.Collections;
public enum BossEnemyState
    {
        Appearance,     // 登場
        Idle,           // 待機
        Move,           // 移動
        Attack,         // 攻撃
        Difence,        // 防御
        Action,         // 特殊行動
        Summon,         // 召喚
        Dead            // 死亡
    }
public class BossEnemyCS : MonoBehaviour
{
    private BossEnemyState state;
    public Vector3[] popEnemyPos = new Vector3[3];
    public int posNum;
    private Vector3 toMove;
    private bool isMove;
    private float moveSpeed = 0.2f;
    private float waitTime;
    private float recastTime;  
     
    // アニメーション用
    public GameObject animChild;
    private Animator anim;       

    public GameObject[] summonEnemy = new GameObject[3];

    private Vector3 pos;
    // Use this for initialization
    void Start()
    {
        state = BossEnemyState.Appearance;
        isMove = false;
        posNum = 1;
        waitTime = 0.0f;
        pos = transform.position;
        pos.x = 11.5f;
        transform.position = pos;

        anim = animChild.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BossEnemyState.Appearance:
                Appearance();
                break;
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
    public BossEnemyState GetState() {
        return this.state;
    }

    void Appearance()
    {
        waitTime += Time.deltaTime;
        if (waitTime < 1.5f)
            return;
        pos.x -= 0.1f;
        if(pos.x < 6.5f)
        {
            pos.x = 6.5f;
            ChangeState(BossEnemyState.Idle);
        }
        transform.position = pos;
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
            toMove = new Vector3(transform.position.x, popEnemyPos[posNum].y, popEnemyPos[posNum].z - 5.0f);
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
        Instantiate(summonEnemy[rndm], new Vector3(transform.position.x, popEnemyPos[posNum].y, popEnemyPos[posNum].z), transform.rotation);
        ChangeState(BossEnemyState.Idle);
    }
    void Dead()
    {
         anim.SetTrigger("Dead");
    }
}
