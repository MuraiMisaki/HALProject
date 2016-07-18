using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TexManager : MonoBehaviour {

    public Sprite def;                  // デフォルト用の透明画像

    private GameObject TexData;         // 受け取ったテクスチャデータ
    private bool Tex_Flg;               // テクスチャを受け取ったか？
    private int SameTex_cnt;            // 同一テクスチャの枚数

    private int[] NoList = new int[4];

    private int CharNoData;         // キャラの番号データ
    private int count = 0;

    private GameProgressionData CharacterNoData;

	// 初期化
	void Start () {
        CharacterNoData = Resources.Load("Database/GameProgression") as GameProgressionData;
        Tex_Flg = false;    // テクスチャを受け取っていない
        SameTex_cnt = 0;    // 同一テクスチャは０枚
        CharNoData = -1;
        foreach (Transform child in transform)
        {
            NoList[count] = -1;
            count++;
        }
        count = 0;
	}
	
	// 更新
	void Update () {
        // テクスチャ取得のフラグがONになったら
        if (Tex_Flg)
        {
            // 子オブジェクトすべて参照
            foreach (Transform child in transform)
            {
                // もし受け取ったテクスチャデータと今のテクスチャデータが同じか？
                if (child.GetComponent<Image>().sprite == TexData.GetComponent<Image>().sprite)
                {
                    // 同一テクスチャの枚数を１プラス
                    SameTex_cnt++;
                }
            }

            // 子オブジェクトすべて参照
            foreach (Transform child in transform)
            {
                // もし今のテクスチャデータがデフォルトかつ同一テクスチャの枚数が０枚か？
                if (child.GetComponent<Image>().sprite == def && SameTex_cnt == 0)
                {
                    // 今のテクスチャデータに受け取ったテクスチャデータを挿入
                    child.GetComponent<Image>().sprite = TexData.GetComponent<Image>().sprite;

                    if (NoList[count] == -1) NoList[count] = CharNoData;

                    break;  // for終了
                }
                count++;

            }
            count = 0;
            SameTex_cnt = 0;    // 同一テクスチャは０枚
            Tex_Flg = false;    // テクスチャを受け取っていない
        }
	}

    // テクスチャ取得関数
    public void GetTex(GameObject Tex,int cnt)
    {
        TexData = Tex;      // 受けっとたデータをテクスチャデータに挿入
        CharNoData = cnt;
        Tex_Flg = true;     // テクスチャを受け取った
    }

    // デフォルトテクスチャセット関数
    public void Setdef(GameObject tex_def,int cnt)
    {
        NoList[cnt] = -1;
        // 今のテクスチャデータにデフォルトテクスチャを挿入
        tex_def.GetComponent<Image>().sprite = def;
    }

    public void SetList() {
        CharacterNoData.frends.Clear();
        for (int i = 0; i < 4; i++) {
            CharacterNoData.frends.Add(NoList[i]);
        }
    }

}
