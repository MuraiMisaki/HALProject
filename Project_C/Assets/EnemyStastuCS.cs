using UnityEngine;
using System.Collections;

public class EnemyStastuCS : MonoBehaviour {

    enum EnemyStatus {
        Fine,               // 元気
        Energency,          // ピンチ！　← 今ココ！
        Dead,               // あ、もうこれ死んだわ…
    }

    public int HP = 1;
    private EnemyStatus status = EnemyStatus.Fine;
    public GameObject deadEffects;          // 死んだときのえふぇくと
    private bool isQuitting = false;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = transform.FindChild("Animator").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HP == 0) {
            status = EnemyStatus.Dead;
            anim.SetBool("isDead",true);
            Destroy(this.gameObject, 0.7f);
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackType")
        {
            HP--;       // HP減少
            anim.SetTrigger("Damage");
            anim.speed = 1.0f;
            GetComponent<EnemyMoveCS>().ChangeMoveType(MoveType.DAMAGE);
        }
    }

    /// <summary>
    /// OnDestroy時のエラー回避
    /// </summary>
    void OnApplicationQuit() {
        isQuitting = true;
    }

    /// <summary>
    /// 死んだときはエフェクトを残すのだ
    /// </summary>
    void OnDestroy() {
        if (!isQuitting)
        {
            Instantiate(deadEffects, transform.position, transform.rotation);
        }
    }
}
