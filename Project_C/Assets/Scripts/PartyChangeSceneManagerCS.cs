using UnityEngine;
using System.Collections;

public class PartyChangeSceneManagerCS : SceneManagerCS
{
	// Use this for initialization
	void Start () {
	
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
