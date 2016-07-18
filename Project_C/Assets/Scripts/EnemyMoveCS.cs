using UnityEngine;
using System.Collections;

    public enum MoveType     // 移動パターン
    {
        NORMAL,         // 通常
        MEANDER,        // 蛇行
        RETURN,         // 退却
        DAMAGE,         // ダメージ 
    }
public class EnemyMoveCS : MonoBehaviour
{

    protected float speed;        // 速度
    protected float accel;        // 加速度
    protected bool isStop;        // 停止
    protected bool isReturn;      // 退却
    public MoveType moveType;   // 移動方法

    protected Vector3 pos;        // 位置
    protected float startPosY;
    protected Vector3 move;       // 移動量
    protected int moveCnt;

    protected Animator anim;

    // Use this for initialization
    void Start () {
        speed = -0.5f;
        accel = -0.0f;
        pos = transform.position;
        move = Vector3.zero;
        startPosY = pos.y;
        anim = transform.FindChild("Animator").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        Move();

    }

    // 移動
    protected void Move() {

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
                MoveMeander();
                break;

            case MoveType.RETURN:
                MoveReturn();
                break;

            case MoveType.DAMAGE:
                MoveDamage();
                break;
        }
    }

    /// <summary>
    /// 通常移動
    /// </summary>
    void MoveNormal() {
        // 加速
        speed += accel;

        // 移動量足しこみ
        move.x += speed;

        // 位置更新
        transform.position = pos + (move * Time.deltaTime);
    }

    /// <summary>
    /// 蛇行移動 Y座標移動
    /// </summary>
    void MoveMeander() {
        moveCnt++;
        // 移動したい場所
        float posY = startPosY + (Mathf.Cos(moveCnt * 0.02f) * -1.25f / 2) + 1.25f / 2;

        // 移動量足しこみ
        move.x += speed;

        // 位置更新
        transform.position = pos + (move * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);

    }

    /// <summary>
    /// 退却
    /// </summary>
    void MoveReturn()
    {
        // 移動量足しこみ
        move.x += 5.0f;
        anim.speed = 3.0f;
        // 位置更新
        transform.position = pos + (move * Time.deltaTime);

    }
    /// <summary>
    /// ダメージうけちゃった
    /// </summary>
    void MoveDamage() {

        // 移動量足しこみ
        move.x += 2.0f;
        // 位置更新
        transform.position = pos + (move * Time.deltaTime);

    }
    
    /// <summary>
    /// エネミーの移動タイプを変更する
    /// </summary>
    /// <param name="type"> 変更する移動タイプ</param>
    public void ChangeMoveType(MoveType type) {
        moveType = type;
    }
}
