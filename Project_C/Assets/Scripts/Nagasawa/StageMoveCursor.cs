﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageMoveCursor : MonoBehaviour{

    private List<Vector3> myList = new List<Vector3>();
    private GameObject Stage;
    private int count;

    private GameObject StageData;



	// Use this for initialization
	void Start () {
        Stage = GameObject.Find("Stage");
        StageData = GameObject.Find("StageData/StageText");
        foreach (Transform child in Stage.transform)
        {
            myList.Add(child.localPosition);
        }
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            count++;
            if (count <= 11) {
                this.transform.localPosition = myList[count];
            }
            else {
                count = 0;
                this.transform.localPosition = myList[count];
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            count--;
            if (count >= 0) {
                this.transform.localPosition = myList[count];
            }
            else {
                count = 11;
                this.transform.localPosition = myList[count];
            }
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        StageData.GetComponent<ChangeStageText>().GetStageData(collision.gameObject);
    }

}