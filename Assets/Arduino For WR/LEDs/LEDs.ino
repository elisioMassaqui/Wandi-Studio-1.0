const int ledPin = 13; // Pino ao qual o LED está conectado
bool isOn = false; // Variável para rastrear o estado ligado/desligado

void setup() {
  Serial.begin(9600); // Inicia a comunicação serial
  pinMode(ledPin, OUTPUT); // Configura o pino do LED como saída
}

void loop() {
  // Alterna o estado ligado/desligado a cada segundo
  isOn = !isOn;

  // Atualiza o estado do LED
  digitalWrite(ledPin, isOn ? HIGH : LOW);

  // Envia o estado do LED pela porta serial
  Serial.println(isOn ? "Ligado" : "Desligado");

  delay(10); // Atraso de 1 segundo
}
