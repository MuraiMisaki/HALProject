using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;     // シーンマネージャを使えるようにする。

public class TitleManagerCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Enterキーが押されたら
        if (Input.GetKeyDown(KeyCode.Return)) {
            // メニュー画面へ移動
            MoveToMenu();
        }
	}
    void MoveToMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
