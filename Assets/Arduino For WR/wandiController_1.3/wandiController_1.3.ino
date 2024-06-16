int led = 13;
int x = 0;

int button = 3;
int sinal_button = 0;

int button1 = 8;
int sinal_button1 = 0;

char comando;

char love;

char printLove;

int contador;


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
    delay(3);
    digitalWrite(led, LOW);
    Serial.println("Nothing01");
  }
  else if (sinal_button1 == LOW && sinal_button == HIGH) {
    Serial.println("botao02Pressionado");
    digitalWrite(led, HIGH);
    delay(3);
    digitalWrite(led, LOW);
    Serial.println("Nothing02");

  }

  love = Serial.read();

  if (love == 'A') {
    contador =  contador + 1;

    Serial.println(contador);

    delay(200);
  }
  else if (love == 'B') {
  contador =  contador - 1;

    Serial.println(contador);

    delay(200);
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
