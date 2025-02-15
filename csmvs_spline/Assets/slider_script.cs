using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Splines;
using UnityEngine.EventSystems;

//[ExecuteAlways]
public class slider_script : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Slider slider;
    public GameObject[] images;
    public float[] og_offset;
    private bool slider_pressed = false;
    public float old_slider_value;

    private void Start()
    {
        //og_offset = new float[images.Length];

        //for (int i = 0; i < images.Length; i++)

        //{
        //og_offset[i] = images[i].GetComponent<SplineAnimate>().StartOffset;
        //}



    }


    public void OnPointerDown(PointerEventData eventData)
    {
        old_slider_value = slider.value;
        og_offset = new float[images.Length];

        for (int i = 0; i < images.Length; i++)

        {
        og_offset[i] = images[i].GetComponent<SplineAnimate>().ElapsedTime;
        }
        slider_pressed = true;
        Debug.Log("huh");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("huh2");
        slider_pressed = false;
    }






    // Update is called once per frame
    void Update()
    {


        Debug.Log(images[0].GetComponent<SplineAnimate>().ElapsedTime);
        for (int i = 0; i < images.Length; i++)

        {

           
            //img.GetComponent<SplineAnimate>().NormalizedTime = slider.value; // WORKS BUT BAD
            //img.GetComponent<SplineAnimate>().StartOffset = slider.value;
        }


        //comment out for showcase
        if (slider_pressed)
        {
            //Debug.Log("Slider pressed");
            for (int i = 0; i < images.Length; i++)

            {
                images[i].GetComponent<SplineAnimate>().Pause();
                float etTemp = images[i].GetComponent<SplineAnimate>().ElapsedTime;
                images[i].GetComponent<SplineAnimate>().ElapsedTime = og_offset[i] + (slider.value - old_slider_value) * 30;
            }
        }
        
        if (!slider_pressed)
        {
            for (int i = 0; i < images.Length; i++)

            {
                images[i].GetComponent<SplineAnimate>().Play();

            }
        }

       


    }
}
