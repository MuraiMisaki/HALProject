using UnityEngine;
using System.Collections;

public class MenuSceneManagerCS : SceneManagerCS
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveNextScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveNextScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveNextScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveNextScene(3);
        }

        // キャンセルキーが押されたら
        if (Input.GetButtonDown("Cancel"))
        {
            // 前のシーンへ移動
            MovePrevScene();
        }
    }
}
