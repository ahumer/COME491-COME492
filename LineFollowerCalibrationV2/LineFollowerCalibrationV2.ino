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

#define FORWARD_POWER 80
#define TURNING_POWER 60
#define PUSHING_POWER 110

#define PUSHING_DELAY 20

#define SENSOR_DEBUG_
#define FUNC_DEBUG_
#define RFID_DEBUG
int counter = 0;

int RST_PIN = 9;
int SS_PIN = 10;

MFRC522 reader(SS_PIN ,RST_PIN);
byte cardID[4] = {4,23,59,46};
byte preCardID[4] = {0,0,0,0};
byte readCardID[4] = {0,0,0,0};

int sensorPins[] = {LMS , LS , MS , RS , RMS};

float sensorValue[5];
boolean digitalValue[5];

bool start=false;
short controlExtra = 0;
short controlStop = 1;
String message = "none";

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

  Serial.begin(9600);
  Serial.setTimeout(5000);
  SPI.begin();  //for Arduino and RFID reader being able to communicate
  reader.PCD_Init(); //Initialization of RFID reader
}

void loop() {
  while(Serial.available()){
    message = Serial.readString();
    if(message=="200"){
      Serial.write("OK\n");  
    }
    if(message=="002"){
      start=true;
      Serial.println();
      Serial.println("START");
      Serial.println();
    }
    if(message=="201"){
      start=false;
      Serial.println("STOP");
      Serial.println(); 
    }
  }
  if(start==true){
    Start(); 
  }
  
  Start(); 
}

void Start (){
  
  #ifdef SENSOR_DEBUG
  counter++;
  delay(1000);
  Serial.write("loop : ");
  Serial.print(counter);
  Serial.write("\n");
  #endif

  convertDigital();
  
  if((digitalValue[0]==1 || digitalValue[1]==1) && digitalValue[3]==0 && digitalValue[4] ==0){
    if(controlExtra==2){
     controlExtra=0; 
    }
    moveLeft();
  }
  
  if((digitalValue[3]==1 || digitalValue[4]==1) && digitalValue[0]==0 && digitalValue[1] ==0) {
    if(controlExtra==2){
     controlExtra=0; 
    }
    moveRight();
  }
  if(digitalValue[0]==0 && digitalValue[1]==0 && digitalValue[2]==0 && digitalValue[3]==0 && digitalValue[4]==0){
    if(controlExtra==2){
       controlExtra=0; 
      }
     //turn();
     stopping();
 }

 if((digitalValue[0]==1 || digitalValue[1]==1) && (digitalValue[3]==1 || digitalValue[4]==1)){

  while(controlExtra<2){
    moveForward();
    delay(5);
    stopping();
    delay(50);
    controlExtra++;
  }
  if (controlExtra==2){
    stopping();
  } 
 }

 if(digitalValue[0]==0 && digitalValue[1]==0 && digitalValue[2]==1 && digitalValue[3]==0 && digitalValue[4]==0){
    if(controlExtra==2){
       controlExtra=0; 
      }
    moveForward();
 }
 
  RFIDreading();

}//end of start

void convertDigital() {
  
  int sum =0; 
    for(short i=0; i<5; i++){
      sensorValue[i] = analogRead(sensorPins[i]);
      sum+=sensorValue[i];
      
    }
    int avg = (sum) / 5;
    int threshold = ( avg *6 ) / 5;  // 120% of avg

    #ifdef SENSOR_DEBUG
        Serial.write(" avg :");
        Serial.print(avg);
        Serial.write(" threshold :");
        Serial.print(threshold);
        Serial.write("\n");
    #endif
    for(short i = 0; i < 5; i++){
        digitalValue[i] = sensorValue[i] > threshold || sensorValue[i] > 250;

        #ifdef SENSOR_DEBUG
        Serial.print(sensorPins[i]);
        Serial.write(" : Analaog : ");
        Serial.print(sensorValue[i]);
        Serial.write(" : Digital : ");
        Serial.print(digitalValue[i]);
        Serial.write("\n");
        #endif
    }
}
void moveForward(){
  if(controlStop ==1 || controlStop == 2){
  digitalWrite(RM1, HIGH); // For right motor, moving forward is on
  digitalWrite(RM2, LOW); // For right motor, moving backward is off
  analogWrite(enR, PUSHING_POWER); //  Right motor speed 

  digitalWrite(LM1, HIGH); //For left motor, moving forward is on
  digitalWrite(LM2, LOW);  //For left motor, moving backward is of
  analogWrite(enL, PUSHING_POWER);  //Right motor, motor speed 
  
  delay(PUSHING_DELAY);
  }
  
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW); 
  analogWrite(enR, FORWARD_POWER);  

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW);  
  analogWrite(enL, FORWARD_POWER);
   
  controlStop = 0;  
       
  #ifdef FUNC_DEBUG
  Serial.write("F\n");
  #endif    
}

void moveRight(){
  //if(controlStop == 1){
  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, PUSHING_POWER);
  
  delay(PUSHING_DELAY);
 // }

  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, TURNING_POWER); 
     
  controlStop = 2;  
            
  #ifdef FUNC_DEBUG
  Serial.write("R\n");
  #endif    
}

void moveLeft(){
  //if(controlStop == 1){
   digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, PUSHING_POWER);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL, 0);

  delay(PUSHING_DELAY);
 //}

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, TURNING_POWER);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL, 0);
     
  controlStop = 2;  
            
     
  #ifdef FUNC_DEBUG
  Serial.write("L\n");
  #endif 
}

void stopping(){
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, LOW);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL, LOW);

   controlStop = 1; 
      
  #ifdef FUNC_DEBUG
  Serial.write("S\n");
  #endif 
}

void turn(){
  
stopping();
  
  #ifdef FUNC_DEBUG
  Serial.write("T\n");
  #endif
}

  //RFID
  //wait until a new card is read
void RFIDreading(){
  if(!reader.PICC_IsNewCardPresent()){
    return;
  }
     
  if(!reader.PICC_ReadCardSerial()){
    return;
  }

  
  for(short i = 0; i<4; i++){
    readCardID[i] = reader.uid.uidByte[i];
  }

  Serial.print("Read card ID : ");
  writeToScreen(readCardID);
  Serial.print("Previous card ID : ");
  writeToScreen(preCardID);
  
  if(reader.uid.uidByte[0] == cardID[0] && reader.uid.uidByte[1] == cardID[1] && 
     reader.uid.uidByte[2] == cardID[2] && reader.uid.uidByte[3] == cardID[3]){
      
      #ifdef RFID_DEBUG
       Serial.write("Authorized card\n");
       //writeToScreen(readCardID);
       #endif
       
       stopping();
       delay(5000);
       return;
  }
  else{
      #ifdef RFID_DEBUG
       Serial.write("Unauthorized card\n");
       //writeToScreen(readCardID);
       #endif  
  }

    for(short i = 0; i<4; i++){
    preCardID[i] = readCardID[i];
    readCardID[i] = 0;
  }

  reader.PICC_HaltA();
}

//for RFID reader
void writeToScreen(byte writeCardID[4]){
    Serial.print("ID No: ");
    for(int counter = 0; counter<4; counter++){
      Serial.print(writeCardID[counter]);
      Serial.print(" ");
    }
    Serial.write("\n");
}