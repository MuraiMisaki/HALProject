using UnityEngine;
using System.Collections;

public class GetStageDatabaseCS : MonoBehaviour {

//    public int stageNumber = 0;             // 後でシーン内で統一する。
//    public GameProgressionData gameData;    // ゲーム進行用データ
    public StageDatabase stageDatabase;
    public GameObject backgroundParent;
    private int stageNumber;
    // Use this for initialization
    void Awake () {
        // 現在のステージ番号を取得
        //       gameData = Resources.Load("Database/GameProgression") as GameProgressionData;
        stageNumber = PlayerPrefs.GetInt("SelectStage");//gameData.selectStage;
        if (stageNumber >= stageDatabase.stageData.Length)
            return;

        // 背景作成
        int num = stageDatabase.stageData[stageNumber].BGObj.Count;
        for (int i = 0; i < num; i++) {
            GameObject obj = Instantiate( stageDatabase.stageData[stageNumber].BGObj[i]);
            obj.transform.parent = backgroundParent.transform;
            if (i == 0) {
                backgroundParent.GetComponent<MoveProgressionCS>().SetMoveReference(obj);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public StageData GetStageData() {
        return stageDatabase.stageData[stageNumber];
    }
}
