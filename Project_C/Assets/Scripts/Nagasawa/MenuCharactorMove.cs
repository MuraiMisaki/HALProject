using UnityEngine;
using System.Collections;

public class MenuCharactorMove : MonoBehaviour {

    private GameObject Data;
    public SceneManagerCS SelectManager;
    private bool Check;
    // Use this for initialization 
	void Start () {
        Check = false;
        SelectManager = GameObject.Find("MenuSelectManager").GetComponent<SceneManagerCS>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Check) {

            switch (Data.name)
            {
                case "Shop":
                    SelectManager.MoveNextScene(1);
                    break;

                case "StageSelect":
                    SelectManager.MoveNextScene(0);

                    break;

                case "Gallery":
                    SelectManager.MoveNextScene(2);
                    break;

            }

            Check = false;
        }
	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Data = collision.gameObject;
    }

    public void SetFlg()
    {
        Check = true;
    }
}
