using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

    private GameObject No;

	// Use this for initialization
	void Start () {
        No = GameObject.Find("No");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (Transform child in transform)
            {
                //child is your child transform
                child.transform.localPosition += new Vector3(-140, 0, 0);

                if (child.transform.localPosition.x < -840)
                {
                    child.transform.localPosition += new Vector3(1680, 0, 0);
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (Transform child in transform)
            {
                //child is your child transform
                child.transform.localPosition += new Vector3(140, 0, 0);

                if (child.transform.localPosition.x > 840)
                {
                    child.transform.localPosition += new Vector3(-1680, 0, 0);
                }

            }
        }
	}
}
