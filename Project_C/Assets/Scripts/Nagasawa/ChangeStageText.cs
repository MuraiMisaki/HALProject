using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeStageText : MonoBehaviour {

    private GameObject Stage;

    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite sprite11;

    // Use this for initialization
    void Start()
    {
        Stage = GameObject.Find("1");
    }

    // Update is called once per frame
    void Update()
    {

        switch (Stage.name)
        {
            case "1":
                this.GetComponent<Image>().sprite = sprite0;    // ねずみ
                break;                                         
                                                              
            case "2":                                           
                this.GetComponent<Image>().sprite = sprite1;    // うし
                break;                                         
                                                                 
            case "3":                                           
                this.GetComponent<Image>().sprite = sprite2;    // とら
                break;                                         
                                                               
            case "4":                                          
                this.GetComponent<Image>().sprite = sprite3;    // うさぎ
                break;                                         
                                                               
            case "5":                                           
                this.GetComponent<Image>().sprite = sprite4;    // たつ
                break;                                         
                                                                
            case "6":                                          
                this.GetComponent<Image>().sprite = sprite5;    // へび
                break;                                          
                                                                 
            case "7":                                           
                this.GetComponent<Image>().sprite = sprite6;    // うま
                break;                                          
                                                               
            case "8":                                          
                this.GetComponent<Image>().sprite = sprite7;    // ひつじ
                break;                                          
                                                               
            case "9":                                          
                this.GetComponent<Image>().sprite = sprite8;    // さる
                break;                                       
                                                               
            case "10":                                         
                this.GetComponent<Image>().sprite = sprite9;    // とり
                break;                                        
                                                               
            case "11":                                         
                this.GetComponent<Image>().sprite = sprite10;   // いぬ
                break;                                        
                                                              
            case "12":                                         
                this.GetComponent<Image>().sprite = sprite11;   // いのしい
                break;

            default:
                break;
        }
    }

    public void GetStageData(GameObject Data)
    {
        Stage = Data;
    }

}