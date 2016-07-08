using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

    private GameObject CharacterData;      // 干支＋猫の13体をまとめている親データ
    GameObject Manager;
    GameObject ChangeText;
    public GameObject partyChangeManager;
    
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("Manager");
        ChangeText = GameObject.Find("Text");
	}
	
	// Update is called once per frame
	void Update () {

        // 下に移動
        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            this.transform.localPosition = new Vector3(0, -30, 0);
        }

        // カーソルが上にあるとき
        if (this.transform.localPosition.y > 0) {

            // 右
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (this.transform.localPosition.x < 200)
                {
                    this.transform.localPosition += new Vector3(140, 0, 0);
                }
                else {
                    this.transform.localPosition = new Vector3(340, 85, 0);
                }

            }

            // 左
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (this.transform.localPosition.x < 220)
                {
                    if (this.transform.localPosition.x > -210)
                        this.transform.localPosition += new Vector3(-140, 0, 0);
                }
                else {
                    this.transform.localPosition = new Vector3(210, 120, 0);
                }

            }

            // 選択する
            if (Input.GetButtonDown("Submit"))
            {
                if (this.transform.localPosition.x > 250) {
                    partyChangeManager.GetComponent<PartyChangeSceneManagerCS>().MoveNextScene();
                }
                TexManager Ma = Manager.GetComponent<TexManager>();
                if (this.transform.localPosition.x < 250)
                    Ma.Setdef(CharacterData);
            }
 
        
        }
        // 下にある
        else {
            // 上
            if (Input.GetKeyDown(KeyCode.UpArrow)) {

                this.transform.localPosition = new Vector3(-210, 120, 0);
            }
            // 選択
            if (Input.GetButtonDown("Submit"))
            {
                    TexManager Ma = Manager.GetComponent<TexManager>();
                    Ma.GetTex(CharacterData);
                    
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterData = collision.gameObject;

        if (this.transform.localPosition.y < 0) ChangeText.GetComponent<ChangeText>().GetCharacterData(CharacterData);
    }
}
