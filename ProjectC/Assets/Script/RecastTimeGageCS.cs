using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecastTimeGageCS : MonoBehaviour {
    
    public Image image;
    public float recastTime;
    private float filledGage;
    public bool isUpdate;
    public Text timeText;
    // Use this for initialization
    void Start () {
        isUpdate = false;
        filledGage = 0.0f;
        timeText.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!this.isUpdate)
            return;
        // ゲージ更新
        UpdateRecastTime();
        // 画像に反映
        this.image.fillAmount = this.filledGage;

    }

    public void StartRecastGage() {
        // nullCheck
        if (this.image == null)
            return;

        this.isUpdate = true;
        this.filledGage = 1.0f;
    }

    void UpdateRecastTime() {

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
            // 文字に反映
            timeText.text = "";

        }
        else {
            // 文字に反映
            this.timeText.text = ((int)(filledGage * recastTime) + 1).ToString();
        }

    }
}
