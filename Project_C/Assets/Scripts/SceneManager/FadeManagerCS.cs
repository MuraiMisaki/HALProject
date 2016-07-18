using UnityEngine;
using System.Collections;

public class FadeManagerCS : MonoBehaviour {

    #region Singleton

    private static FadeManagerCS instance;

    public static FadeManagerCS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (FadeManagerCS)FindObjectOfType(typeof(FadeManagerCS));

                if (instance == null)
                {
                    Debug.LogError(typeof(FadeManagerCS) + "is nothing");
                }
            }

            return instance;
        }
    }

    #endregion Singleton

    void Awake() {
        //シングルトンのためのコード
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}

