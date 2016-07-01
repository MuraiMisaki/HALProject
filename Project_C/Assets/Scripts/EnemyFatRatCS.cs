using UnityEngine;
using System.Collections;

public class EnemyFatRatCS : MonoBehaviour
{
    public enum MovePattern
    {
        normal,         // 通常
        meander,        // 蛇行
        accel,          // 加速 
    }

    public float moveSpeed;
    public GameObject animChild;
    private Animator anim;
    public Vector3 endPoint;
    private bool isKnockback = false;
    private bool isDead = false;
    public MovePattern movePat;
    private GameObject player;
    private float lineY;
    private int moveCnt;
    private bool isReturn;  
    
    // Use this for initialization
    void Start()
    {
        anim = animChild.GetComponent<Animator>();
        endPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        player = GameObject.FindGameObjectWithTag("Player");
        lineY = transform.position.y + 1.25f /2;
        moveCnt = 0;
        isReturn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        if (isReturn) {
            MoveReturn();
            return;
        }

        if (isKnockback) {
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
            return;
        }
        Move();
            if(transform.position.x <= endPoint.x - 2.0f)
        {
            Destroy(gameObject);
        }
    }
    void Move() {
        switch (movePat)
        {
            case MovePattern.normal:    // 通常移動
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                break;
            case MovePattern.meander:   // 蛇行移動
                moveCnt++;
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, lineY + (Mathf.Cos(moveCnt * 0.02f) * - 1.25f / 2), transform.position.z);
                break;
            case MovePattern.accel:     // 加速移動 
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

                if (transform.position.x - player.transform.position.x < 7.5f)
                {
                    transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime * 2, transform.position.y, transform.position.z);
                    anim.speed = 3.0f;
                }
                if (transform.position.x - player.transform.position.x < 6.5f)
                {
                    transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime * 3, transform.position.y, transform.position.z);
                    anim.SetTrigger("Accel");
                }
                break;
                    
        }
    }
    void MoveReturn()
    {
        transform.position = new Vector3(transform.position.x + 5.0f * Time.deltaTime, transform.position.y, transform.position.z);
        
    }
    public void StartReturn()
    {
        isReturn = true;
        anim.speed = 3.0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            StartCoroutine(StartKnockback());
        }
        if (collision.gameObject.tag == "AttackType")
        {
            StartCoroutine(StartDamage());
        }
    }
    IEnumerator StartKnockback()
    {
        anim.SetTrigger("damage");
        anim.speed = 1.0f;
        isKnockback = true;

        // 1.0秒待つ
        yield return new WaitForSeconds(1.0f);
        isKnockback = false;
    }
    IEnumerator StartDamage()
    {
        anim.SetTrigger("damage");
        anim.speed = 1.0f;
        isKnockback = true;

        // 1.0秒待つ
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(StartDead());
    }
    IEnumerator StartDead()
    {
        anim.SetBool("isDead", true);
        anim.speed = 1.0f;
        isKnockback = true;

        // 1.0秒待つ
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

        anim.SetBool("isDead", false);
        isKnockback = false;
    }
}