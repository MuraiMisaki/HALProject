using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatusCS : MonoBehaviour {

    public GameObject[] hpUI = new GameObject[5];
    public int hp;
    private int lifeStage;
    private float invincibleTime;
    // Use this for initialization
    void Start () {
        lifeStage = hpUI[0].GetComponent<UIStatusCS>().GetStatus();
        hp = lifeStage * hpUI.Length;
    }
	
	// Update is called once per frame
	void Update () {
        if (invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (invincibleTime > 0) {
            return;
        }
            if (collision.gameObject.tag == "Enemy")
        {
            hp--;
            if (hp < 0) {
                hp = 0;
            }
            int lifestatus = hp % lifeStage;
            hpUI[hp / lifeStage].GetComponent<UIStatusCS>().UpdateStatus(lifestatus);
            GetComponent<BlinkerCS>().StartBink();
            invincibleTime = GetComponent<BlinkerCS>().GetBlinkTime();
        }
    }
}
