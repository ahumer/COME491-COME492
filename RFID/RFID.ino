#include <MFRC522.h>

#include <Servo.h>
#include <SPI.h>

int RST_PIN = 9;
int SS_PIN = 10;
int servoPIN = 4;
int rLed = 6;
int gLed = 7;
int buzzer = 5;

Servo motor;
MFRC522 reader(SS_PIN ,RST_PIN);
byte cardID[4] = {80,21,12,163};

void setup() {
  motor.attach(servoPIN);
  motor.write(0);
  Serial.begin(9600);
  SPI.begin();  //for Arduino and RFID reader being able to communicate
  reader.PCD_Init(); //Initialization of RFID reader
  pinMode(rLed, OUTPUT);
  pinMode(gLed, OUTPUT);
  pinMode(buzzer, OUTPUT);
}

void loop() {
  //wait until a new card is read
  if(!reader.PICC_IsNewCardPresent())
    return; 
  if(!reader.PICC_ReadCardSerial())
  return;

  if(reader.uid.uidByte[0] == cardID[0] && reader.uid.uidByte[1] == cardID[1] && 
     reader.uid.uidByte[2] == cardID[2] && reader.uid.uidByte[3] == cardID[3]){
       Serial.println("Authorized card");
       writeToScreen();
       digitalWrite(gLed, HIGH);
       tone(buzzer,600);
       delay(300);
       noTone(buzzer);
       motor.write(180);
       delay(3000);
       motor.write(0);
       delay(1000);
       digitalWrite(gLed, LOW);
  }
  else{
    Serial.println("Unauthorized card");
    writeToScreen();
    digitalWrite(rLed, HIGH);
    tone(buzzer,250);
    delay(1000);
    noTone(buzzer);
    digitalWrite(rLed, LOW);
  }

  reader.PICC_HaltA();
}
void writeToScreen(){
    Serial.print("ID No: ");
    for(int counter = 0; counter<4; counter++){
      Serial.print(reader.uid.uidByte[counter]);
      Serial.print(" ");
    }
    Serial.println();
  }
