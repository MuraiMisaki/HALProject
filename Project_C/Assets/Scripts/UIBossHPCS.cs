using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBossHPCS : MonoBehaviour
{

    public Slider chldSlider;
    public float extendSpeed;
    public float maxWidth;
    public bool isExtend;
    private Vector2 size;
    private RectTransform rect;
    // Use this for initialization

    void Start()
    {
        isExtend = true;
        rect = chldSlider.GetComponent<RectTransform>();
        size = rect.sizeDelta;
        size.x = 0.0f;
        rect.sizeDelta = size;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExtend)
            return;

        if (rect.sizeDelta.x >= maxWidth)
        {
            isExtend = false;
            size.x = maxWidth;
            rect.sizeDelta = size;
            return;
        }
        size.x += extendSpeed * Time.deltaTime;
        rect.sizeDelta = size;
    }
    public void ChangeValue(float value)
    {
        chldSlider.value = value;
    }

}
