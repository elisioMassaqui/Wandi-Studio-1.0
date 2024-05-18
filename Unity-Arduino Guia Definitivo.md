# Essa é a minha configuração da comunicação do software com arduino

## Primeiro configure a Unity pra comunicação IO.Portas

1 - Adicione a biblioteca na sua classe: ***using System.IO.Ports;***

2 - Entre Build Settings e troque ***.NET Standard pelo .NET Framework***

Está aqui o script da unity:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600); // Substitua "COM3" pela porta correta do seu Arduino

    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string message = serialPort.ReadLine();
                Debug.Log("Recebido: " + message);
                receberDados(message);
            }
            catch (System.Exception)
            {
                // Ignora timeouts
            }
        }
    }

    void receberDados(string message)
    {
        // Aqui você pode processar mensagens recebidas do Arduino e tomar ações na Unity
        if (message == "botao01Pressionado")
        {
            Debug.Log("Botão 01 Pressionado");
            // Ações quando o botão 01 é pressionado
        }
        else if (message == "botao02Pressionado")
        {
            Debug.Log("Botão 02 Pressionado");
            // Ações quando o botão 02 é pressionado
        }
        else if (message == "botoesNaoPressionados")
        {
            Debug.Log("Nenhum botão pressionado");
            // Ações quando nenhum botão é pressionado
        }
    }

    public void SendCommandToArduino(char command)
    {
        if (serialPort.IsOpen)
        {
            serialPort.Write(command.ToString());
            Debug.Log("Enviado: " + command);
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}

```

## Agora configure a sua placa arduino juntamente com protoboard (Componentes físicos)

1 - Prepare apenas uma LED.

2 - Prepare dois botões ou apenas 1.

3 - Agora faça a ligação com os ***fios*** (em qualquer lugar da ***protoboard***, onde você preferir), no caso do resistor acredito que não é necessário explicar, pra quem tem uma mínima expertise com isso, conecte:

- LED = Pin 13 (GND)
- Resistor
- Botão 1 = Pin 3 (GND)
- Botão 2 = Pin 8 (GND)

Não esquça que ***TR e RX*** na placa serve pra monitorar a entrada e saída de dados.

## Conecte o arduino com via cabo ao computador

Está aqui o script da configuração da placa arduino:

```c
int led = 13;
int x = 0;

int button = 3;
int sinal_button = 0;

int button1 = 8;
int sinal_button1 = 0;

char comando;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600); // Inicia a comunicação serial

  pinMode(led, OUTPUT);
  pinMode(button, INPUT_PULLUP);

  pinMode(button1, INPUT_PULLUP);

}

void loop() {

  sinal_button = digitalRead(button);
  sinal_button1 = digitalRead(button1);

  if (sinal_button == LOW && sinal_button1 == HIGH) {
    Serial.println("botao01Pressionado");
    digitalWrite(led, HIGH);
    delay(5);
    digitalWrite(led, LOW);
  }

  else if (sinal_button1 == LOW && sinal_button == HIGH) {
    Serial.println("botao02Pressionado");
    digitalWrite(led, HIGH);
    delay(5);
    digitalWrite(led, LOW);
  }
  /* ca esta o conflito com meus metodos piscar led poh
  else {
    digitalWrite(led, LOW);
    //Muito importante pra não enviar as strings anteriores continuamente, e o programa poder rodar independentemente, oque evita o programa não colar no inicio a espera do input pra receber a string que quer nesse caso distraimo ele com outra garota, pra não pensar muito kkkk
    Serial.println("botoesNaoPressionados");
  }
  */
  
  // put your main code here, to run repeatedly:
    if (Serial.available() > 0) {
    comando = Serial.read();  // Lê o comando da porta serial
    
    // Verifica o comando recebido e executa a ação correspondente
    switch (comando) {
      case 'A':
      piscarLedA();
      break;
      case 'B':
      piscarLedB();
      break;
      case 'C':
      case 'D':
      case 'E':
      case 'F':
      case 'G':
      case 'H':
      case 'I':
      case 'J':
      case 'K':
      case 'L': 
      piscarLedCtoL();
      break;
    }
  }
}
  
  void piscarLedA() {
  digitalWrite(led, HIGH);  // Liga o LED
  delay(10);
  digitalWrite(led, LOW);   // Desliga o LED
  delay(3);
}

void piscarLedB() {
  digitalWrite(led, HIGH);  // Liga o LED
  delay(16);
  digitalWrite(led, LOW);   // Desliga o LED
  delay(8);
}


void piscarLedCtoL() {
  digitalWrite(led, HIGH);  // Liga o LED
  delay(8);
  digitalWrite(led, LOW);   // Desliga o LED
  delay(16);
}

```

Sinta-se a vontade pra contribuir...
