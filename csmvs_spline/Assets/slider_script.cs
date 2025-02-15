using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Splines;

//[ExecuteAlways]
public class slider_script : MonoBehaviour
{

    public Slider slider;
    public GameObject[] images;
    public float[] og_offset;

    private void Start()
    {
        og_offset = new float[images.Length];

        for (int i = 0; i < images.Length; i++)

        {
            og_offset[i] = images[i].GetComponent<SplineAnimate>().StartOffset;
        }



    }


    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < images.Length; i++)

        {

            images[i].GetComponent<SplineAnimate>().StartOffset = og_offset[i] + slider.value;
            //img.GetComponent<SplineAnimate>().NormalizedTime = slider.value; // WORKS BUT BAD
            //img.GetComponent<SplineAnimate>().StartOffset = slider.value;
        }


    }
}
