using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatusCS : MonoBehaviour {

    public GameObject[] hpUI = new GameObject[5];       // HP表示用UI
    private int lifeStage;                              // 一つのライフにつき何段階
    public int hp;                                      // HPデータ
    private int maxHP;
    private float invincibleTime;                       // 無敵時間
    public GameObject damageEffect;                    // ダメージを受けた時のエフェクト
    public GameObject recoveryEffect;
    void Start () {
        lifeStage = hpUI[0].GetComponent<UIStatusCS>().GetStatus();

        maxHP = hp = lifeStage * hpUI.Length;
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
    public void Recovery() {
        hp++;

        Instantiate(recoveryEffect, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), transform.rotation);
        if (maxHP < hp)
        {
            hp = maxHP;
        }
        else
        {
            hpUI[((hp+1) / lifeStage) - 1].GetComponent<UIStatusCS>().RecoveryUI();
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
            // ダメージエフェクト
            Instantiate(damageEffect, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), transform.rotation);

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
