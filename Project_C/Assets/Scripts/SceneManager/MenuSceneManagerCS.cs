using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;     // シーンマネージャを使えるようにする。

public class MenuSceneManagerCS : SceneManagerCS
{
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

        // キャンセルキーが押されたら
        if (Input.GetButtonDown("Cancel"))
        {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }
    override public void MoveNextScene(int i = 0)
    {
        if (i < 0 || i >= nextScene.Length)
        {
            Debug.Log("ERROR SCENE TRANSITION!");
            return;
        }
        // 文字列が入っていなければ
        if (nextScene[i].Length == 0)
            return;
        fade.FadeIn(fadeTime, () =>
        {
            bgmManager.GetComponent<BgmManager>().Play(bgmName[i]);
            SceneManager.LoadScene(nextScene[i]);
        });
    }
}
