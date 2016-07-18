using UnityEngine;
using System.Collections;

public class EnemyMoveGearCS : EnemyMoveCS {

    public float gearShiftPosPercent;
    private float gearShiftPosX;
    private bool isAccel;
    private bool isGearShift;
    private float timeCnt;
	// Use this for initialization
	void Start () {
        // 追加せってい
        gearShiftPosPercent = 0.5f;
        isAccel = false;
        isGearShift = false;
        timeCnt = 0.6f;
        Vector3 gearShiftPos = Camera.main.ViewportToWorldPoint(new Vector3(gearShiftPosPercent, 0, 0));
        gearShiftPosX = gearShiftPos.x;

        // 継承元設定
        speed = -0.5f;
        accel = -0.0f;
        pos = transform.position;
        move = Vector3.zero;
        startPosY = pos.y;
        anim = transform.FindChild("Animator").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (pos.x < gearShiftPosX && !isGearShift) {
            speed = -3.0f;
            anim.speed = 3.0f;
            isGearShift = true;
        }
        if (isGearShift && !isAccel) {
            timeCnt -= Time.deltaTime;
            if (timeCnt < 0) {
                anim.SetTrigger("Accel");
                isAccel = true;
            }
        }
        Move();
    }
}
