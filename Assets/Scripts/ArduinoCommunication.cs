using UnityEngine;
using System.IO.Ports;

public class ArduinoCommunication : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600); // Substitua "COM3" pelo nome da porta do seu Arduino


    //Cada junta com suas respectivas configurações, pegar o objecto na cena,nesse caso o obj que queremos que seja uma J, velocidade do objecto, direção e limites de rotação.

    //Obj baseRotatória com suas respectivas configurações.
    public GameObject base01;
    public float baseSpeed01 = 20.7f;
    public Vector3 rotateBase01;

    //J2 com suas respectivas config.
    public GameObject J2;
    public float speedJ2 = 15.4f;
    public Vector3 rotateJ2;
    public Vector3 rotateJ2Positive;
    public Vector3 rotateJ2Negative;

    //J3 com suas respectivas config.
    public GameObject J3;
    public float speedJ3 = 15.7f;
    public Vector3 rotateJ3Positive;
    public Vector3 rotateJ3Negative;

    public int moverJ3Positive = 1;
    public int moverJ3Negative = -1;

    // Start is called before the first frame update
    void Start()
    {
        //Abrir a porta e conectar com Arduino.
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        //Se a porta estiver aberta e conectada com Arduino.
        if (serialPort.IsOpen)
        {
            try
            {
                //faça leitura da string que o Arduino escreve e envia pra nós.
                
                
                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    serialPort.Write("L");
                    base01.transform.Rotate(rotateBase01);

                }
                else if (Input.GetKey(KeyCode.RightArrow))
                { 
                    serialPort.Write("R");
                    base01.transform.Rotate(-rotateBase01);
                }

            

            }

            //Pra monitorar ou tratamento de erros na comunicação serial entre Unity e Arduino.
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }

        }

        rotateBase01 = new Vector3(0, 1, 0) * baseSpeed01 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            base01.transform.Rotate(rotateBase01);
        }


        rotateJ2Positive = new Vector3(0,0, 1) * speedJ2 * Time.deltaTime;
        rotateJ2Negative = new Vector3(0, 0, -1) * speedJ2 * Time.deltaTime;
        if(Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.LeftArrow))
        {
            J2.transform.Rotate(rotateJ2Positive);
        }
        if (Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.RightArrow))
        {
            J2.transform.Rotate(rotateJ2Negative);
        }



        rotateJ3Positive = new Vector3(0, 0, moverJ3Positive) * speedJ3 * Time.deltaTime;
        rotateJ3Negative = new Vector3(0, 0, moverJ3Negative) * speedJ3 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.LeftArrow))
        {
            J3.transform.Rotate(rotateJ3Positive);
        }
        if (Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.RightArrow))
        {
            J3.transform.Rotate(rotateJ3Negative);
        }


        //Se o software estiver fechando.
        void OnApplicationQuit()
        {
            //CVerifica se a porta e a comunicação com Arduino está em curso ainda.
            if (serialPort.IsOpen)
            {
                //e fecha tudo kkkk
                serialPort.Close();
            }
        }

    }

}
