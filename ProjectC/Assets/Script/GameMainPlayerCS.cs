using UnityEngine;
using System.Collections;

public class GameMainPlayerCS : MonoBehaviour {

    private Vector3 viewPoint;

    public Transform[] selectPointPos = new Transform[1];   // 移動候補場所
    public Transform moveTarget;                           // 移動場所
    public int nowSelectRoad;                              // 現在選択場所
    private float moveSpeed = 0.5f;                         // 移動速度
    public int moveDir;                                 // 移動方向     // -1 下、1 上

    // Use this for initialization
    void Start () {
        // 画面端を取得
        this.viewPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        // 画面端でスタート
        this.transform.position = new Vector3(viewPoint.x + 1.0f, this.transform.position.y, selectPointPos[nowSelectRoad].position.z);
        
        moveTarget = null;
        moveDir = 0;
    }
	
	// Update is called once per frame
	void Update () {
        // 入力待ち
        InputWait();

        if (moveTarget)
        {
            Move();
        }
	}
    void Move() {

        Vector3 offset = moveTarget.position - this.transform.position;      // 現在位置との距離 
        offset = new Vector3(0.0f, 0.0f, offset.z);   // z方向のみ移動
        float distance = offset.magnitude;                      // 移動幅
        Vector3 moveDirVec = offset.normalized;                    // 移動方向  

        // 移動幅が一定距離より小さくなったら
        if (distance <= this.moveSpeed)
        {
            // 移動完了
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, moveTarget.position.z);
            moveTarget = null;
            moveDir = 0;
            return;
        }

        // 移動
        this.transform.position += moveDirVec * this.moveSpeed;
    }

    void InputWait() {

        // 上矢印キーが押されたら
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 上方向移動中
            if (moveDir > 0)
                return;
            
            // 選択モード変更
            nowSelectRoad++;

            // 上限制限
            if (this.nowSelectRoad >= this.selectPointPos.Length)
            {
                nowSelectRoad = this.selectPointPos.Length -1;
            }
            // 移動ターゲット設定
            this.moveTarget = this.selectPointPos[nowSelectRoad];
            moveDir = 1;
        }
        // 下矢印キーが押されたら
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 下方向移動中
            if (moveDir < 0)
                return;

            // 選択モード変更
            nowSelectRoad--;
            // 上限制限
            if (this.nowSelectRoad < 0)
            {
                nowSelectRoad = 0;
            }
            // 移動ターゲット設定
            this.moveTarget = this.selectPointPos[nowSelectRoad];
            // 移動フラグ立ち上げ
            moveDir = -1;
        }
    }
}
