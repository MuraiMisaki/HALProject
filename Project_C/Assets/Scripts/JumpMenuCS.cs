using UnityEngine;
using System.Collections;

public class JumpMenuCS : MonoBehaviour {

    private Vector3 position;       // 位置
    private float   interval = 40.0f;       // 間隔
    public GameObject player;

	// Use this for initialization
	void Start () {
        // 位置初期化
        this.position = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (player == null)
            return;
        float fDistance = player.transform.position.x - transform.position.x;

        if (fDistance < -15.0f)
        {
            JumpLeft();
        }
        if (fDistance > 25.0f)
        {
            JumpRight();
        }

    }
    public void JumpLeft()
    {
        transform.position = new Vector3(this.position.x - this.interval, this.position.y, this.position.z);
        position = transform.position;
    }

    public void JumpRight()
    {
        transform.position = new Vector3(this.position.x + this.interval, this.position.y, this.position.z);
        position = transform.position;
    }
    public void JumpObj(int dir)
    {
        transform.position = new Vector3(this.position.x + this.interval * dir, this.position.y, this.position.z);
        position = transform.position;
    }
}
