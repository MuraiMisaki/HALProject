using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;     // シーンマネージャを使えるようにする。

public class SceneManagerCS : MonoBehaviour {

    public string[] nextScene = new string[1];
    public string prevScene;
    public int selectScene;
    protected GameObject bgmManager;

    // フェード用
    protected float fadeTime = 1.0f;
    public Fade fade = null;

    // Use this for initialization
    void Start () {
        fade = GameObject.Find("FadeImage").GetComponent<Fade>();
        bgmManager = GameObject.Find("BgmManager");
        selectScene = 0;
        fade.FadeOut(fadeTime);
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
        if (Input.GetKeyDown(KeyCode.Delete)) {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }

    virtual public void MoveNextScene(int i = 0)
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
            SceneManager.LoadScene(nextScene[i]);
        });
    }
    public void MovePrevScene()
    {
        // 文字列が入っていなければ
        if (prevScene.Length == 0)
            return;

        fade.FadeIn(fadeTime, () =>
        {
            SceneManager.LoadScene(prevScene);
        });
    }
}
