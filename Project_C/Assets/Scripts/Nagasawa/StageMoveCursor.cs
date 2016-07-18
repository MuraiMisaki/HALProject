using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageMoveCursor : MonoBehaviour{

    private List<Vector3> myList = new List<Vector3>();
    private GameObject Stage;
    private int count;

    private GameObject StageData;

    private GameProgressionData StageNoData;
    private GameObject BackGroud;

	// Use this for initialization
	void Start () {
        Stage = GameObject.Find("Stage");
        BackGroud = GameObject.Find("Back");
        StageData = GameObject.Find("StageData/StageText");
        StageNoData = Resources.Load("Database/GameProgression") as GameProgressionData;
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
            BackGroud.GetComponent<StageSelectBackCS>().ChangeBG(count);
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

            BackGroud.GetComponent<StageSelectBackCS>().ChangeBG(count);
        }

        if (Input.GetButtonDown("Submit")) {
            PlayerPrefs.SetInt("SelectStage", count);
            //            StageNoData.selectStage = count;
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        StageData.GetComponent<ChangeStageText>().GetStageData(collision.gameObject);
    }

}
