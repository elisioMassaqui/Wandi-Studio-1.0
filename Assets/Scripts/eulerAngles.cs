using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eulerAngles : MonoBehaviour
{
    public Transform baseY;
    public Transform armX;
    public Transform arm2Z;

    public float baseRate = 1;
    public float armRate = 1;
    public float arm2Rate = 1;

    public Slider sliderBase;
    public Slider sliderArm;
    public Slider sliderArm2;

    public float baseSliderValue = 0.0f;
    public float armSliderValue = 0.0f;
    public float armSliderValue2 = 0.0f;

    public float baseYRot = 0.0f;
    public float baseYMin = -45.0f;
    public float baseYMax = 45.0f;

    public float armXRot = 0.0f;
    public float armXMin = -45.0f;
    public float armXMax = 45.0f;

    public float arm2ZRot = 0.0f;
    public float arm2ZMin = -45f;
    public float arm2ZMax = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        sliderBase.minValue = -1;
        sliderArm.minValue = -1;
        sliderArm2.minValue = -1;

        sliderBase.maxValue = 1;
        sliderArm.maxValue = 1;
        sliderArm2.maxValue = 1;
    }

    // Update is called once per frame
   void Update()
{
    UpdateBaseRotation();
    UpdateArmXRotation();
    UpdateArm2ZRotation();
}

void UpdateBaseRotation()
{
    baseSliderValue = sliderBase.value;
    baseYRot += baseSliderValue * baseRate * Time.deltaTime;
    baseYRot = Mathf.Clamp(baseYRot, baseYMin, baseYMax);
    baseY.localEulerAngles = new Vector3(baseY.localEulerAngles.x, baseYRot, baseY.localEulerAngles.z);
}

void UpdateArmXRotation()
{
    armSliderValue = sliderArm.value;
    armXRot += armSliderValue * armRate * Time.deltaTime;
    armXRot = Mathf.Clamp(armXRot, armXMin, armXMax);
    armX.localEulerAngles = new Vector3(armXRot, armX.localEulerAngles.y, armX.localEulerAngles.z);
}

void UpdateArm2ZRotation()
{
    armSliderValue2 = sliderArm2.value;
    arm2ZRot += armSliderValue2 * arm2Rate * Time.deltaTime;
    arm2ZRot = Mathf.Clamp(arm2ZRot, arm2ZMin, arm2ZMax);
    arm2Z.localEulerAngles = new Vector3(arm2Z.localEulerAngles.x, arm2Z.localEulerAngles.y, arm2ZRot);
}
    public void resetSliders()
    {
        baseSliderValue = 0.0f;
        armSliderValue = 0.0f;
        armSliderValue2 = 0.0f;
        sliderBase.value = 0.0f;
        sliderArm.value = 0.0f;
        sliderArm2.value = 0.0f;
    }
}
