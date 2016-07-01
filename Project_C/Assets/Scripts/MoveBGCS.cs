using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveBGCS : MonoBehaviour {

    public GameObject[] BG = new GameObject[3];
    public Slider slider;
    public float totalDistance;
    private float distance; 
    public float interval;
    public float speed;
    private float width;

	// Use this for initialization
	void Start () {
        distance = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        float moveX = transform.position.x - Time.deltaTime * speed;
        distance += Time.deltaTime * speed;
        if (moveX < -interval) {
            moveX += interval;
        }
        transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        slider.value = distance / totalDistance;

    }
}
