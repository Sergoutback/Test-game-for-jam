using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderForDialog : MonoBehaviour
{
    public Transform textForSlider;
    public float textSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Slider();
    }

    void Slider()
    {
        textSpeed = textSpeed * Time.deltaTime;
        transform.Translate(0f, 1000f, 0f * textSpeed);

    }
}
