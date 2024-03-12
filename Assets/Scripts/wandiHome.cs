using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandiHome : MonoBehaviour
{
    public string carregarSistema;
    public float esperarPraEntrar;

    public int numberCena;
    public float esperarPraIniciar;
    
    public GameObject loadingTrapez;

    // Start is called before the first frame update....
    void Start()
    {
        loadingTrapez.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(processEntrySystem());
        }


    }

    
     public void iniciar(){
               StartCoroutine(processIniciar());
        }

        IEnumerator processIniciar(){
            loadingTrapez.SetActive(true);
            yield return new WaitForSeconds(esperarPraIniciar);
            Application.LoadLevel(numberCena);
        }

    IEnumerator processEntrySystem()
    {
        loadingTrapez.SetActive(true);
        yield return new WaitForSeconds(esperarPraEntrar);
        Application.LoadLevel(carregarSistema);

    }

        public void encerrarSoftware()
        {

            Application.Quit();

        }

       


}
