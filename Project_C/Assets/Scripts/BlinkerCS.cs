using UnityEngine;
using System.Collections;

// 点滅させるよ

public class BlinkerCS : MonoBehaviour {
    public SpriteRenderer sprite;   // 点滅画像
    public float intervalTime;  // 点滅間隔
    public int BlinkNum;    // 点滅回数
    private int BlinkCnt;

    private bool isBlink;       // 点滅しているか

	// Use this for initialization
	void Start () {
        BlinkCnt = 0;
        isBlink = false;
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    IEnumerator Blinker() {

        while (BlinkCnt > 0)
        {
            // 切り替え
            sprite.enabled = false;
            yield return new WaitForSeconds(intervalTime);

            // 切り替え
            sprite.enabled = true;
            yield return new WaitForSeconds(intervalTime);

            BlinkCnt--;
        }

        // 切り替え 念のため
        sprite.enabled = true;
        yield return new WaitForSeconds(intervalTime);
    }
    public void StopBlink() {
        BlinkCnt = 0;
    }

    public void StartBink() {
        // カウンター初期化
        BlinkCnt = BlinkNum;
        if (!isBlink)       // 点滅中ではなかったら
        {
            StartCoroutine("Blinker");
        }
    }

}
