using UnityEngine;
using System.Collections;

public class MoveAnimalsCS : MonoBehaviour {
    public float moveSpeed;
    private Vector3 position;
    private Vector3 viewPoint;
    private Vector3 endPoint;
    
    private float cntTime;

    public bool isRight = false;        //右から出てくる？
    // Use this for initialization
    void Start () {
        if (isRight)
        {
            this.viewPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
            this.endPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            this.transform.position = new Vector3(this.viewPoint.x + 0.5f, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            this.viewPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            this.endPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
            this.transform.position = new Vector3(this.viewPoint.x - 0.5f, this.transform.position.y, this.transform.position.z);
        }
        this.position = this.transform.position;
        cntTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        cntTime += Time.deltaTime;
        this.position.x += moveSpeed;
        this.transform.position = this.position;
        if (this.position.x <= this.endPoint.x - 0.5f && isRight)
        {
            Destroy(this.gameObject);
        }
        if (this.position.x >= this.endPoint.x + 0.5f && !isRight)
        {
            Destroy(this.gameObject);
        }
    }
}
