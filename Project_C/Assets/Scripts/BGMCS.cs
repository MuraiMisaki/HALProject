using UnityEngine;
using System.Collections;

public class BGMCS : MonoBehaviour
{

    private static bool isCreate = false;        // 生成されているか
    private bool isDontDestroy = false;
    public bool isChange = false;
    // Use this for initialization
    void Awake()
    {
        // 生成されていない
        if (!isCreate)
        {
            Debug.Log("Creat");
            isCreate = true;
            isDontDestroy = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Debug.Log("Created");
            Destroy(this.gameObject);
        }
    }
    // 新しくシーンが移動したとき
    void OnLevelWasLoaded()
    {

        Debug.Log("Load");
        if (isChange) {
            DontDestroyOnLoad(this.gameObject);
            GameObject[] bgmObjs;
            bgmObjs = GameObject.FindGameObjectsWithTag("BGM");
            for (int i = 0; i < bgmObjs.Length; i++) {
                if (bgmObjs[i].gameObject == this.gameObject)
                {
                    continue;
                }
                Destroy(bgmObjs[i].gameObject);
            }
        }
        //Debug.Log("Load");
        //// BGMオブジェクト検索
        //GameObject[] bgmObjs;
        //bgmObjs = GameObject.FindGameObjectsWithTag("BGM");
        //for (int i = 0; i < bgmObjs.Length; i++)
        //{
        //    if (bgmObjs[i].gameObject == this.gameObject)
        //        continue;

        //    // 曲の変更があるかどうか
        //    if (this.gameObject.GetComponent<AudioSource>().clip != bgmObjs[i].GetComponent<AudioSource>().clip)
        //    {
        //        isChange = true;
        //        // 新しいオブジェクトを残す
        //        DontDestroyOnLoad(bgmObjs[i].gameObject);
        //    }
        //}
        //// 変更アリ
        //if (isChange)
        //{
        //    Destroy(this.gameObject);
        //}
        //// 変更なし
        //else {
        //    for (int i = 0; i < bgmObjs.Length; i++)
        //    {
        //        if (bgmObjs[i].gameObject == this.gameObject)
        //            continue;
        //        Destroy(bgmObjs[i].gameObject);
        //    }
        //}
    }
}
