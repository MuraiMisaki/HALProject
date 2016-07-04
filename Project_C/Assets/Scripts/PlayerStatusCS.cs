using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatusCS : MonoBehaviour {

    public GameObject[] hpUI = new GameObject[5];       // HP表示用UI
    private int lifeStage;                              // 一つのライフにつき何段階
    public int hp;                                      // HPデータ
    private float invincibleTime;                       // 無敵時間

    // Use this for initialization
    void Start () {
        lifeStage = hpUI[0].GetComponent<UIStatusCS>().GetStatus();
        hp = lifeStage * hpUI.Length;
    }
	
	// Update is called once per frame
	void Update () {

        // 無敵時間
        if (invincibleTime > 0)
        {
            // 減らすよ
            invincibleTime -= Time.deltaTime;
        }
	}

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 無敵時間なら
        if (invincibleTime > 0) {
            // 処理しない
            return;
        }
        
        // エネミーに当たったら
        if (collision.gameObject.tag == "Enemy")
        {
            // HPを減らす
            hp--;
            // 下限制限
            if (hp < 0) {
                hp = 0;
            }
            // UI更新
            int lifestatus = hp % lifeStage;
            hpUI[hp / lifeStage].GetComponent<UIStatusCS>().UpdateStatus(lifestatus);

            // 点滅処理
            GetComponent<BlinkerCS>().StartBink();
            invincibleTime = GetComponent<BlinkerCS>().GetBlinkTime();
        }
    }
}
