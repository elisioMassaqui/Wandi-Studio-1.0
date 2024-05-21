using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO.Ports;
using System;

public class wandiController : MonoBehaviour
{
    public bool rotacionar;
    public bool home;

    public bool receber;

    [Header("In Arduino")]
    public string message;

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

    [Header("Base Na Esteira")]
    public Transform baseEsteiraOrigem;
    public float baseDestino;
    public float baseVelocidade;
    public Vector3 basePosition = new Vector3(0.21f, 0.1021f, 67f);
    public float vectores;


    public SerialPort serialPort;
    /*
    [Header("Serial Unity-Arduino")]
     //Carte de amor, que será recebido do arduino, com certas informações, interprete cada informação do seu jeito e use ela como quiser.
    public string mensagem;
    public TextMeshProUGUI messageLove;  //Botão a ser pressionado
    */

    [Header("Pra Usuário Definir A Porta Ou Tipo De Arduino.")]
    public string portaArduino; // porta do arduino em string receba da selectedPort.
    public TextMeshProUGUI statusPort; // Texto de estado da porta.
    public Toggle conectionSerial; //
    public Image imageConnect; // Mudar a cor da imagem de vermelho pra verde pra conectar.
    public Image remoteImage; // 
    public GameObject progressConect; // Processar ao conectar a porta dentro de um IEnumerator
    //PortDrodown
    [Header("PortDrodown")]
    public TMP_Dropdown portDropdown; //Escolher, procurar e atualizar porta.
    public string selectedPort; //Envia para portaArduino
    public string[] ports;
    
    [Header("Angulos das Juntas Na UI")]
    public TextMeshProUGUI anguloJ1;  //Mostrar, o angulo da junta a ser movida, em tempo real na tela.
    public TextMeshProUGUI anguloJ2;
    public TextMeshProUGUI anguloJ3;
    public TextMeshProUGUI anguloJ4;
    public TextMeshProUGUI anguloJ5;

    [Header("Posição Sincronizada na UI")]
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

    [Header("Buttton e Slider Pra Velocidade na UI")]
    public Slider sliderVelocidadeJ1;
    public Slider sliderVelocidadeJ2;
    public Slider sliderVelocidadeJ3;
    public Slider sliderVelocidadeJ4;
    public Slider sliderVelocidadeJ5;

    [Header("Mostrar Na UI Velocidade Das Juntas")]
    public TextMeshProUGUI mostrarVelocidadeJ1UI;
    public TextMeshProUGUI mostrarVelocidadeJ2UI;
    public TextMeshProUGUI mostrarVelocidadeJ3UI;
    public TextMeshProUGUI mostrarVelocidadeJ4UI;
    public TextMeshProUGUI mostrarVelocidadeJ5UI;


    // Start is called before the first frame update......
    void Start()
    {
       
        // Inicialize o SerialPort com as configurações necessárias
        serialPort = new SerialPort();
        // Configurar outras configurações do SerialPort, se necessário.
        serialPort.BaudRate = 9600;

        //Nºao incicie o progresso de conection ao iniciar o app
        progressConect.SetActive(false);
        //Nºao inicializei o home
        rotacionar = false;
    }

    
      //Botão pra abrir conectar a porta
      public void OpenPorta(){
        try
        {
        //Recebe o nome da porta da variavel que vai receber do Input uma outra String.
            serialPort.PortName = portaArduino;
            serialPort.Open();
            //Mensagem quando a porta estiver aberta
            statusPort.text = "A sua porta: |" + portaArduino + "| Foi Aberta Com Sucesso!";
            StartCoroutine(remoteConected());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao abrir a porta: " + e.Message);
            statusPort.text = "Falha Ao Abrir A Porta: " + portaArduino;
        }

    }

    //Botão pra fechar
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

    //O que fazer enquanto conecta a porta.
    IEnumerator remoteConected(){
        
        //Inicie o progresso de conexºao
        progressConect.SetActive(true);

        //Passe alguns segundos
        yield return new WaitForSeconds(6f);
        
        //Trocar a cor dessa imagem na parte central inferior da tela, pra azul
        remoteImage.color = Color.blue;

        //Se estiver aberta
        if (serialPort.IsOpen)
        {
            //Manda pra o Wandi Robot inicializar o HOME
            serialPort.Write("X");
            rotacionar = !false;
            Debug.Log("X");

            progressConect.SetActive(false);
        }
        
    }

    // Update is called once per frame.
    void Update()
    {
        //Limitar o valor da velocidade entre 0....e....1.
          sliderVelocidadeJ1.value = Mathf.Clamp(sliderVelocidadeJ1.value, 0.00f, 0.09f);
          sliderVelocidadeJ2.value = Mathf.Clamp(sliderVelocidadeJ2.value, 0.00f, 0.09f);
          sliderVelocidadeJ3.value = Mathf.Clamp(sliderVelocidadeJ3.value, 0.00f, 0.09f);
          sliderVelocidadeJ4.value = Mathf.Clamp(sliderVelocidadeJ4.value, 0.00f, 0.09f);
          sliderVelocidadeJ5.value = Mathf.Clamp(sliderVelocidadeJ5.value, 0.00f, 0.09f);
          baseVelocidade = Mathf.Clamp(baseVelocidade, 0.00f, 0.09f);
        
        //A float da velocidade vai receber o valor do slider
          velocidadeJ1 = sliderVelocidadeJ1.value;
          velocidadeJ2 = sliderVelocidadeJ2.value;
          velocidadeJ3 = sliderVelocidadeJ3.value;
          velocidadeJ4 = sliderVelocidadeJ4.value;
          velocidadeJ5 = sliderVelocidadeJ5.value;

         // Mostrar a velociade ao lado controlador slider de velocidade
          mostrarVelocidadeJ1UI.text = velocidadeJ1.ToString("F2");
          mostrarVelocidadeJ2UI.text = velocidadeJ2.ToString("F2");
          mostrarVelocidadeJ3UI.text = velocidadeJ3.ToString("F2");
          mostrarVelocidadeJ4UI.text = velocidadeJ4.ToString("F2");
          mostrarVelocidadeJ5UI.text = velocidadeJ5.ToString("F2");
          


         //O texto do angulo J da UI vai receber a string concatenada com o progresso do seu angulo.
        anguloJ1.text = "Angulo J1.Y: " + origemJ1.localRotation.y.ToString("F2");
        anguloJ2.text = "Angulo J2.Z: " + origemJ2.localRotation.z.ToString("F2");
        anguloJ3.text = "Angulo J3.Z: " + origemJ3.localRotation.z.ToString("F2");
        anguloJ4.text = "Angulo J4.Y: " + origemJ4.localRotation.z.ToString("F2");
        anguloJ5.text = "Angulo J5.Y: " + origemJ5.localRotation.y.ToString("F2");

        //As caixas de textos na ui no lado esquerdo dos buttons vão receber valor unitário aplicados nos vectores imaginarios.
        unitJ1.text = destinoJ1.ToString();
        unitJ2.text = destinoJ2.ToString();
        unitJ3.text = destinoJ3.ToString();
        unitJ4.text = destinoJ4.ToString();
        unitJ5.text = destinoJ5.ToString();

        //Se a porta estiver aberta ou não, muda de cor.
        if(serialPort.IsOpen){
            imageConnect.color = Color.green;
        }
        else if(!serialPort.IsOpen){
            imageConnect.color = Color.red;
            rotacionar = !true;
            home = !true;
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
            origemJ4.localRotation = Quaternion.Slerp(origemJ4.localRotation, Quaternion.Euler(0, 0, destinoJ4), velocidadeJ4);
            origemJ5.localRotation = Quaternion.Slerp(origemJ5.localRotation, Quaternion.Euler(0, destinoJ5, 0), velocidadeJ5);
            //falta J6, mas é básico.

            //Para base na esteira
            baseEsteiraOrigem.localPosition = Vector3.Lerp(baseEsteiraOrigem.localPosition, basePosition, baseVelocidade);
            vectores = basePosition.y - basePosition.z;

            // Apos conecetar a porta vai sincronizar a posiçao com WR e os dados irao pra UI
            SincronizadaJ1UI.text = "Posição J1.Y: " + origemJ1.localRotation.ToString("F1");
            SincronizadaJ2UI.text = "Posição J2.Z: " + origemJ2.localRotation.ToString("F1");
            SincronizadaJ3UI.text = "Posição J3.Z: " + origemJ3.localRotation.ToString("F1");
            SincronizadaJ4UI.text = "Posição J4.Y: " + origemJ4.localRotation.ToString("F1");
            SincronizadaJ5UI.text = "Posição3 J5.Y: " + origemJ5.localRotation.ToString("F1");
          }

        //Steps e Graus.
        destinoJ1 = Mathf.Clamp(destinoJ1, -83f, 82f);   //Suposto valor inicial: 2
        destinoJ2 = Mathf.Clamp(destinoJ2, -50f, 10f);   //Suposto valor inicial: 10

        destinoJ3 = Mathf.Clamp(destinoJ3, -80f, -60f);  //Suposto valor inicial: -77
        destinoJ4 = Mathf.Clamp(destinoJ4,-64f, -46f);   //Suposto valor inicial: -54
        destinoJ5 = Mathf.Clamp(destinoJ5, -87f, 90f);   //Suposto valor inicial: 2

        //Receber carta de amor de arduino.
        if (serialPort.IsOpen)
        {
            message = serialPort.ReadLine();
            Debug.Log("Recebido: " + message);

            if (message.Contains("otao01Pressionado"))
            {
                destinoJ1 += 5f;
                Debug.Log("Botão 01 Pressionado");
            }
            else if (message.Contains("botao02Pressionado"))
            {
                destinoJ1 -= 5f;
                Debug.Log("Botão 02 Pressionado");
            }
            else
            {
                message = "Love";
            }

        }
          
    }

    //A cada clique no button vai incrementar ou decrementar no valor do destino da junta.

    //Buttons para Steps/s
    public void J1Max(){
        destinoJ1 += 5f;
        serialPort.Write("A");
    } 
    public void J1Min(){
        destinoJ1 -= 5f;
        serialPort.Write("B");
    }
    public void J2Max(){
        destinoJ2 += 5f;
        serialPort.Write("C");
    }
    public void J2Min(){
        destinoJ2 -= 5f;
        serialPort.Write("D");
    } 

    //Buttons para Graus/s
    public void J3Max(){
        destinoJ3 += 1f;
        serialPort.Write("E");
    }
    public void J3Min(){
        destinoJ3 -= 1f;
        serialPort.Write("F");
    }
    public void J4Max(){
        destinoJ4 += 1f;
        serialPort.Write("G");
    }
    public void J4Min(){
        destinoJ4 -= 1f;
        serialPort.Write("H");
    }
    public void J5Max(){
        destinoJ5 += 1f;
        serialPort.Write("I");
    }
    public void J5Min(){
        destinoJ5 -= 1f;
        serialPort.Write("J");
    }

    public void J6Max(){
        destinoJ5 += 1f;
        serialPort.Write("K");
    }
    public void J6Min(){
        destinoJ5 -= 1f;
        serialPort.Write("L");
    }


        // Atualiza a lista de portas e o dropdown
    public void AtualizarPortas()
    {
        // Obter a lista de portas disponíveis
        ports = SerialPort.GetPortNames();

        // Limpar as opções existentes no dropdown
        portDropdown.ClearOptions();
        // Adicionar as portas detectadas como opções no dropdown
        portDropdown.AddOptions(new List<string>(ports));
        
        // Adicionar um listener para o evento de seleção do dropdown
        portDropdown.onValueChanged.AddListener(OnPortDropdownValueChanged);

    }

    // Manipula a mudança na seleção do dropdown
    public void OnPortDropdownValueChanged(int index)
    {
        //Percorre o index atual selecioonado
        selectedPort = portDropdown.options[index].text;
        Debug.Log("Porta selecionada: " + selectedPort);
        //String da Porta Arduino do metodo open porta recebe porta selecionada do dropdown
        portaArduino = selectedPort;

        statusPort.text = selectedPort;

        // Você pode fazer o que quiser com a porta selecionada, como iniciar a comunicação serial, etc.
    }
    public void portAtual(int index){
        //Percorre o index atual selecioonado
        selectedPort = portDropdown.options[index].text;
        Debug.Log("Porta selecionada: " + selectedPort);
        //String da Porta Arduino do metodo open porta recebe porta selecionada do dropdown
        portaArduino = selectedPort;

        statusPort.text = selectedPort;
    }

    //Velocidade do slider pode se incrementar e decrementar aqui e pra cada funçºao pode enviar algum char no Wandi Robot pra mudar a velocidade lá também, ao mesmo tempooo
    public void velocidadeJ1Min(){
        sliderVelocidadeJ1.value -= 0.01f;
        serialPort.Write("0");
    }
    public void VelocidadeJ1Max(){
        sliderVelocidadeJ1.value += 0.01f;
        serialPort.Write("1");
    }
    public void velocidadeJ2Min(){
        sliderVelocidadeJ2.value -= 0.01f;
        serialPort.Write("2");
    }
    public void VelocidadeJ2Max(){
        sliderVelocidadeJ2.value += 0.01f;
        serialPort.Write("3");
    }
    public void velocidadeJ3Min(){
        sliderVelocidadeJ3.value -= 0.01f;
        serialPort.Write("4");
    }
    public void VelocidadeJ3Max(){
        sliderVelocidadeJ3.value += 0.01f;
        serialPort.Write("5");
    }
    public void velocidadeJ4Min(){
        sliderVelocidadeJ4.value -= 0.01f;
        serialPort.Write("6");
    }
    public void VelocidadeJ4Max(){
        sliderVelocidadeJ4.value += 0.01f;
        serialPort.Write("7");
    }
    public void velocidadeJ5Min(){
        sliderVelocidadeJ5.value -= 0.01f;
        serialPort.Write("8");
    }
    public void VelocidadeJ5Max(){
        sliderVelocidadeJ5.value += 0.01f;
        serialPort.Write("9");
    }

}
