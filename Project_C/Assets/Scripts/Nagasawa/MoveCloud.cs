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
        foreach (Transform child in transform)
        {
            child.transform.position -= new Vector3(0.5f, 0, 0);
            if (child.transform.position.x < -150.0f) { child.transform.position = new Vector3(750, 238, 0); }
        }
    }

}


