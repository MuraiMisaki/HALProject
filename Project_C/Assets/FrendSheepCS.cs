using UnityEngine;
using System.Collections;

public class FrendSheepCS : FrendsCS {

    private GameObject player;
    private float waitTime = 3.0f;
    private bool isRemove = false;
	// Use this for initialization
	void Start () {
        frendType = FrendType.Recovery;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (isRemove)
            return;
        waitTime -= Time.deltaTime;
        if (waitTime <= 0) {
            isRemove = true;
            player.GetComponent<PlayerStatusCS>().Recovery();
            Destroy(this.gameObject, 2.0f);
        }

    }
}
