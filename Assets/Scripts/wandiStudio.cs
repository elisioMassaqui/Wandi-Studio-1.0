using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wandiStudio : MonoBehaviour
{
    //Modo linha
    public GameObject useTrail;
    public Toggle toggleTrail;

    //Trocar camera
    public SimpleCameraSwitcher simpleCameraSwitcher;

    //Mudanças na UI ou de canvas
    public GameObject canvasScena;
    public GameObject canvasMain;

    // Start is called before the first frame update
    void Start()
    {
        toggleTrail.isOn = false;
        canvasScena.SetActive(false);
        canvasMain.SetActive(true);
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


        if (Input.GetKeyUp(KeyCode.Space))
        {
            canvasScena.SetActive(true);
            canvasMain.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.Home))
        {
            canvasScena.SetActive(false);
            canvasMain.SetActive(true);
        }
    }

    public void FecharSistema(){
        Application.Quit();
    }
    
    public void carregarScene(int loadScene){
        Application.LoadLevel(loadScene);
    }

}
