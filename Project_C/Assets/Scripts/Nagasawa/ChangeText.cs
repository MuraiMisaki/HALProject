using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    private GameObject Charactar;

	// Use this for initialization
	void Start () {
        Charactar = GameObject.Find("0");

    }

    // Update is called once per frame
    void Update () {

        switch (Charactar.name) {
            case "0":
                this.GetComponent<Text>().text = "猫：アタッカー";
                break;

            case "1":
                this.GetComponent<Text>().text = "鼠：トリッキー";
                break;

            case "2":
                this.GetComponent<Text>().text = "牛：ディフェンス";
                break;

            case "3":
                this.GetComponent<Text>().text = "虎：アタッカー";
                break;

            case "4":
                this.GetComponent<Text>().text = "兎：回復";
                break;

            case "5":
                this.GetComponent<Text>().text = "龍：アタッカー";
                break;

            case "6":
                this.GetComponent<Text>().text = "蛇：トリッキー";
                break;

            case "7":
                this.GetComponent<Text>().text = "馬：ディフェンス";
                break;

            case "8":
                this.GetComponent<Text>().text = "羊：回復";
                break;

            case "9":
                this.GetComponent<Text>().text = "猿：トリッキー";
                break;

            case "10":
                this.GetComponent<Text>().text = "鳥：アタッカー";
                break;

            case "11":
                this.GetComponent<Text>().text = "犬：ディフェンス";
                break;

            case "12":
                this.GetComponent<Text>().text = "猪：アタッカー";
                break;

            default:
                break;
        }
	}

    public void GetCharacterData(GameObject Data) {
        Charactar = Data;
    }

}
