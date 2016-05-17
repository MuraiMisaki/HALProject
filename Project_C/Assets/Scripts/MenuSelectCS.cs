using UnityEngine;
using System.Collections;

public class MenuSelectCS : MonoBehaviour {
    public GameObject[] selectPointObj = new GameObject[1];   // 移動候補場所
    private Transform moveTarget;                           // 移動場所
    static private int nowSelectMode;                              // 現在選択モード
    private float moveSpeed = 0.5f;                         // 移動速度
    private bool isMove;                                    // 移動中フラグ
    public GameObject sceneManager = null;

    // Use this for initialization
    void Start()
    {
        // 初期化
        this.transform.position = this.selectPointObj[nowSelectMode].transform.position;
        moveTarget = null;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        // モード選択
        ModeSelect();

        // 移動
        if (isMove)
            move();

        // 決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 移動中はダメ
            if (isMove)
                return;
            if (sceneManager == null)
                return;
            sceneManager.GetComponent<SceneManagerCS>().MoveNextScene(nowSelectMode);
        }
    }

    /// <summary>
    /// 目的位置まで移動
    /// </summary>
    void move()
    {

        // 移動目的位置がなければ取得する
        if (this.moveTarget == null)
            this.moveTarget = this.selectPointObj[nowSelectMode].transform;   // 移動目的位置取得

        Vector3 offset = moveTarget.position - this.transform.position;      // 現在位置との距離  
        float distance = offset.magnitude;                      // 移動幅
        Vector3 moveDir = offset.normalized;                    // 移動方向  

        // 移動幅が一定距離より小さくなったら
        if (distance <= this.moveSpeed)
        {
            // 移動完了
            this.transform.position = moveTarget.position;
            isMove = false;
            return;
        }

        // 移動
        this.transform.position += moveDir * this.moveSpeed;
    }

    /// <summary>
    /// 次のモード選択
    /// </summary>
    void NextModeSelect()
    {
        // 選択モード変更
        nowSelectMode++;

        // 上限制限
        if (nowSelectMode >= this.selectPointObj.Length)
        {
            nowSelectMode -= this.selectPointObj.Length;
        }

        //// 選択位置更新
        //int n = (nowSelectMode - 2 + this.selectPointObj.Length) % this.selectPointObj.Length;
        //selectPointObj[n].GetComponent<JumpMenuCS>().JumpRight();
        // 移動ターゲット変更
        this.moveTarget = this.selectPointObj[nowSelectMode].transform;
    }

    /// <summary>
    /// 前のモード選択
    /// </summary>
    void PrevModeSelect()
    {
        // 選択モード変更
        nowSelectMode--;

        // 下限制限
        if (nowSelectMode < 0)
        {
            nowSelectMode += this.selectPointObj.Length;
        }

        //// 選択位置更新
        //int n = (nowSelectMode + 3) % this.selectPointObj.Length;
        //selectPointObj[n].GetComponent<JumpMenuCS>().JumpLeft();
        // 移動ターゲット設定
        this.moveTarget = this.selectPointObj[nowSelectMode].transform;
    }

    /// <summary>
    /// モード選択
    /// </summary>
    void ModeSelect()
    {
        // 移動中は選択できない
        if (isMove)
            return;

        // 左矢印キーが押されたら
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 前モード選択
            PrevModeSelect();
            // 移動フラグ立ち上げ
            isMove = true;
        }
        // 右矢印キーが押されたら
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 次モード選択
            NextModeSelect();
            // 移動フラグ立ち上げ
            isMove = true;
        }
    }
}
