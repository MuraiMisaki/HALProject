using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TexManager : MonoBehaviour {

    public Sprite def;

    private GameObject a;
    private bool bflg;
    private bool bflg2;

	// Use this for initialization
	void Start () {
        bflg = false;
        bflg2 = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (bflg)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Image>().sprite == def)
                {
                    child.GetComponent<Image>().sprite = a.GetComponent<Image>().sprite;
                    break;
                }
            }

            foreach (Transform child in transform)
            {
                if (child.GetComponent<Image>().sprite == a.GetComponent<Image>().sprite)
                {
                    if (!bflg2)
                    {
                        bflg2 = true;
                    }
                    else
                    {
                        child.GetComponent<Image>().sprite = def;
                        break;
                    }
                }
            }

            bflg2 = false;
            bflg = false;
        }
	}

    public void GetTex(GameObject Tex)
    {
        a = Tex;
        bflg = true;
    }
    public void Setdef(GameObject tex_def)
    {
        tex_def.GetComponent<Image>().sprite = def;
    }
}
