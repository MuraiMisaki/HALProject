using UnityEngine;
using System.Collections;

public class GameMainSceneManagerCS : SceneManagerCS
{

    private GameObject bgmManager;
    // Use this for initialization
    void Start ()
    {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        fade.FadeOut(fadeTime);
        bgmManager = GameObject.Find("BgmManager");
        StageData stageData = GetComponent<GetStageDatabaseCS>().GetStageData();
        bgmManager.GetComponent<BgmManager>().Play(stageData.bgm);
    }
	
	// Update is called once per frame
	void Update () {
        // 決定キーが押されたら
        if (Input.GetButtonDown("Submit"))
        {
            // 次のシーンへ移動
            MoveNextScene(selectScene);
        }
        // キャンセルキーが押されたら
        if (Input.GetButtonDown("Cancel"))
        {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }
    public void PlayBossBGM() {

        bgmManager.GetComponent<BgmManager>().Play("BGM_Stage_Boss");
    }
}
