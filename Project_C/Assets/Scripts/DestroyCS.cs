using UnityEngine;
using System.Collections;

public class DestroyCS : MonoBehaviour {

    public float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
