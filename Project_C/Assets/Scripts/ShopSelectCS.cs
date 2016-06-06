using UnityEngine;
using System.Collections;



public class ShopSelectCS : MonoBehaviour {

    //定数定義
    const int PARTS_HEAD = 0;       //パーツ頭
    const int PARTS_SUIT = 1;       //パーツ服
    const int PARTS_BOOTS = 2;      //パーツ足
    const int PARTS_MAX = 2;        //パーツの最大数 0を含む
    const int PARTS_HEAD_MAX = 2;   //現在の頭パーツの最大数 0を含む
    const int PARTS_SUIT_MAX = 2;
    const int PARTS_BOOTS_MAX = 2;

    //グローバル変数
    int SelectParts = 0;    //0…頭パーツを設定1…服パーツを設定2…足パーツを設定
    int HatPartsEdit = 0;   //頭装備を変更する変数

    int HatEquip = 0;           //頭装備
    int SuitEquip = 0;          //体装備
    int BootsEquips = 0;        //足装備
    bool Initialize = false;

    GameObject UFlame;
    GameObject MFlame;
    GameObject DFlame;
    GameObject Hat1;
    GameObject Hat2;
    GameObject Hat3;
    GameObject Suit1;
    GameObject Boots1;
    GameObject Boots2;
    GameObject Arrow1;
    GameObject Arrow2;
    // Use this for initialization
    void Start () {
        UFlame = GameObject.Find("UpFlame");
        MFlame = GameObject.Find("MiddleFlame");
        DFlame = GameObject.Find("DownFlame");
        Hat1 = GameObject.Find("Hat1");
        Hat2 = GameObject.Find("Hat2");
        Hat3 = GameObject.Find("Hat3");
        Suit1 = GameObject.Find("Suit1");
        Boots1 = GameObject.Find("Boots1");
        Boots2 = GameObject.Find("Boots2");
        Arrow1 = GameObject.Find("arrow1");
        Arrow2 = GameObject.Find("arrow2");
    }

    // Update is called once per frame
    void Update() {

        // キー入力下を押された時
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if (SelectParts < PARTS_MAX)
            {
                SelectParts++;
            }else{
                SelectParts = 0;
            }
        }
        // キー入力上を押された時
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (SelectParts > 0){
                SelectParts--;
            }else{
                SelectParts = 2;
            }
        }
        // キー入力左を押された時
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            switch(SelectParts)
            {
                case PARTS_HEAD:
                    if (HatEquip > 0)
                    {
                        HatEquip--;
                    }
                    else
                    {
                        HatEquip = PARTS_HEAD_MAX;
                    }
                    break;
                case PARTS_SUIT:
                    if (SuitEquip > 0)
                    {
                        SuitEquip--;
                    }
                    else
                    {
                        SuitEquip = PARTS_SUIT_MAX;
                    }
                    break;
                case PARTS_BOOTS:
                    if (BootsEquips > 0)
                    {
                        BootsEquips--;
                    }
                    else
                    {
                        BootsEquips = PARTS_BOOTS_MAX;
                    }
                    break;
            }
        }
        // キー入力右を押された時
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            switch (SelectParts)
            {
                case PARTS_HEAD:
                    if (HatEquip < PARTS_HEAD_MAX)
                    {
                        HatEquip++;
                    }
                    else
                    {
                        HatEquip = 0;
                    }
                    break;

                case PARTS_SUIT:
                    if (SuitEquip < PARTS_SUIT_MAX)
                    {
                        SuitEquip++;
                    }
                    else
                    {
                        SuitEquip = 0;
                    }
                    break;
                case PARTS_BOOTS:
                    if (BootsEquips < PARTS_BOOTS_MAX)
                    {
                        BootsEquips++;
                    }
                    else
                    {
                        BootsEquips = 0;
                    }
                    break;
            }
        }

        // パーツの選択位置の更新
        switch (SelectParts)
        {

            //セレクトパーツが頭の変数に入っているのなら
            case PARTS_HEAD:
                UFlame.GetComponent<SpriteRenderer>().color = Color.red;
                MFlame.GetComponent<SpriteRenderer>().color = Color.green;
                DFlame.GetComponent<SpriteRenderer>().color = Color.green;
                Arrow1.GetComponent<Animator>().SetTrigger("ShiftUp");
                Arrow2.GetComponent<Animator>().SetTrigger("UpTrigger");
                //頭装備の変更
                switch (HatEquip)
                {
                    case 0:
                        Hat1.transform.position = new Vector3(-3.5f ,4);
                        Hat2.transform.position = new Vector3(-0.4f,3);
                        Hat3.transform.position = new Vector3(-6, 3);
                        break;
                    case 1:
                        Hat1.transform.position = new Vector3(-6, 3);
                        Hat2.transform.position = new Vector3(-3.5f, 4);
                        Hat3.transform.position = new Vector3(-0.4f, 3);
                        break;
                    case 2:
                        Hat1.transform.position = new Vector3(-0.4f, 3);
                        Hat2.transform.position = new Vector3(-6, 3);
                        Hat3.transform.position = new Vector3(-3.5f, 4);
                        break;
                }
                break;
            //セレクトパーツが(略
            case PARTS_SUIT:
                UFlame.GetComponent<SpriteRenderer>().color = Color.green;
                MFlame.GetComponent<SpriteRenderer>().color = Color.red;
                DFlame.GetComponent<SpriteRenderer>().color = Color.green;
                Arrow1.GetComponent<Animator>().SetTrigger("ShiftMiddle");
                Arrow2.GetComponent<Animator>().SetTrigger("MiddleTrigger");
                //頭装備の変更
                switch (SuitEquip)
                {
                    case 0:
                        Suit1.transform.position = new Vector3(-3.5f ,0.4f);

                        break;
                    case 1:
                        Suit1.transform.position = new Vector3(-6, 0.4f);
                        break;
                    case 2:
                        Suit1.transform.position = new Vector3(-0.4f, 0.4f);
                        break;

                }
                break;
            //セレクトパーツが(略
            case PARTS_BOOTS:
                UFlame.GetComponent<SpriteRenderer>().color = Color.green;
                MFlame.GetComponent<SpriteRenderer>().color = Color.green;
                DFlame.GetComponent<SpriteRenderer>().color = Color.red;
                Arrow1.GetComponent<Animator>().SetTrigger("ShiftDown");
                Arrow2.GetComponent<Animator>().SetTrigger("DownTrigger");
                switch (BootsEquips)
                {
                    case 0:
                        Boots1.transform.position = new Vector3(-3.7f, -3.5f);
                        Boots2.transform.position = new Vector3(-0.5f, -3.5f);
                        break;
                    case 1:
                        Boots1.transform.position = new Vector3(-6.1f, -3.5f);
                        Boots2.transform.position = new Vector3(-3.7f, -3.5f);
                        break;
                    case 2:
                        Boots1.transform.position = new Vector3(-0.5f, -3.5f);
                        Boots2.transform.position = new Vector3(-6.1f, -3.5f);
                        break;

                }
               break;
        }


    }
}
