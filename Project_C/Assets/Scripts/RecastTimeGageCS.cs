using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecastTimeGageCS : MonoBehaviour {
    public Image gageImage;         // 残り時間表示用ゲージ画像
    public Text timeText;           // 残り時間表示用テキスト
    private float filledGage;       // 残り時間割合
    private bool isUpdate;           // 更新中か？
    private float recastTime;       // リキャストタイム
    

	// Use this for initialization
	void Start () {
        // 初期化
        recastTime = 0.0f;
        filledGage = 0.0f;
        timeText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        // 更新フラグ確認
        if (!this.isUpdate)
            return;
        // 時間更新
        UpdateTime();

        // 文字に反映
        if (this.filledGage == 0.0f)
        {
            timeText.text = "";
        }
        else
        {
            // 整数化して文字に反映
            this.timeText.text = ((int)(filledGage * recastTime) + 1).ToString();
        }

        // 画像に反映
        this.gageImage.fillAmount = this.filledGage;
    }

    void UpdateTime() {

        // ゼロ除算回避
        if (this.recastTime == 0.0f)
        {
            // 初期化
            this.filledGage = 0.0f;
            this.isUpdate = false;
            return;
        }

        // 経過時間に応じてタイムを減少
        this.filledGage -= 1.0f / this.recastTime * Time.deltaTime;

        // 下限制限
        if (this.filledGage <= 0.0f)
        {
            this.filledGage = 0.0f;
            this.isUpdate = false;
        }
    }

    // 外部から呼び出し　ゲージの更新を始める
    public void StartRecastGage(float time) {
        this.recastTime = time;
        this.filledGage = 1.0f;
        this.isUpdate = true;
        if (this.recastTime == 0.0f)
        {
            filledGage = 0.0f;
            this.isUpdate = false;
            timeText.text = "";
        }
    }
    public bool IsUpdate() {
        return isUpdate;
    }
}
