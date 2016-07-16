using UnityEngine;
using System.Collections;

public class BGMCS : MonoBehaviour
{
    public string bgmName;
    private bool isPlay = false;
    void Start() {
    }
    void Update()
    {
        if (!isPlay)
        {
            GetComponent<BgmManager>().Play(bgmName);
            isPlay = true;
        }


    }
}
