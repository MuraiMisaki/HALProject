using UnityEngine;
using System.Collections;

public class PartyChangeSceneManagerCS : SceneManagerCS
{
    // Use this for initialization
    void Start ()
    {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        fade.FadeOut(fadeTime);
        bgmManager = GameObject.Find("BgmManager");
        bgmManager.GetComponent<BgmManager>().Play("BGM_PartySelect");

    }
	
	// Update is called once per frame
	void Update () {
        // キャンセルキーが押されたら
        if (Input.GetButtonDown("Cancel"))
        {
            // 前のシーンへ移動
            MovePrevScene();
        }

    }
}
