using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

    private GameObject No;
    GameObject Manager;
    
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("Manager");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            this.transform.localPosition = new Vector3(0, -30, 0);
        }

        if (this.transform.localPosition.y > 0) {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (this.transform.localPosition.x < 200)
                {
                    this.transform.localPosition += new Vector3(140, 0, 0);
                }
                else {
                    this.transform.localPosition = new Vector3(340, 85, 0);
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (this.transform.localPosition.x < 210)
                {
                    if (this.transform.localPosition.x > -210)
                        this.transform.localPosition += new Vector3(-140, 0, 0);
                }
                else {
                    this.transform.localPosition = new Vector3(210, 120, 0);
                }

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TexManager Ma = Manager.GetComponent<TexManager>();
                if (this.transform.localPosition.x < 250)
                    Ma.Setdef(No);
            }
 
        
        }
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {

                this.transform.localPosition = new Vector3(-210, 120, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                    TexManager Ma = Manager.GetComponent<TexManager>();
                    Ma.GetTex(No);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        No = collision.gameObject;
    }
}
