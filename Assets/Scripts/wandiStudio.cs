using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wandiStudio : MonoBehaviour
{
    //Modo linha
    public GameObject useTrail;
    public Toggle toggleTrail;

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

    public void FecharSistema(){
        Application.Quit();
    }
    
    public void carregarScene(int loadScene){
        Application.LoadLevel(loadScene);
    }

}
