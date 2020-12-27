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


void setup() {
 
  //Sensor pins
  pinMode(LMS,INPUT);
  pinMode(LS,INPUT);
  pinMode(MS,INPUT);
  pinMode(RS,INPUT);
  pinMode(RMS,INPUT);
  
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
  void updating();
  
  #ifdef SENSOR_DEBUG
  counter++;
  delay(1000);
  Serial.println(counter);
  #endif
  
  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the middle sensor see black, move forward
     moveForward();

     #ifdef SENSOR_DEBUG
     Serial.println("1");
     #endif
     
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the right and the middle sensor see black turn right
     turnRight();
     #ifdef SENSOR_DEBUG
     Serial.println("2");
     #endif
     
  }
  
  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the right sensor see black turn right
     turnRight();
     
     #ifdef SENSOR_DEBUG
     Serial.println("3");
     #endif
     
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 0){  // When the right and rightmost sensor see black, turn right
    turnRight();
    
     #ifdef SENSOR_DEBUG
     Serial.println("4");
     #endif
    
  }
  
   if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 0){  // When the rightmost sensor see black turn right
     turnRight();
     
     #ifdef SENSOR_DEBUG
     //Serial.println("5");
     #endif
     
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the left and the middle sensor see black, turn left
     turnLeft();
     
     #ifdef SENSOR_DEBUG
     Serial.println("6");
     #endif
    
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 0 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the left sensor see black, turn left
     turnLeft();
     
     #ifdef SENSOR_DEBUG
     Serial.println("7");
     #endif
     
  }
  
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 0 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the left and leftmost sensor see black, turn left
     turnLeft();
     
     #ifdef SENSOR_DEBUG
     Serial.println("8");
     #endif
      
  }
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the leftmost sensor see black, turn left
     turnLeft();
     
     #ifdef SENSOR_DEBUG
     Serial.println("9");
     #endif
      
  }
  
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 0 && digitalRead(RMS) == 0){  // When all of them see black stop  
     stopping();
     
     #ifdef SENSOR_DEBUG
     Serial.println("10");
     #endif
     
  }
  
  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When all of them see white stop
     stopping();
     
    #ifdef SENSOR_DEBUG
    Serial.println("11");
    #endif
    
     
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
       
      #ifdef FUNC_DEBUG
      Serial.println("RFID STOP");
      #endif

      delay(5000);
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

void turnRight(){ 

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

void turnLeft(){

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
