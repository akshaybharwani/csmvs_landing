using UnityEngine;
using UnityEngine.UI;

public class scale_slider : MonoBehaviour
{
    public Slider scaleSlider;
    private float scaleSliderNumber;

    
    void Update()
    {
        scaleSliderNumber = scaleSlider.value * 0.0045f;
        Vector3 scale = new Vector3(scaleSliderNumber, scaleSliderNumber, scaleSliderNumber);
        this.transform.localScale = scale;
    }
}

