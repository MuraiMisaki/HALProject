using UnityEngine;
using System.Collections;

public class EnemyMoveCS : MonoBehaviour
{
    public enum MoveType     // 移動パターン
    {
        NORMAL,         // 通常
        MEANDER,        // 蛇行
        RETURN,         // 退却
        DAMAGE,         // ダメージ 
    }

    protected float speed;        // 速度
    protected float accel;        // 加速度
    protected bool isStop;        // 停止
    protected bool isReturn;      // 退却
    public MoveType moveType;   // 移動方法

    protected Vector3 pos;        // 位置
    protected float startPosY;
    protected Vector3 move;       // 移動量
    protected int moveCnt;

	// Use this for initialization
	void Start () {
        speed = -0.5f;
        accel = -0.0f;
        pos = transform.position;
        move = Vector3.zero;
        startPosY = pos.y;
    }
	
	// Update is called once per frame
	void Update () {
        Move();

    }

    // 移動
    void Move() {

        // 現在位置を取得
        pos = transform.position;

        // 移動量初期化
        move = Vector3.zero;

        // 移動タイプに合わせて移動
        switch (moveType) {
            case MoveType.NORMAL:
                MoveNormal();
                break;

            case MoveType.MEANDER:
                MoveNormal();
                MoveMeander();
                break;

            case MoveType.RETURN:
                MoveReturn();
                break;

            case MoveType.DAMAGE:
                MoveDamage();
                break;
        }
        // 位置更新
        transform.position = pos + (move * Time.deltaTime);
    }

    /// <summary>
    /// 通常移動
    /// </summary>
    void MoveNormal() {
        // 加速
        speed += accel;

        // 移動量足しこみ
        move.x += speed;
    }

    /// <summary>
    /// 蛇行移動
    /// </summary>
    void MoveMeander() {

    }

    /// <summary>
    /// 退却
    /// </summary>
    void MoveReturn() {

    }
    /// <summary>
    /// ダメージうけちゃった
    /// </summary>
    void MoveDamage() {

    }
}
