#include <MFRC522.h>
#include <SPI.h>

//Five infrared sensors
#define LMS 15 //Leftmost sensor
#define LS 16 //Left Sensor
#define MS 17 //Middle sensor
#define RS 18 //Right sensor
#define RMS 19 //Rightmost sensor

//For L298N Motor Driver
#define LM1 7 //IN4
#define LM2 4 //IN3
#define RM2 3 //IN2
#define RM1 2 //IN1
#define enR 5 //ENA (PWM)
#define enL 6 //ENB (PWM)

#define FORWARD_POWER 140
#define TURNING_POWER 110

#define SENSOR_DEBUG
#define FUNC_DEBUG
int counter = 0;

int RST_PIN = 9;
int SS_PIN = 10;

MFRC522 reader(SS_PIN ,RST_PIN);
byte cardID[4] = {80,21,12,163};

int sensorPins[] = {LMS , LS , MS , RS , RMS};

float sensorValue[5];
float sensorValueMin[5] = {1024,1024,1024,1024,1024};
float sensorValueMax[5] = {0,0,0,0,0};
float threshold[5] = {10, 10, 10, 10, 10};
float sensorValueAvg[5] = {512,512,512,512,512};
boolean digitalValue[5];
short error = 0;
short control=0;

void setup() {
 
  //Sensor pins
  for ( short i=0; i < 5; i++){
    pinMode(sensorPins[i], INPUT);
  }
  //Motor pins
  pinMode(LM2, OUTPUT);
  pinMode(LM1, OUTPUT);
  pinMode(RM2, OUTPUT);
  pinMode(RM1, OUTPUT);
  pinMode(enR, OUTPUT); //Left motor enable
  pinMode(enL, OUTPUT); //Right motor enable

  Serial.begin(115200);
  SPI.begin();  //for Arduino and RFID reader being able to communicate
  reader.PCD_Init(); //Initialization of RFID reader
}

void loop() {

  //Updating min,max,avg,threshold values
  updating();
  updateSensor();
  
  #ifdef SENSOR_DEBUG
  counter++;
  delay(1000);
  Serial.println(counter);
  #endif
  
  if((digitalValue[0]==0 || digitalValue[1]==0) && digitalValue[3]==1 && digitalValue[4] ==1){
    control=0;
    moveRight();
    return;
  }
  
  if((digitalValue[3]==0 || digitalValue[4]==0) && digitalValue[0]==1 && digitalValue[1] ==1) {
    control=0;
    moveLeft();
    return;
  }

 if((digitalValue[0]==0 || digitalValue[1]==0) && (digitalValue[3]==0 || digitalValue[4]==0)){

  if(control==0){
    moveForward();
    delay(5);
    stopping();
    delay(50);
    control++;;
    return;
  }
  else if (control==2){
    stopping();
    control=0;
    return;
  }
  
 }


  //RFID
  //wait until a new card is read
  if(!reader.PICC_IsNewCardPresent()){
    return;
  }
     
  if(!reader.PICC_ReadCardSerial()){
    return;
  }
  
  if(reader.uid.uidByte[0] == cardID[0] && reader.uid.uidByte[1] == cardID[1] && 
     reader.uid.uidByte[2] == cardID[2] && reader.uid.uidByte[3] == cardID[3]){
       Serial.println("Authorized card");
       writeToScreen();
       stopping();
  }
  else{
       Serial.println("Unauthorized card");
       writeToScreen();  
  }

  reader.PICC_HaltA();

}

void moveForward(){
  
  digitalWrite(RM1, HIGH);// For right motor, moving forward is on
  digitalWrite(RM2, LOW); // For right motor, moving backward is off
  analogWrite(enR, FORWARD_POWER);  //  Right motor speed

  digitalWrite(LM1, HIGH); //For left motor, moving forward is on
  digitalWrite(LM2, LOW);  //For left motor, moving backward is off
  analogWrite(enL, FORWARD_POWER);    //Right motor, motor speed

       
  #ifdef FUNC_DEBUG
  Serial.println("F");
  #endif
    
}

void moveRight(){ 

  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, TURNING_POWER);

       
  #ifdef FUNC_DEBUG
  Serial.println("R");
  #endif
     
}

void moveLeft(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, TURNING_POWER);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL,0 );

     
  #ifdef FUNC_DEBUG
  Serial.println("L");
  #endif
  
}

void stopping(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, LOW);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL, LOW);

       
  #ifdef FUNC_DEBUG
  Serial.println("S");
  #endif
  
}

//for RFID reader
void writeToScreen(){
    Serial.print("ID No: ");
    for(int counter = 0; counter<4; counter++){
      Serial.print(reader.uid.uidByte[counter]);
      Serial.print(" ");
    }
    Serial.println();
  }

  void updateSensor() {
          #ifdef FUNC_DEBUG
      Serial.println("Update: ");
      #endif
      
    for(short i=0; i<5; i++){
      sensorValue[i] = analogRead(sensorPins[i]);
      digitalValue[i] = sensorValue[i] > (sensorValueAvg[i] + threshold[i]);

      #ifdef FUNC_DEBUG
      Serial.print(sensorPins[i]);
      Serial.print(" : Avalue-> ");
      Serial.print(sensorValue[i]);
      Serial.print(" avarage-> ");
      Serial.print(sensorValueAvg[i]);
      Serial.print(" threshold-> ");
      Serial.print(sensorValueAvg[i]+threshold[i]);
      Serial.print( " Dvalue-> ");
      Serial.println(digitalValue[i]);
      #endif
    }
  }

  //Updating min,max,avg,threshold values
  void updating() {
    for(short i = 0; i < 5; i++){
      sensorValueMin[i] = sensorValue[i] < sensorValueMin[i] ? sensorValue[i] : sensorValueMin[i];
      sensorValueMax[i] = sensorValue[i] > sensorValueMax[i] ? sensorValue[i] : sensorValueMax[i];
      sensorValueAvg[i] = (sensorValueMin[i] + sensorValueMax[i]) / 2; // update the avarage value
      threshold[i] = (sensorValueMax[i] - sensorValueMin[i]) * 0.1; // Threshold is 10% of total sensor range
      
    }
  }
