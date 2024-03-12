using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class wandiController : MonoBehaviour
{
    public bool rotacionar;

    [Header("Juntas Steps/s")]
    public Transform origemJ1; //Pegar o vector escalar do objecto.
    public float destinoJ1; //Inicializar o vector imaginário do objecto.
    public float velocidadeJ1; // Velocidade de rotação.

    public Transform origemJ2;
    public float destinoJ2;
    public float velocidadeJ2;

    [Header("Juntas Graus/s")]
    public Transform origemJ3;
    public float destinoJ3;
    public float velocidadeJ3;

    public Transform origemJ4;
    public float destinoJ4;
    public float velocidadeJ4;

    public Transform origemJ5;
    public float destinoJ5;
    public float velocidadeJ5;

    public Transform origemJ6;
    public float destinoJ6;
    public float velocidadeJ6;
    


    // Start is called before the first frame update......
    void Start()
    {
       
    }

    // Update is called once per frame.
    void Update()
    {
        //Limitar o valor da velocidade entre 0....e....1.
          Mathf.Clamp01(velocidadeJ1);
          Mathf.Clamp01(velocidadeJ2);
          Mathf.Clamp01(velocidadeJ3);
          Mathf.Clamp01(velocidadeJ4);
          Mathf.Clamp01(velocidadeJ5);
          Mathf.Clamp01(velocidadeJ6);


    
        //Se bool for permitivo, !false entâo rotacione;
        //A origem da junta, nesse caso o vector escalar vai receber o valor do destino da junta, nesse caso o vector imaginario com a respectiva "velocidade",  a + (a + b) * t;
        //Isso no método slerp (Liner Spherical Interpolation) da classe quaternion, e o vector imaginário será um euler da classe quaternion também.

          if(rotacionar)
          {
                //Juntas Steps/s
                origemJ1.localRotation = Quaternion.Slerp(origemJ1.localRotation, Quaternion.Euler(0, destinoJ1, 0), velocidadeJ1);
                origemJ2.localRotation = Quaternion.Slerp(origemJ2.localRotation, Quaternion.Euler(0, 0, destinoJ2), velocidadeJ2);
                //Juntas Graus/s
                origemJ3.localRotation = Quaternion.Slerp(origemJ3.localRotation, Quaternion.Euler(0, 0, destinoJ3), velocidadeJ3);
                origemJ4.localRotation = Quaternion.Slerp(origemJ4.localRotation, Quaternion.Euler(0, destinoJ4, 0), velocidadeJ4);
                origemJ5.localRotation = Quaternion.Slerp(origemJ5.localRotation, Quaternion.Euler(0, destinoJ5, 0), velocidadeJ5);
                //falta J6, mas é básico.
          }

    }

    //A cada clique no button vai incrementar ou decrementar no valor do destino da junta.

    //Buttons para Steps/s
    public void J1Max(){
        destinoJ1 += 5f;
    } 
    public void J1Min(){
        destinoJ1 -= 5f;
    }
    public void J2Max(){
        destinoJ2 += 5f;
    }
    public void J2Min(){
        destinoJ2 -= 5f;
    } 

    //Buttons para Graus/s
    public void J3Max(){
        destinoJ3 += 1f;
    }
    public void J3Min(){
        destinoJ3 -= 1f;
    }
    public void J4Max(){
        destinoJ4 += 1f;
    }
    public void J4Min(){
        destinoJ4 -= 1f;
    }
    public void J5Max(){
        destinoJ5 += 1f;
    }
    public void J5Min(){
        destinoJ5 -= 1f;
    }

}
