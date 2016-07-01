using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ShopSelectCS : MonoBehaviour {

    public Sprite NonGauge;
    public Sprite InGauge;
    public Sprite InitGauge;
    SpriteRenderer MainSprite;
    //定数定義
    const int PARTS_HEAD = 0;       //パーツ頭
    const int PARTS_SUIT = 1;       //パーツ服
    const int PARTS_BOOTS = 2;      //パーツ足
    const int PARTS_MAX = 2;        //パーツの最大数 0を含む
    const int PARTS_HEAD_MAX = 2;   //現在の頭パーツの最大数 0を含む
    const int PARTS_SUIT_MAX = 2;
    const int PARTS_BOOTS_MAX = 2;

    //クラス定義
    public HatClass HatClass;
    public SuitClass SuitClass;
    public BootsClass BootsClass;

    //グローバル変数
    int SelectParts = 0;    //0…頭パーツを設定1…服パーツを設定2…足パーツを設定

    //int HatPartsEdit = 0;   //頭装備を変更する変数

    int HatEquip = 0;           //頭装備
    int SuitEquip = 0;          //体装備
    int BootsEquips = 0;        //足装備
    //bool Initialize = false;
    int ShopPoint = 1234;

    int HatMount = 0;               //現在装備している頭装備
    int SuitMount = 0;              //現在(ry
    int BootsMount = 0;             //ry
    

    GameObject UFlame;
    GameObject MFlame;
    GameObject DFlame;
    GameObject[] Hat = new GameObject[3];
    GameObject[] Suit = new GameObject[3];
    GameObject[] Boots = new GameObject[3];
    GameObject Arrow1;
    GameObject Arrow2;
    GameObject Gauge;
    GameObject[] GaugeClone = new GameObject[19];
    GameObject ShopText;
    GameObject[] EquipIcon = new GameObject[3];
    GameObject PointText;
    // Use this for initialization
    void Start() {
        UFlame = GameObject.Find("UpFlame");
        MFlame = GameObject.Find("MiddleFlame");
        DFlame = GameObject.Find("DownFlame");
        Hat[0] = GameObject.Find("Hat1");
        Hat[1] = GameObject.Find("Hat2");
        Hat[2] = GameObject.Find("Hat3");
        Suit[0] = GameObject.Find("Suit1");
        Boots[0] = GameObject.Find("Boots1");
        Boots[1] = GameObject.Find("Boots2");
        Arrow1 = GameObject.Find("arrow1");
        Arrow2 = GameObject.Find("arrow2");
        EquipIcon[0] = GameObject.Find("HatEquipIcon");
        EquipIcon[1] = GameObject.Find("SuitEquipIcon");
        EquipIcon[2] = GameObject.Find("BootsEquipIcon");
        Gauge = GameObject.Find("HPGauge1");
        ShopText = GameObject.Find("ShopText");
        PointText = GameObject.Find("point");
        for (int i = 0; i < 19 ; i++)
        {
            float GaugeX = 0;
            float GaugeY = 0;
            switch (i)
            {
                case 0:
                case 5:
                case 10:
                case 15:
                    GaugeX = 5;
                    break;
                case 1:
                case 6:
                case 11:
                case 16:
                    GaugeX = 5.8f;
                    break;
                case 2:
                case 7:
                case 12:
                case 17:
                    GaugeX = 6.6f;
                    break;
                case 3:
                case 8:
                case 13:
                case 18:
                    GaugeX = 7.4f;
                    break;
                case 4:
                case 9:
                case 14:
                    GaugeX = 4.2f;
                    break;
            }
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    GaugeY = -2.6f;
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    GaugeY = -3.2f;
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    GaugeY = -3.8f;
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    GaugeY = -4.4f;
                    break;
            }
            GaugeClone[i] = Instantiate(Gauge) as GameObject;
            GaugeClone[i].transform.position = new Vector3(GaugeX,GaugeY);
            
        }
    }

    // Update is called once per frame
    void Update() {

        PointText.GetComponent<Text>().text = "PT: " + ShopPoint;
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
                        Hat[0].transform.position = new Vector3(-3.5f ,4.1f);
                        Hat[1].transform.position = new Vector3(-0.4f,3);
                        Hat[2].transform.position = new Vector3(-6, 3);
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat1の説明文";
                        HatEquipMount(HatEquip);
                        HatEquipIconMove();
                        break;
                    case 1:
                        Hat[0].transform.position = new Vector3(-6, 3);
                        Hat[1].transform.position = new Vector3(-3.5f, 4.1f);
                        Hat[2].transform.position = new Vector3(-0.4f, 3);
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat2\nの説明文";
                        HatEquipMount(HatEquip);
                        HatEquipIconMove();
                        break;
                    case 2:
                        Hat[0].transform.position = new Vector3(-0.4f, 3);
                        Hat[1].transform.position = new Vector3(-6, 3);
                        Hat[2].transform.position = new Vector3(-3.5f, 4.1f);
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat3の説明文";
                        HatEquipMount(HatEquip);
                        HatEquipIconMove();
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
                        Suit[0].transform.position = new Vector3(-3.5f ,-0.1f);
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit1の説明文";
                        SuitEquipMount(SuitEquip);
                        break;
                    case 1:
                        Suit[0].transform.position = new Vector3(-6, -0.1f);
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit2の説明文";
                        SuitEquipMount(SuitEquip);
                        break;
                    case 2:
                        Suit[0].transform.position = new Vector3(-0.4f, -0.1f);
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit3の説明文";
                        SuitEquipMount(SuitEquip);
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
                        Boots[0].transform.position = new Vector3(-3.7f, -3.5f);
                        Boots[1].transform.position = new Vector3(-0.5f, -3.5f);
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots1の説明文";
                        BootsEquipMount(BootsEquips);
                        break;
                    case 1:
                        Boots[0].transform.position = new Vector3(-6.1f, -3.5f);
                        Boots[1].transform.position = new Vector3(-3.7f, -3.5f);
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots2の説明文";
                        BootsEquipMount(BootsEquips);
                        break;
                    case 2:
                        Boots[0].transform.position = new Vector3(-0.5f, -3.5f);
                        Boots[1].transform.position = new Vector3(-6.1f, -3.5f);
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots3の説明文";
                        BootsEquipMount(BootsEquips);
                        break;

                }
               break;
        }


    }

    void GaugeInitialize()
    {
        MainSprite = Gauge.GetComponent<SpriteRenderer>();
        MainSprite.sprite = NonGauge;
        for (int i = 0; i < 19; i++)
        {
            MainSprite = GaugeClone[i].GetComponent<SpriteRenderer>();
            MainSprite.sprite = NonGauge;
        }

        MainSprite = Gauge.GetComponent<SpriteRenderer>();
        MainSprite.sprite = InitGauge;

        for (int i = 0; i < 4; i++)
        {
            MainSprite = GaugeClone[i].GetComponent<SpriteRenderer>();
            MainSprite.sprite = InitGauge;
        }
        for (int i = 0; i < 1; i++)
        {
            MainSprite = GaugeClone[i + 9].GetComponent<SpriteRenderer>();
            MainSprite.sprite = InitGauge;
        }

    }

    void HatGaugeUpdate(int HatEquip)
    {
        switch(HatEquip){
            case 0:
                for(int i = 0; i < HatClass.Hat1_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < HatClass.Hat1_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;

            case 1:
                for (int i = 0; i < HatClass.Hat2_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < HatClass.Hat2_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
            case 2:
                for (int i = 0; i < HatClass.Hat3_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < HatClass.Hat3_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
        }
    }
    
    void SuitGaugeUpdate(int SuitEquip){
        switch (SuitEquip)
        {
            case 0:
                for (int i = 0; i < SuitClass.Suit1_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < SuitClass.Suit1_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;

            case 1:
                for (int i = 0; i < SuitClass.Suit2_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < SuitClass.Suit2_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
            case 2:
                for (int i = 0; i < SuitClass.Suit3_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < SuitClass.Suit3_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
        }

    }

    void BootsGaugeUpdate(int BootsEquips)
    {
        switch (BootsEquips)
        {
            case 0:
                for (int i = 0; i < BootsClass.Boots1_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < BootsClass.Boots1_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;

            case 1:
                for (int i = 0; i < BootsClass.Boots2_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < BootsClass.Boots2_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
            case 2:
                for (int i = 0; i < BootsClass.Boots3_HP; i++)
                {
                    MainSprite = GaugeClone[i + 4].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }

                for (int i = 0; i < BootsClass.Boots3_Charisma; i++)
                {
                    MainSprite = GaugeClone[i + 10].GetComponent<SpriteRenderer>();
                    MainSprite.sprite = InGauge;
                }
                break;
        }

    }

    void HatEquipMount(int MountInt){
        if (Input.GetKeyDown(KeyCode.E)) {
            HatMount = MountInt;
        }
    }
    void SuitEquipMount(int MountInt)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SuitMount = MountInt;
        }
    }
    void BootsEquipMount(int MountInt)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BootsMount = MountInt;
        }
    }

    void HatEquipIconMove(){

        switch (HatMount) {
            case 0:
                switch (HatEquip){
                    case 0:
                        EquipIcon[0].transform.position = new Vector3(-3.5f,2.8f);
                        break;
                    case 1:
                        EquipIcon[0].transform.position = new Vector3(-6.0f, 2.8f);
                        break;
                    case 2:
                        EquipIcon[0].transform.position = new Vector3(-0.3f, 2.8f);
                        break;
                }
                break;
            case 1:
                switch (HatEquip)
                {
                    case 0:
                        EquipIcon[0].transform.position = new Vector3(-0.3f, 2.8f);
                        break;
                    case 1:
                        EquipIcon[0].transform.position = new Vector3(-3.5f, 2.8f);
                        break;
                    case 2:
                        EquipIcon[0].transform.position = new Vector3(-6.0f, 2.8f);
                        break;
                }
                break;
            case 2:
                switch (HatEquip)
                {
                    case 0:
                        EquipIcon[0].transform.position = new Vector3(-6.0f, 2.8f);
                        break;
                    case 1:
                        EquipIcon[0].transform.position = new Vector3(-0.3f, 2.8f);
                        break;
                    case 2:
                        EquipIcon[0].transform.position = new Vector3(-3.5f, 2.8f);
                        break;
                }
                break;
        }

    }

}


[System.Serializable]
public class HatClass {

    public int Hat1_HP;
    public int Hat1_Charisma;
    public int Hat1_NeedPoint;
    public bool Hat1_Buy;
    public int Hat2_HP;
    public int Hat2_Charisma;
    public int Hat2_NeedPoint;
    public bool Hat2_Buy;
    public int Hat3_HP;
    public int Hat3_Charisma;
    public int Hat3_NeedPoint;
    public bool Hat3_Buy;
}

[System.Serializable]
public class SuitClass{

    public int Suit1_HP;
    public int Suit1_Charisma;
    public int Suit1_NeedPoint;
    public bool Suit1_Buy;
    public int Suit2_HP;
    public int Suit2_Charisma;
    public int Suit2_NeedPoint;
    public bool Suit2_Buy;
    public int Suit3_HP;
    public int Suit3_Charisma;
    public int Suit3_NeedPoint;
    public bool Suit3_Buy;
}

[System.Serializable]
public class BootsClass{

    public int Boots1_HP;
    public int Boots1_Charisma;
    public int Boots1_NeedPoint;
    public bool Boots1_Buy;
    public int Boots2_HP;
    public int Boots2_Charisma;
    public int Boots2_NeedPoint;
    public bool Boots2_Buy;
    public int Boots3_HP;
    public int Boots3_Charisma;
    public int Boots3_NeedPoint;
    public bool Boots3_Buy;
}
