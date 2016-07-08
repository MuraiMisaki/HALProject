using UnityEngine;
using System.Collections;

public enum FrendType
{
    Attacker,   // アタッカー
    Tricky,     // トリッキー
    Defense,    // ディフェンス
    Recovery,   // 回復
}
public class FrendsCS : MonoBehaviour {

    public GameObject animChild;        // アニメーションを持つオブジェクト
    protected Animator anim;            // アニメーター
    protected FrendType frendType;      // タイプ


    // Use this for initialization
    void Start () {
        anim = animChild.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update () {
	
	}
    public FrendType GetFrendType() {
        return frendType;
    }
}
