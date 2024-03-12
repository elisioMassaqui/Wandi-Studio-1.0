using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    public UnityEngine.UI.InputField portNameInput;
    public UnityEngine.UI.Text statusText;

    private SerialPort serialPort;

    void Start()
    {
        // Inicialize o SerialPort com as configurações necessárias
        serialPort = new SerialPort();

        // Configurar outras configurações do SerialPort, se necessário
         serialPort.BaudRate = 9600;
    }

    void Update()
    {
        // Se a porta estiver aberta, você pode ler dados do Arduino aqui
        if (serialPort.IsOpen)
        {
            // Ler dados do Arduino e fazer algo com eles
        }
    }

    public void OpenPort()
    {
        // Obter o nome da porta do campo de entrada
        string portName = portNameInput.text;

        // Tentar abrir a porta
        try
        {
            serialPort.PortName = portName;
            serialPort.Open();
            statusText.text = "Porta aberta: " + portName;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao abrir a porta: " + e.Message);
            statusText.text = "Erro ao abrir a porta";
        }
    }

    public void ClosePort()
    {
        // Fechar a porta se estiver aberta
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            statusText.text = "Porta fechada";
        }
    }
}
