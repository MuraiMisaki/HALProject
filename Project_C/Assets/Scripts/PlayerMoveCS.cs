using UnityEngine;
using System.Collections;

public class PlayerMoveCS : MonoBehaviour {

    public Transform[] lane = new Transform[3];
    private Transform moveToLane = null;
    public float moveSpeed = 0.5f;
    private int selectLane = 0;
    private bool isMove = false;

	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {
        // 移動
        if (isMove) {
            Move();

            return;
        }
        // 入力待ち
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
    }

    void MoveDown()
    {
        // これ以上 下には行けません
        if (this.selectLane >= (this.lane.Length) -1)
            return;

        this.selectLane += 1;
        moveToLane = lane[selectLane];
        isMove = true;

    }
    void MoveUp() {
        // これ以上 上には行けません
        if (this.selectLane <= 0)
            return;

        selectLane -= 1;
        moveToLane = lane[selectLane];
        isMove = true;
    }

    void Move() {

        Vector3 offset = moveToLane.position - this.transform.position;      // 現在位置との距離  
        float distance = offset.magnitude;                      // 移動幅
        Vector3 moveDir = offset.normalized;                    // 移動方向  

        // 移動幅が一定距離より小さくなったら
        if (distance <= this.moveSpeed)
        {
            // 移動完了
            this.transform.position = moveToLane.position;
            isMove = false;
            return;
        }

        // 移動
        this.transform.position += moveDir * this.moveSpeed;
    }
}
