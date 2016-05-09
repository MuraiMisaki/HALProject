using UnityEngine;
using System.Collections;

public class CreateObject : MonoBehaviour {
    public GameObject recastGage;
    public GameObject creatObj;

    public KeyCode keyCode;

    private Vector3 clicPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyCode))
        {
            if (recastGage.GetComponent<RecastTimeGageCS>().isUpdate)
                return;
            if (transform.root.gameObject.GetComponent<GameMainPlayerCS>().moveDir != 0)
                return;
            recastGage.GetComponent<RecastTimeGageCS>().StartRecastGage();
            Instantiate(creatObj, this.transform.position, creatObj.transform.rotation);
        }
    }
    public void CreateObj() {
        if (recastGage.GetComponent<RecastTimeGageCS>().isUpdate)
            return;
        recastGage.GetComponent<RecastTimeGageCS>().StartRecastGage();
        Instantiate(creatObj, this.transform.position, creatObj.transform.rotation);
    }
}
