using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position -= new Vector3(0.05f, 0, 0);

        if (this.transform.position.x < -28f) { this.transform.position = new Vector3(16f, 3f, 1f); }

    }

}
