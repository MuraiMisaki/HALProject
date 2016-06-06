using UnityEngine;
using System.Collections;

public class MoveAnimalsCS : MonoBehaviour {

    public float moveSpeed;
    public GameObject animChild;
    private Animator anim;
    private bool isDead = false;

    private Vector3 endPoint;               // 画面端位置
    // Use this for initialization
    void Start () {
        anim = animChild.GetComponent<Animator>();
        endPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
        if(!isDead)
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        if (transform.position.x >= endPoint.x + 10.0f) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("isDead", true);
        isDead = true;
        // 0.5秒後に削除
        Destroy(gameObject, 0.5f);

    }
}
