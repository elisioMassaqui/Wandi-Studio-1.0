using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wandiStudio : MonoBehaviour
{
    public GameObject useTrail;
    public Toggle toggleTrail;

    public SimpleCameraSwitcher simpleCameraSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        toggleTrail.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleTrail.isOn)
        {
            useTrail.SetActive(!false);
        }
        else if (!toggleTrail.isOn)
        {
            useTrail.SetActive(!true);
        }
    }

    public void carregarScene(int loadScene){
        Application.LoadLevel(loadScene);
    }

}
