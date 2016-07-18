using UnityEngine;
using System.Collections;

public class StageSceneManagerCS : SceneManagerCS {
    
	// Use this for initialization
	void Start () {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        fade.FadeOut(fadeTime);
        bgmManager = GameObject.Find("BgmManager");
        bgmManager.GetComponent<BgmManager>().Play("BGM_PartySelect");
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
}
