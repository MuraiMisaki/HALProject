using UnityEngine;
using System.Collections;

public class MenuSelectCS : MonoBehaviour {

    public GameObject[] SelectObj = new GameObject[4];  // 選択メニューオブジェクト
    private bool isInit = false;    // 初期化したか
    private bool isMove = false;    // 移動中か
    public float moveSpeed;     // 移動スピード
    public float movedist;     // 移動距離
    private int moveDir = 0;    // 移動方向
    private float distance;     // 移動間隔
    public int selectMenu = 0; // 選択メニュー番号

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // 初期化してなければ
        if (!isInit) {
            // 初期化する
            Init();
        }
        if (isMove)
        {
            // 移動
            Move();
        }
        else
        {

            // 左が選択されたら
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // 背景が右に動く
                MoveRight();
            }
            // 右が選択されたら
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 背景が左に動く
                MoveLeft();
            }
        }

	}
    void Init() {
        // オブジェクト間の距離を求める
        distance = SelectObj[1].transform.position.x - SelectObj[0].transform.position.x;
        for (int i = 0; i < SelectObj.Length; i++) {
            // オブジェクトの初期化
            SelectObj[i].GetComponent<JumpMenuCS>().Init(distance, SelectObj.Length);
        }
    }
    // スクロール移動
    void Move() {
        // 移動
        this.transform.position = new Vector3(this.transform.position.x + moveDir * moveSpeed, this.transform.position.y, this.transform.position.z);
        // 距離を求める
        float fDist = this.transform.position.x - this.SelectObj[selectMenu].transform.position.x;
        // 一定距離よりも小さくなったら
        if (fDist <= this.moveSpeed) {
            // 到着
            Arrival();
            return;
        }
    }
    // 左へスクロール移動
    void MoveLeft() {
        // 選択更新
        selectMenu--;
        Debug.Log("moveleft");
        // 下限制限
        if (selectMenu < 0)
        {
            selectMenu += this.SelectObj.Length;
        }
        moveDir = -1;
        isMove = true;
    }
    // 右へスクロール移動
    void MoveRight() {
        selectMenu++;
        Debug.Log("moveright");
        // 上限制限
        if (selectMenu >= this.SelectObj.Length) {
            selectMenu = 0;
        }
        moveDir = 1;
        isMove = true;
    }

    // 到着
    void Arrival() {
        this.transform.position = SelectObj[selectMenu].transform.position;
        isMove = false;
        moveDir = 0;
    }
}
