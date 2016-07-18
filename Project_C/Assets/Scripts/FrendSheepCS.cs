using UnityEngine;
using System.Collections;

public class FrendSheepCS : FrendsCS {

    private GameObject player;
    private float waitTime = 3.0f;
    private bool isRemove = false;
    private bool isDestroy = false;
    public GameObject destroyEffect;
	// Use this for initialization
	void Start () {
        frendType = FrendType.Recovery;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (isDestroy)
            return;

        waitTime -= Time.deltaTime;
        if (waitTime <= 0 && !isRemove) {
            isRemove = true;
            player.GetComponent<PlayerStatusCS>().Recovery();
            Destroy(this.gameObject, 2.0f);
           
        }
        if (waitTime < -0.5) {
                isDestroy = true;
                Instantiate(destroyEffect,transform.position, transform.rotation);
            }

    }
}
