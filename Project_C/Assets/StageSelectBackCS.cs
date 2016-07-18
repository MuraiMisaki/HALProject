using UnityEngine;
using System.Collections;

public class StageSelectBackCS : MonoBehaviour {

    private StageDatabase stageData;
    private int SelectStage;
    public GameObject[] StageBG = new GameObject[12]; 
    // Use this for initialization
    void Start ()
    {
        SelectStage = 0;
        stageData = Resources.Load("Database/StageData") as StageDatabase;

        for (int j = 0; j < 12; j++)
        {
            // 背景作成
            int num = stageData.stageData[j].BGObj.Count;
            for (int i = 0; i < num; i++)
            {
                GameObject obj = Instantiate(stageData.stageData[j].BGObj[i]);
                obj.transform.parent = StageBG[j].transform;
                StageBG[j].SetActive(false);
            }
        }
        ChangeBG(0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeBG(int num)
    {
        StageBG[SelectStage].SetActive(false);
        SelectStage = num;
        StageBG[SelectStage].SetActive(true);
    }
}
