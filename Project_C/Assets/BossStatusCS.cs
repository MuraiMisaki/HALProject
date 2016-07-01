using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossStatusCS : MonoBehaviour {

    public GameObject UIBossHP;
    public int maxHP = 1;
    public int hp;
	// Use this for initialization
	void Start () {
        UIBossHP = (GameObject)Instantiate(UIBossHP);
        hp = maxHP;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            if (GetComponent<RatBossEnemyCS>().GetState() == RatBossEnemyState.Appearance)
                return;

            hp--;
            UIBossHP.GetComponent<UIBossHPCS>().ChangeValue((float)hp / maxHP);

            if (hp <= 0)
            {
                GetComponent<RatBossEnemyCS>().ChangeState(RatBossEnemyState.Dead);
                GetComponent<BlinkerCS>().StartBink();
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
