using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour {
    private bool move;

    private Move moveflg;

    void Start()
    {
        move = false;
        moveflg = gameObject.transform.parent.GetComponent<Move>();
    }

    void Update()
    {


        if (this.transform.position.x < -12f && !move)
        {
            transform.position = new Vector3(17.5f, 1.5f, 0);
            move = true;
        }

        if (this.transform.position.x > 12f && !move)
        {
            transform.position = new Vector3(-17.5f, 1.5f, 0);
            move = true;
        }

        if (!moveflg.bmoveflg()) move = false;

    }



}