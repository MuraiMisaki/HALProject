using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetDatabaseCS : MonoBehaviour {

    private StageDatabase stagedata;
    //private GameProgressionData gamePression;
    public Text bossName;
    public Canvas canvas;
    private int stegeNum;
    // Use this for initialization
    void Start () {
        // ステージデータ読み込み
        stagedata = Resources.Load("Database/StageData") as StageDatabase;
        //// ゲーム進行データ読み込み
        //gamePression = Resources.Load("Database/GameProgression") as GameProgressionData;
        stegeNum = PlayerPrefs.GetInt("SelectStage");

        // もしクリアしたことなければ
        if (!stagedata.stageData[stegeNum].isClear)
        {
            bossName.text = stagedata.stageData[stegeNum].bossName;
            stagedata.stageData[stegeNum].isClear = true;
        }
        else
        {
            canvas.enabled = false;
        }

        // ステージ背景生成
        // 背景作成
        int num = stagedata.stageData[stegeNum].BGObj.Count;
        for (int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(stagedata.stageData[stegeNum].BGObj[i]);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
