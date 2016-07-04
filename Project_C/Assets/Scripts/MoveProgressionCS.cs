using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveProgressionCS : MonoBehaviour {

    public Slider slider;
    public float totalDistance;     // ボスまでの総移動距離
    private float moveDistance;     // 移動距離
    public GameObject moveReference;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveDistance = moveReference.GetComponent<MoveBGCS>().GetMoveDistance();
        slider.value = moveDistance / totalDistance;
    }

    public float GetMovePercent()
    {
        return moveDistance / totalDistance * 100;
    }
    public void SetMoveReference(GameObject obj) {
        moveReference = obj;
    }
}
