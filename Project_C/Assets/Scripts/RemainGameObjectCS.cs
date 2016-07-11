using UnityEngine;
using System.Collections;

public class RemainGameObjectCS : MonoBehaviour {

    public GameObject[] remainObj = new GameObject[1];
    private bool isLoad;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < remainObj.Length; i++)
        {
            remainObj[i].transform.parent = this.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnLevelWasLoaded() {
        Debug.Log("SceNE!!");
        if (isLoad)
            return;

        for (int i = 0; i < remainObj.Length; i++)
        {
            remainObj[i].transform.parent = null;
        }
        isLoad = true;
    }
}
