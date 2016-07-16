using UnityEngine;
using System.Collections;

public class MenuSceneManagerCS : SceneManagerCS
{
    private GameObject bgmManager;
    public string[] bgmName = new string[3];

	// Use this for initialization
	void Start ()
    {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        bgmManager = GameObject.Find("BgmManager");
        bgmManager.GetComponent<BgmManager>().Play("BGM_Title");

        fade.FadeOut(fadeTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveNextScene(0);
            bgmManager.GetComponent<BgmManager>().Play(bgmName[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveNextScene(1);
            bgmManager.GetComponent<BgmManager>().Play(bgmName[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveNextScene(2);
            bgmManager.GetComponent<BgmManager>().Play(bgmName[2]);
        }

        // キャンセルキーが押されたら
        if (Input.GetButtonDown("Cancel"))
        {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }
}
