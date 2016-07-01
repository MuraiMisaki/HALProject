using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStatusCS : MonoBehaviour {

    private int status;
    public GameObject[] particle = new GameObject[2];
    public Image[] image = new Image[2];

	// Use this for initialization
	void Start () {
        status = image.Length;
	}
    void Awake() {

        status = image.Length;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void UpdateStatus(int i) {
        status = i;
        UpdateUI();
    }
    void UpdateUI() {
        particle[status].SetActive(true);
        // なくなった
        if (status <= 0) {
            for (int i = 0; i < image.Length; i++) {
                image[i].enabled = false;
            }
            return;
        }

        // 表示OFF
        for (int i = 0; i < image.Length; i++)
        {
            image[i].enabled = false;
        }

        image[status - 1].enabled = true;
    }

    public int GetStatus() {
        return status;
    }
}
