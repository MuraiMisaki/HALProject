using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetDatabaseCS : MonoBehaviour {

    private StageDatabase stagedata;
    public Text bossName;
    public Canvas canvas;
    // Use this for initialization
    void Start () {

 //       stagedata = Resources.Load("StageDatabase");
        if (!stagedata.stageData[0].isClear)
        {
            bossName.text = stagedata.stageData[0].bossName;
            stagedata.stageData[0].isClear = true;
        }
        else
        {
            canvas.enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
