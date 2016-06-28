using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

    private float speed = 2;
    private int spriteCount = 3;
    Vector3 spriteSize;
    private float spritex;

    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    void Update()
    {
       transform.position += Vector3.left * speed * Time.deltaTime;

       spritex = (transform.position + spriteSize / 2).x ;

       if (spritex < ScreenManager.Instance.screenRect.x) OnBecameInvisible();

    }

    void OnBecameInvisible()
    {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position += Vector3.right * width * spriteCount;
    }
}
