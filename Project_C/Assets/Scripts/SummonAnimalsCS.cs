using UnityEngine;
using System.Collections;

public class SummonAnimalsCS : MonoBehaviour {

    public GameObject summonsAnimals;
    public GameObject recastGage;
    public float recastTime;

    public KeyCode summonCode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(summonCode)) {
            if (recastGage.GetComponent<RecastTimeGageCS>().IsUpdate())
                return;
            recastGage.GetComponent<RecastTimeGageCS>().StartRecastGage(recastTime);
            Instantiate(summonsAnimals,transform.position,transform.rotation);
        }
	}
}
