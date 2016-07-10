using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // 初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        this.transform.localPosition -= new Vector3(0.5f, 0, 0);
       if (this.transform.localPosition.x < -586.0f) {
           this.transform.localPosition = new Vector3(580, 125, 0); 
       }
     
    }

}


