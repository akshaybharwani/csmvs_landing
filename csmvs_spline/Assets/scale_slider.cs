using UnityEngine;
using UnityEngine.UI;

public class scale_slider : MonoBehaviour
{
    //[Range(1.0f, 5.0f)]
    public Slider scaleSlider;
    public Slider scaleSlider_ind;
    private float scaleSliderNumber;
    private float scaleSliderNumber_ind;


    //Slider scale control here!!!
    private float individual_Slider_Multiplier = 6f;
    private float global_Slider_Multiplier = 0.005f;


    void Update()
    {
        scaleSliderNumber_ind = scaleSlider_ind.value * individual_Slider_Multiplier;
        //Vector3 scale_ind = new Vector3(scaleSliderNumber_ind, scaleSliderNumber_ind, scaleSliderNumber_ind);
        //this.transform.localScale = scale_ind;

        scaleSliderNumber = scaleSlider.value * global_Slider_Multiplier;
        Vector3 scale = new Vector3(scaleSliderNumber * scaleSliderNumber_ind, scaleSliderNumber * scaleSliderNumber_ind, scaleSliderNumber * scaleSliderNumber_ind);
        this.transform.localScale = scale;
    }
}

