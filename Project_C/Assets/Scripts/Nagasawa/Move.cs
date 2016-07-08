using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private float moveSpeed;    // 移動速度
    private bool isMove;        // 移動中フラグ

    private int cnt;

    private MenuCharactorMove MenuCharactor;

    // Use this for initialization
    void Start()
    {
        // 初期化
        isMove = false;
        cnt = 1;
        moveSpeed = 0;
        MenuCharactor = GameObject.Find("Charactor").GetComponent<MenuCharactorMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove) {
            // 左矢印キーが押されたら
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // 移動フラグ立ち上げ
                isMove = true;
                moveSpeed = 0.5f;
            }
            // 右矢印キーが押されたら
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 移動フラグ立ち上げ
                isMove = true;
                moveSpeed = -0.5f;
            }
            // 決定
            if (Input.GetButtonDown("Submit"))
            {
                MenuCharactor.SetFlg();
            }
        }
        else {
            // 移動
            move();
        }
    }

    void move()
    {
        if (cnt > 20)
        {
            // 移動完了
            isMove = false;
            cnt = 1;
            return;
        }

        cnt++;

        // 移動
        foreach (Transform child in transform) {
            child.transform.position += new Vector3(moveSpeed, 0, 0);
        }

    }

    public bool bmoveflg() { return isMove; }
}



