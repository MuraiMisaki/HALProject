using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeleteObjCS : MonoBehaviour {

    private List<GameObject> DestroyObj = new List<GameObject>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddDestroyObj(GameObject obj) {
        DestroyObj.Add(obj);
    }

    void OnDestroy() {
        int objCnt = DestroyObj.Count;
        for (int i = 0; i < objCnt; i++) {
            Destroy(DestroyObj[i]);
        }
    }
}
