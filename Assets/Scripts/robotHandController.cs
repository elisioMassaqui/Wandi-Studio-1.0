using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotHandController : MonoBehaviour
{
    public float baseRate = 1;
    public float armRate = 1;

    public Slider sliderBase;
    public Slider sliderArm;

    public float baseYMin = -45.0f;
    public float baseYMax = 45.0f;

    public float armXMin = -45.0F;
    public float armXMax = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        sliderBase.minValue = -1;
        sliderArm.minValue = 1;

        sliderBase.maxValue = 1;
        sliderArm.maxValue = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
