using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;     // シーンマネージャを使えるようにする。

public class SceneManagerCS : MonoBehaviour {

    public string[] nextScene = new string[1];
    public string prevScene;
    public int selectScene;

    // Use this for initialization
    void Start () {
        selectScene = 0;
    }
	
	// Update is called once per frame
	void Update () {
        // Enterキーが押されたら
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 次のシーンへ移動
            MoveNextScene(selectScene);
        }

        if (Input.GetKeyDown(KeyCode.Delete)) {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }

    void MoveNextScene(int i)
    {
        if (i < 0 || i >= nextScene.Length)
        {
            Debug.Log("ERROR SCENE TRANSITION!");
            return;
        }
        // 文字列が入っていなければ
        if (nextScene[i].Length == 0)
            return;

        SceneManager.LoadScene(nextScene[i]);
    }
    void MovePrevScene()
    {
        // 文字列が入っていなければ
        if (prevScene.Length == 0)
            return;

        SceneManager.LoadScene(prevScene);
    }
}
