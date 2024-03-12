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


    public SerialPort serialPort;
    /*
    [Header("Serial Unity-Arduino")]
     //Carte de amor, que será recebido do arduino, com certas informações, interprete cada informação do seu jeito e use ela como quiser.
    public string mensagem;
    public TextMeshProUGUI messageLove;  //Botão a ser pressionado
    */

    [Header("Pra Usuário Definir A Porta Ou Tipo De Arduino.")]
    public string portaArduino; // porta do arduino em string.
    public TextMeshProUGUI statusPort; // Texto de estado da porta.
    public Toggle conectionSerial; //
    public Image imageConnect; // Mudar a cor da imagem de vermelho pra verde pra conectar.
    public Image remoteImage; // 
    public GameObject progressConect; // Processar ao conectar a porta dentro de um IEnumerator
    
    [Header("Angulos das Juntas Na UI")]
    public TextMeshProUGUI anguloJ1;  //Mostrar, o angulo da junta a ser movida, em tempo real na tela.
    public TextMeshProUGUI anguloJ2;
    public TextMeshProUGUI anguloJ3;
    public TextMeshProUGUI anguloJ4;
    public TextMeshProUGUI anguloJ5;

    [Header("Posição Sincronizada")]
    public TextMeshProUGUI SincronizadaJ1UI;
    public TextMeshProUGUI SincronizadaJ2UI;
    public TextMeshProUGUI SincronizadaJ3UI;
    public TextMeshProUGUI SincronizadaJ4UI;
    public TextMeshProUGUI SincronizadaJ5UI;

    [Header("Valor Unitário das Juntas Na UI")]
    public TextMeshProUGUI unitJ1;  //Mostrar, o valor a ser ++ ou -- dos botoes
    public TextMeshProUGUI unitJ2;
    public TextMeshProUGUI unitJ3;
    public TextMeshProUGUI unitJ4;
    public TextMeshProUGUI unitJ5;
    


    // Start is called before the first frame update......
    void Start()
    {
       
        // Inicialize o SerialPort com as configurações necessárias
        serialPort = new SerialPort();
        // Configurar outras configurações do SerialPort, se necessário.
        serialPort.BaudRate = 9600;

        progressConect.SetActive(false);
    }


      public void OpenPorta(){
         //A varaivel que vai dar a porta pra seriaPort está recebendo aqui o input do usuario no dropdown.
        portaArduino = portNameFromArduino.text;
        try
        {
        //Recebe o nome da porta da variavel que vai receber do Input.
            serialPort.PortName = portaArduino;
            serialPort.Open();
            statusPort.text = "A sua porta: |" + portaArduino + "| Foi Aberta Com Sucesso!";
            StartCoroutine(remoteConected());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao abrir a porta: " + e.Message);
            statusPort.text = "Falha Ao Abrir A Porta: " + portaArduino;
        }

    }


    public void ClosePort()
    {
        // Fechar a porta se estiver aberta
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            statusPort.text = "Porta fechada!!!";
            progressConect.SetActive(false);
            
        }
    }

    IEnumerator remoteConected(){
        
        progressConect.SetActive(true);

        yield return new WaitForSeconds(6f);
        painelAutoControle.SetActive(false);
        painelControleButtons.SetActive(!true);
        painelControleSlider.SetActive(!true);

        remotePainel.SetActive(!true);
        remoteImage.color = Color.blue;

        sliderMode.interactable = !true;
        buttonMode.interactable = true;

        if (serialPort.IsOpen)
        {
            progressConect.SetActive(false);
        }
        
    }

        public void iniciarSistemaHome (){
        if(serialPort.IsOpen){
            serialPort.Write("X");
            Debug.Log("X");

            // Sincronizar a posiçao com WR
            RotationJ2Z = 10f;
            RotationJ3Z = 278f;
            RotationJ4Z = -48f;

            // Apos conecetar a porta vai sincronizar a posiçao com WR e os dados irao pra UI
            SincronizadaJ1UI.text = "Posição J1.Y: " + RotationJ1Y.ToString("F1");
            SincronizadaJ2UI.text = "Posição J2.Z: " + RotationJ2Z.ToString("F1");
            SincronizadaJ3UI.text = "Posição J3.Z: " + RotationJ3Z.ToString("F1");
            SincronizadaJ4UI.text = "Posição J4.Y: " + RotationJ4Y.ToString("F1");
            SincronizadaJ5UI.text = "Posição J5.Y: " + RotationJ5Y.ToString("F1");
        }
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

         //o texto do angulo J da UI vai receber a string concatenada com o progresso do seu angulo.
        anguloJ1.text = "Angulo J1.Y: " + RotationJ1Y.ToString("F2");
        anguloJ2.text = "Angulo J2.Z: " + RotationJ2Z.ToString("F2");
        anguloJ3.text = "Angulo J3.Z: " + RotationJ3Z.ToString("F2");
        anguloJ4.text = "Angulo J4.Y: " + RotationJ4Y.ToString("F2");
        anguloJ5.text = "Angulo J5.Y: " + RotationJ5Z.ToString("F2");

        unitJ1.text = RotationJ1Y.ToString("F2");
        unitJ2.text = RotationJ2Z.ToString("F2");
        unitJ3.text = RotationJ3Z.ToString("F2");
        unitJ4.text = RotationJ4Y.ToString("F2");
        unitJ5.text = RotationJ5Z.ToString("F2");

        //Se a porta estiver aberta ou não, muda de cor.
        if(serialPort.IsOpen){
            imageConnect.color = Color.green;
        }
        else if(!serialPort.IsOpen){
            imageConnect.color = Color.red;
        }


    
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
