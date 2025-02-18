using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Splines;
using UnityEngine.EventSystems;
using NUnit.Framework;
using System.Collections.Generic;

//[ExecuteAlways]
public class slider_script : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Slider slider;
    public Slider speed_slider;

    public GameObject image_container;
    public GameObject image_container_large;


    public List<GameObject> images = new List<GameObject>();
    public List<GameObject> images_large = new List<GameObject>();


    public float[] og_offset;
    public float[] og_offset_large;


    private bool slider_pressed = false;
    public float old_slider_value;

    private void Start()
    {



        foreach (Transform child in image_container.transform)
        {
            foreach (Transform child2 in child.transform)
            {
                images.Add(child2.gameObject);
            }
        }
        foreach (Transform child in image_container_large.transform)
        {
            foreach (Transform child2 in child.transform)
            {
                images_large.Add(child2.gameObject);
            }
        }

        
        
        
        
        //og_offset = new float[images.Length];

        //for (int i = 0; i < images.Length; i++)

        //{
        //og_offset[i] = images[i].GetComponent<SplineAnimate>().StartOffset;
        //}



    }





    public void OnPointerDown(PointerEventData eventData)
    {
        //no movement if slider is pressed in between
        //old_slider_value = slider.value;
        og_offset = new float[images.Count];
        og_offset_large = new float[images_large.Count];

        for (int i = 0; i < images.Count; i++)

        {
            og_offset[i] = images[i].GetComponent<SplineAnimate>().ElapsedTime;
        }
        for (int i = 0; i < images_large.Count; i++)

        {
            og_offset_large[i] = images_large[i].GetComponent<SplineAnimate>().ElapsedTime;
        }
        
        
        
        
        
        slider_pressed = true;
       

    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        //movement if slider is pressed in between
        old_slider_value = slider.value;
        Debug.Log("huh2");
        slider_pressed = false;
    }






    // Update is called once per frame
    void Update()
    {

        if (slider_pressed)
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].GetComponent<SplineAnimate>().Pause();
                images[i].GetComponent<SplineAnimate>().ElapsedTime = og_offset[i] + (slider.value - old_slider_value) * 35;
            }
            
            for (int i = 0; i < images_large.Count; i++)
            {
                images_large[i].GetComponent<SplineAnimate>().Pause();
                images_large[i].GetComponent<SplineAnimate>().ElapsedTime = og_offset_large[i] + (slider.value - old_slider_value) * 46;
            }
        }






        if (!slider_pressed)
        {
            for (int i = 0; i < images.Count; i++)

            {
                images[i].GetComponent<SplineAnimate>().Play();
                
            }
            for (int i = 0; i < images_large.Count; i++)

            {
                images_large[i].GetComponent<SplineAnimate>().Play();
                
            }
        }

       for (int i = 0; i < images.Count; i++)
            {
                images[i].GetComponent<SplineAnimate>().MaxSpeed = speed_slider.value * 2f;
            }

            for (int i = 0; i < images_large.Count; i++)
            {
                images_large[i].GetComponent<SplineAnimate>().MaxSpeed = speed_slider.value * 5f;
            }
        




    }
}
