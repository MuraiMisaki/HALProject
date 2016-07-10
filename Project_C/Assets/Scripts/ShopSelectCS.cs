using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ShopSelectCS : MonoBehaviour {

    public Sprite NonGauge;
    public Sprite InGauge;
    public Sprite InitGauge;
    SpriteRenderer MainSprite;

    public Sprite InMark;
    SpriteRenderer Marksprite;

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
    int ShopPoint = 1234;
    int HatEquip = 0;           //頭装備
    int SuitEquip = 0;          //体装備
    int BootsEquips = 0;        //足装備

    int HatMount = 0;               //現在装備している頭装備
    int SuitMount = 0;              //現在(ry
    int BootsMount = 0;             //ry
    

    GameObject UFlame;
    GameObject MFlame;
    GameObject DFlame;
    GameObject[] Hat = new GameObject[3];
    GameObject[] Suit = new GameObject[3];
    GameObject[] Boots = new GameObject[4];
    GameObject Arrow1;
    GameObject Arrow2;
    GameObject Gauge;
    GameObject[] GaugeClone = new GameObject[19];
    GameObject ShopText;
    GameObject[] EquipIcon = new GameObject[3];
    GameObject PointText;
    GameObject BuyMark;
    GameObject[] BuyMarkClone = new GameObject[8];
    // Use this for initialization
    void Start() {
        UFlame = GameObject.Find("UpFlame");
        MFlame = GameObject.Find("MiddleFlame");
        DFlame = GameObject.Find("DownFlame");
        Hat[0] = GameObject.Find("Hat1");
        Hat[1] = GameObject.Find("Hat2");
        Hat[2] = GameObject.Find("Hat3");
        Suit[0] = GameObject.Find("Suit1");
        Suit[1] = GameObject.Find("Suit2");
        Suit[2] = GameObject.Find("Suit3");
        Boots[0] = GameObject.Find("Boots1");
        Boots[1] = GameObject.Find("Boots2");
        Boots[2] = GameObject.Find("Boots3");
        Boots[3] = GameObject.Find("Boots3_2");
        Arrow1 = GameObject.Find("arrow1");
        Arrow2 = GameObject.Find("arrow2");
        EquipIcon[0] = GameObject.Find("HatEquipIcon");
        EquipIcon[1] = GameObject.Find("SuitEquipIcon");
        EquipIcon[2] = GameObject.Find("BootsEquipIcon");
        Gauge = GameObject.Find("HPGauge1");
        ShopText = GameObject.Find("ShopText");
        PointText = GameObject.Find("point");
        BuyMark = GameObject.Find("BuyMark");
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
        for(int i = 0; i < 8; i++)
        {
            BuyMarkClone[i] = Instantiate(BuyMark) as GameObject;
            BuyMarkClone[i].transform.localScale = BuyMark.transform.localScale;
        }
        Marksprite = BuyMarkClone[2].GetComponent<SpriteRenderer>();
        Marksprite.sprite = InMark;
        BuyMarkClone[2].transform.position = Suit[0].transform.position + new Vector3(-0.85f, 0.85f);
        Marksprite = BuyMarkClone[5].GetComponent<SpriteRenderer>();
        Marksprite.sprite = InMark;
        BuyMarkClone[5].transform.position = Boots[0].transform.position + new Vector3(-0.85f, 0.85f);
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
                        BuyMark.transform.position = Hat[0].transform.position + new Vector3(-0.85f,-0.35f);
                        if (HatClass.Hat2_Buy == true)
                        {
                            BuyMarkClone[0].transform.position = Hat[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (HatClass.Hat3_Buy == true)
                        {
                            BuyMarkClone[1].transform.position = Hat[2].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat1の説明文";
                        HatEquipMount(HatEquip,HatClass.Hat1_Buy,HatClass.Hat1_NeedPoint);
                        EquipIconMove();
                        break;
                    case 1:
                        Hat[0].transform.position = new Vector3(-6, 3);
                        Hat[1].transform.position = new Vector3(-3.5f, 4.1f);
                        Hat[2].transform.position = new Vector3(-0.4f, 3);
                        BuyMark.transform.position = Hat[0].transform.position + new Vector3(-0.85f, 0.85f);
                        if (HatClass.Hat2_Buy == true)
                        {
                            BuyMarkClone[0].transform.position = Hat[1].transform.position + new Vector3(-0.85f, -0.35f);
                        }
                        if (HatClass.Hat3_Buy == true)
                        {
                            BuyMarkClone[1].transform.position = Hat[2].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat2\nの説明文";
                        HatEquipMount(HatEquip, HatClass.Hat2_Buy, HatClass.Hat2_NeedPoint);
                        EquipIconMove();
                        break;
                    case 2:
                        Hat[0].transform.position = new Vector3(-0.4f, 3);
                        Hat[1].transform.position = new Vector3(-6, 3);
                        Hat[2].transform.position = new Vector3(-3.5f, 4.1f);
                        BuyMark.transform.position = Hat[0].transform.position + new Vector3(-0.85f, 0.85f);
                        if (HatClass.Hat2_Buy == true)
                        {
                            BuyMarkClone[0].transform.position = Hat[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (HatClass.Hat3_Buy == true)
                        {
                            BuyMarkClone[1].transform.position = Hat[2].transform.position + new Vector3(-0.85f, -0.35f);
                        }
                        GaugeInitialize();
                        HatGaugeUpdate(HatEquip);
                        ShopText.GetComponent<Text>().text = "Hat3の説明文";
                        HatEquipMount(HatEquip,HatClass.Hat3_Buy, HatClass.Hat3_NeedPoint);
                        EquipIconMove();
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
                        Suit[1].transform.position = new Vector3(-0.4f ,-0.1f);
                        Suit[2].transform.position = new Vector3(-6,-0.1f);
                        if (SuitClass.Suit1_Buy == true)
                        {
                            BuyMarkClone[2].transform.position = Suit[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit2_Buy == true)
                        {
                            BuyMarkClone[3].transform.position = Suit[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit3_Buy == true)
                        {
                            BuyMarkClone[4].transform.position = Suit[2].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit1の説明文";
                        SuitEquipMount(SuitEquip,SuitClass.Suit1_Buy,SuitClass.Suit1_NeedPoint);
                        EquipIconMove();
                        break;
                    case 1:
                        Suit[0].transform.position = new Vector3(-6, -0.1f);
                        Suit[1].transform.position = new Vector3(-3.5f, -0.1f);
                        Suit[2].transform.position = new Vector3(-0.4f, -0.1f);
                        if (SuitClass.Suit1_Buy == true)
                        {
                            BuyMarkClone[2].transform.position = Suit[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit2_Buy == true)
                        {
                            BuyMarkClone[3].transform.position = Suit[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit3_Buy == true)
                        {
                            BuyMarkClone[4].transform.position = Suit[2].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit2の説明文";
                        SuitEquipMount(SuitEquip, SuitClass.Suit2_Buy, SuitClass.Suit2_NeedPoint);
                        EquipIconMove();
                        break;
                    case 2:
                        Suit[0].transform.position = new Vector3(-0.4f, -0.1f);
                        Suit[1].transform.position = new Vector3(-6f, -0.1f);
                        Suit[2].transform.position = new Vector3(-3.5f, -0.1f);
                        if (SuitClass.Suit1_Buy == true)
                        {
                            BuyMarkClone[2].transform.position = Suit[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit2_Buy == true)
                        {
                            BuyMarkClone[3].transform.position = Suit[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (SuitClass.Suit3_Buy == true)
                        {
                            BuyMarkClone[4].transform.position = Suit[2].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        GaugeInitialize();
                        SuitGaugeUpdate(SuitEquip);
                        ShopText.GetComponent<Text>().text = "Suit3の説明文";
                        SuitEquipMount(SuitEquip, SuitClass.Suit3_Buy, SuitClass.Suit3_NeedPoint);
                        EquipIconMove();
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
                        Boots[2].transform.position = new Vector3(-5.46f, -3.91f);
                        Boots[3].transform.position = new Vector3(-6.7f, -3.91f);
                        if (BootsClass.Boots1_Buy == true)
                        {
                            BuyMarkClone[5].transform.position = Boots[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots2_Buy == true)
                        {
                            BuyMarkClone[6].transform.position = Boots[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots3_Buy == true)
                        {
                            BuyMarkClone[7].transform.position = Boots[2].transform.position + new Vector3(-1.25f, 1.35f);
                        }
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots1の説明文";
                        BootsEquipMount(BootsEquips,BootsClass.Boots1_Buy,BootsClass.Boots1_NeedPoint);
                        EquipIconMove();
                        break;
                    case 1:
                        Boots[0].transform.position = new Vector3(-6.1f, -3.5f);
                        Boots[1].transform.position = new Vector3(-3.7f, -3.5f);
                        Boots[2].transform.position = new Vector3(0.3f, -3.91f);
                        Boots[3].transform.position = new Vector3(-1.14f, -3.91f);
                        if (BootsClass.Boots1_Buy == true)
                        {
                            BuyMarkClone[5].transform.position = Boots[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots2_Buy == true)
                        {
                            BuyMarkClone[6].transform.position = Boots[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots3_Buy == true)
                        {
                            BuyMarkClone[7].transform.position = Boots[2].transform.position + new Vector3(-1.25f, 1.35f);
                        }
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots2の説明文";
                        BootsEquipMount(BootsEquips, BootsClass.Boots2_Buy, BootsClass.Boots2_NeedPoint);
                        EquipIconMove();
                        break;
                    case 2:
                        Boots[0].transform.position = new Vector3(-0.5f, -3.5f);
                        Boots[1].transform.position = new Vector3(-6.1f, -3.5f);
                        Boots[2].transform.position = new Vector3(-2.72f, -3.91f);
                        Boots[3].transform.position = new Vector3(-4.32f, -3.91f);
                        if (BootsClass.Boots1_Buy == true)
                        {
                            BuyMarkClone[5].transform.position = Boots[0].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots2_Buy == true)
                        {
                            BuyMarkClone[6].transform.position = Boots[1].transform.position + new Vector3(-0.85f, 0.85f);
                        }
                        if (BootsClass.Boots3_Buy == true)
                        {
                            BuyMarkClone[7].transform.position = Boots[2].transform.position + new Vector3(-1.25f, 1.35f);
                        }
                        GaugeInitialize();
                        BootsGaugeUpdate(BootsEquips);
                        ShopText.GetComponent<Text>().text = "Boots3の説明文";
                        BootsEquipMount(BootsEquips, BootsClass.Boots3_Buy, BootsClass.Boots3_NeedPoint);
                        EquipIconMove();
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

    void HatEquipMount(int MountInt,bool HatBuy,int NeedPT){
        if (Input.GetButtonDown("Submit")) { 
            if (HatBuy == false )
            {
                if (ShopPoint >= NeedPT)
                {
                    ShopPoint -= NeedPT;
                    switch (MountInt)
                    {
                        case 0:
                            HatClass.Hat1_Buy = true;
                            break;
                        case 1:
                            HatClass.Hat2_Buy = true;
                             Marksprite = BuyMarkClone[0].GetComponent<SpriteRenderer>();
                            Marksprite.sprite = InMark;
                            break;
                        case 2:
                            HatClass.Hat3_Buy = true;
                            Marksprite = BuyMarkClone[1].GetComponent<SpriteRenderer>();
                            Marksprite.sprite = InMark;
                            break;
                    }
                    HatBuy = true;
                }
            }
            if (HatBuy == true) {
                HatMount = MountInt;
            }
        }
    }
    void SuitEquipMount(int MountInt,bool SuitBuy,int NeedPT)
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (SuitBuy == false)
            {
                if (ShopPoint >= NeedPT)
                {
                    ShopPoint -= NeedPT;
                    switch (MountInt)
                    {
                        case 0:
                            SuitClass.Suit1_Buy = true;
                            break;
                        case 1:
                            SuitClass.Suit2_Buy = true;
                            break;
                        case 2:
                            SuitClass.Suit3_Buy = true;
                            break;
                    }
                    SuitBuy = true;
                }
            }
            if (SuitBuy == true) {
                SuitMount = MountInt;
            }
        }
    }
    void BootsEquipMount(int MountInt,bool BootsBuy,int NeedPT)
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (BootsBuy == false)
            {
                if (ShopPoint >= NeedPT)
                {
                    ShopPoint -= NeedPT;
                    switch (MountInt)
                    {
                        case 0:
                            BootsClass.Boots1_Buy = true;
                            break;
                        case 1:
                            BootsClass.Boots2_Buy = true;
                            break;
                        case 2:
                            BootsClass.Boots3_Buy = true;
                            break;
                    }
                    BootsBuy = true;
                }
            }
            if (BootsBuy == true) {
                BootsMount = MountInt;
            }
        }
    }

    void EquipIconMove(){

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

        switch (SuitMount)
        {
            case 0:
                switch (SuitEquip)
                {
                    case 0:
                        EquipIcon[1].transform.position = new Vector3(-3.5f, -0.1f);
                        break;
                    case 1:
                        EquipIcon[1].transform.position = new Vector3(-6.0f, -0.1f);
                        break;
                    case 2:
                        EquipIcon[1].transform.position = new Vector3(-0.3f, -0.1f);
                        break;
                }
                break;
            case 1:
                switch (SuitEquip)
                {
                    case 0:
                        EquipIcon[1].transform.position = new Vector3(-0.3f, -0.1f);
                        break;
                    case 1:
                        EquipIcon[1].transform.position = new Vector3(-3.5f, -0.1f);
                        break;
                    case 2:
                        EquipIcon[1].transform.position = new Vector3(-6.0f, -0.1f);
                        break;
                }
                break;
            case 2:
                switch (SuitEquip)
                {
                    case 0:
                        EquipIcon[1].transform.position = new Vector3(-6.0f, -0.1f);
                        break;
                    case 1:
                        EquipIcon[1].transform.position = new Vector3(-0.3f, -0.1f);
                        break;
                    case 2:
                        EquipIcon[1].transform.position = new Vector3(-3.5f, -0.1f);
                        break;
                }
                break;
        }

        switch (BootsMount)
        {
            case 0:
                switch (BootsEquips)
                {
                    case 0:
                        EquipIcon[2].transform.position = new Vector3(-3.5f, -3.4f);
                        break;
                    case 1:
                        EquipIcon[2].transform.position = new Vector3(-6.0f, -3.4f);
                        break;
                    case 2:
                        EquipIcon[2].transform.position = new Vector3(-0.3f, -3.4f);
                        break;
                }
                break;
            case 1:
                switch (BootsEquips)
                {
                    case 0:
                        EquipIcon[2].transform.position = new Vector3(-0.3f, -3.4f);
                        break;
                    case 1:
                        EquipIcon[2].transform.position = new Vector3(-3.5f, -3.4f);
                        break;
                    case 2:
                        EquipIcon[2].transform.position = new Vector3(-6.0f, -3.4f);
                        break;
                }
                break;
            case 2:
                switch (BootsEquips)
                {
                    case 0:
                        EquipIcon[2].transform.position = new Vector3(-6.0f, -3.4f);
                        break;
                    case 1:
                        EquipIcon[2].transform.position = new Vector3(-0.3f, -3.4f);
                        break;
                    case 2:
                        EquipIcon[2].transform.position = new Vector3(-3.5f, -3.4f);
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
