using UnityEngine;
using System.Collections;

public class BillboardCS : MonoBehaviour {

    public Camera targetCamera;    // カメラ

	// Use this for initialization
	void Start () {
        // 対象のカメラが設定されていなかったら…
        if (this.targetCamera == null) {
            // メインカメラを取得する
            this.targetCamera = Camera.main;
        }
    }

	// Update is called once per frame
	void Update () {

        // カメラの方向を見る
        this.transform.LookAt(this.targetCamera.transform.position);

	}
}