using UnityEngine;
using System.Collections;

public class RabbitTrigger : MonoBehaviour {

    private Transform Rabbit;

    public float Jump_line = 4.0f;

	// Use this for initialization
	void Start () {
        Rabbit = gameObject.transform.FindChild("Animator");
	}
	
	// Update is called once per frame
	void Update () {

        if (Rabbit.transform.localPosition.y > Jump_line)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }else{
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
	}
}
