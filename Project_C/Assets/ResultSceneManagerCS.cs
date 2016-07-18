using UnityEngine;
using System.Collections;

public class ResultSceneManagerCS : SceneManagerCS {

	// Use this for initialization
	void Start ()
    {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        bgmManager = GameObject.Find("BgmManager");
        selectScene = 0;
        fade.FadeOut(fadeTime);

        // 削除するオブジェクトの登録
        GameObject obj;
        obj = GameObject.Find("StatusUI");
        GetComponent<DeleteObjCS>().AddDestroyObj(obj);

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
