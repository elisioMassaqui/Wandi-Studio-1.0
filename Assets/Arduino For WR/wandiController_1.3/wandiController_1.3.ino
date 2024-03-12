int led = 13;
int x = 0;

int button = 3;
int sinal_button = 0;

int button1 = 8;
int sinal_button1 = 0;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600); // Inicia a comunicação serial

  pinMode(led, OUTPUT);
  pinMode(button, INPUT_PULLUP);

  pinMode(button1, INPUT_PULLUP);

}

void loop() {
  // put your main code here, to run repeatedly:
    if (Serial.available() > 0) {
    char comando = Serial.read();  // Lê o comando da porta serial

    // Verifica o comando recebido e executa a ação correspondente
    switch (comando) {
      case 'A':
        piscarLedA();
        break;
      case 'B':
      piscarLedB();
      break;
        // Adicione mais casos para outros comandos, se necessário
    }
  }
}

  void piscarLedA() {
  digitalWrite(led, HIGH);  // Liga o LED
  delay(5);
  digitalWrite(led, LOW);   // Desliga o LED
   delay(10);
}

void piscarLedB() {
  digitalWrite(led, HIGH);  // Liga o LED
  delay(8);
  digitalWrite(led, LOW);   // Desliga o LED
  delay(16);
}
