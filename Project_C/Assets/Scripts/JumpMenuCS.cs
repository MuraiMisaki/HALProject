using UnityEngine;
using System.Collections;

public class JumpMenuCS : MonoBehaviour {

    private Vector3 position;       // 位置
    private float   interval;       // 間隔
    private int     JumpNum;        // 飛ばすオブジェクト数
    private float   jumpDistance;    // ジャンプ距離

	// Use this for initialization
	void Start () {
        // 位置初期化
        this.position = transform.position;

    }
    // 初期化
    public void Init(float fIntrvl, int nObjNum) {
        this.interval   = fIntrvl;
        this.JumpNum = nObjNum + 1;
        this.jumpDistance = this.interval * this.JumpNum;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void JumpLeft()
    {
        transform.position = new Vector3(this.position.x - this.jumpDistance, this.position.y, this.position.z);
    }

    public void JumpRight()
    {
        transform.position = new Vector3(this.position.x + this.jumpDistance, this.position.y, this.position.z);
    }
    public void JumpObj(int dir)
    {
        transform.position = new Vector3(this.position.x + this.jumpDistance * dir, this.position.y, this.position.z);
    }
}
