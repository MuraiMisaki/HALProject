using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private GameObject cursor;

	// Use this for initialization
	void Start () {
        cursor = GameObject.Find("cursor");
	}
	
	// Update is called once per frame
	void Update () {

        if (cursor.transform.localPosition.y < 0) {

            if (Input.GetKeyDown(KeyCode.RightArrow)) {

                foreach (Transform child in transform) {
            
                    child.transform.localPosition += new Vector3(-140, 0, 0);

                    if (child.transform.localPosition.x < -840) {
                
                        child.transform.localPosition += new Vector3(1820, 0, 0);
                    }
                }
            }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        
                foreach (Transform child in transform) {

                    child.transform.localPosition += new Vector3(140, 0, 0);

                    if (child.transform.localPosition.x > 840) {

                        child.transform.localPosition += new Vector3(-1820, 0, 0);
                    }
                }
            }
        }

        foreach (Transform child in transform) {

            if (child.transform.localPosition.x < -280 || child.transform.localPosition.x > 280) {
                child.gameObject.SetActive(false);
            } else {
                child.gameObject.SetActive(true);
            }
        }
 
	}


}
