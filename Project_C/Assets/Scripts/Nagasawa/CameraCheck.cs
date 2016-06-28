using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour {
    Vector3 spriteSize;
    private float spritex;
    private float spritex1;
    private bool bflg;

    private bool move;

    private Move moveflg;

    void Start()
    {
        move = false;
        moveflg = gameObject.transform.parent.GetComponent<Move>();
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        bflg = false;
    }

    void Update()
    {
        spritex = (transform.position + spriteSize / 2).x;
        spritex1 = (transform.position - spriteSize / 2).x;

        if (!move)
        {
            if (spritex < ScreenManager.Instance.screenRect.x) OnBecameInvisible();

            if (spritex1 > ScreenManager.Instance.screenRect.xMax)
            {

                bflg = true;
                OnBecameInvisible();
            }
        }
        else
        {
            if (!moveflg.bmoveflg()) move = false;
        
        }
    }

    void OnBecameInvisible()
    {

        move = true;

        if (bflg) {
            transform.position = new Vector3(-18.5f, 1.5f, 0);
            bflg = false;
        } else {
            transform.position = new Vector3(18.5f, 1.5f, 0);
        }

    }

}