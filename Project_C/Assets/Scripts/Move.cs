using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

    private int i;
    private GameObject No;

	// Use this for initialization
	void Start () {
        i = 0;
        No = GameObject.Find("No");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow)) {
        }
	}
}
