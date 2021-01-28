#include <MFRC522.h>
#include <SPI.h>

#define SENSOR_DEBUG_
#define FUNC_DEBUG_
#define RFID_DEBUG_
#define LINE_TEST_
#define RFID_TEST_

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

#define FORWARD_POWER 50
#define PUSHING_POWER 220
#define TURNING_POWER 5

#define PUSHING_DELAY 2
#define TURNING_DELAY 30

int counter = 0;

int RST_PIN = 9;
int SS_PIN = 10;

MFRC522 reader(SS_PIN ,RST_PIN);
byte cardID[4] = {243,189,233,20};  //Destination card ID
byte readCardID[4] = {0,0,0,0};

int sensorPins[] = {LMS , LS , MS , RS , RMS};

float sensorValue[5];
boolean digitalValue[5];

bool start=false;
short controlPostn = 0;  //Controlling whether unexpected sensor positions are accrued.
short controlStop = 1;  //Controlling whether one of the wheels or both of the wheels are stopped.
bool controlMessage = false;  //Controlling whether the previous message was 241,242,243 or not.
bool controlID = false; //Controlling for if the vehicle find the RFID card with the given ID
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
  if(Serial.available()){
    message = Serial.readString();
      if(message == "200"){
      Serial.write("OK\n");
      message="";  
      }
      if(message == "002"){
        start=true;
        Serial.println();
        Serial.println("START");
        Serial.println();
        message="";
      }
      if(message == "201"){
        start=false;
        Serial.println("STOP");
        Serial.println();
        message=""; 
      }
      //This direction message indicate that there is no need to change vehicle direction.
      if(message == "240" && start == true){
        Serial.write("OK1\n");
        controlMessage = true;
        message="";
      }
      if(message == "241" && start == true){
        Serial.write("OK1\n");
        //Serial.println("&turn left");
        turnLeft();
        stopping();
        controlMessage = true;
        message="";
      }
      if(message == "242" && start == true){
        Serial.write("OK1\n");
        //Serial.println("&turn right");
        turnRight();
        stopping();
        controlMessage = true;
        message="";
      }
      if(message == "243" && start == true){
        Serial.write("OK1\n");
        //Serial.println("&turn back");
        turnBack();
        stopping();
        controlMessage = true;
        message="";
      }
      if(controlMessage == true && message != ""){
        controlMessage = false;
        Serial.write("OK2\n");
        storeCardID(message);
        
        #ifdef FUNC_DEBUG
        Serial.print("Sended card: ");
        Serial.println(message);
        Serial.print("Destination card: ");
        
        for(short i=0;i<4;i++){
        Serial.print(cardID[i]);
        Serial.print(" ");
        }
        Serial.println(" ");
        Serial.println("Move and read");
        #endif
        
        controlID = false;
        //control = false;
        
        message="";
     }
  } // if(serial.available) end
   
 //If synchronized communication is established, start.
 while(controlID == false && start == true){
  Movement();
  RFIDreading();
  //Serial.println("StartLoop");
 }
     
  #ifdef LINE_TEST
  Movement();
  #endif
  #ifdef RFID_TEST
   RFIDreading(); 
  #endif
    
}//End of loop
  
void Movement (){
   #ifdef SENSOR_DEBUG
  counter++;
  delay(1000);
  Serial.write("loop : ");
  Serial.print(counter);
  Serial.write("\n");
  #endif

  convertDigital();
  int postn = positionCalculation();
  
  if(postn == 1){
    moveLeft(50);
  }
  else if(postn == 3){
    moveLeft(50);
  }
  else if(postn == 2){
    moveLeft(40);
  }
  else if(postn == 6){
    moveLeft(40);
  }
  else if(postn == 12){
    moveRight(40);
  }
  else if(postn == 8){
    moveRight(40);
  }
  else if(postn == 24){
    moveRight(50);
  }
  else if(postn == 16){
    moveRight(50);
  }
  
/*  else if(postn == 0){   //there is no need for whole white stuation, because lots of time it isn't recognized
                            //so it can goes into else statement block by making it comment out
     moveForward();
 }*/
 else if(postn == 4){
      moveForward();
 }
 /*else if(postn == 31){  //whole of them are black stuation can goes into else statement, too.
                          //because there is no need to stop at the whole black
                          //and also, it isn't always recognized, because sensor readings are not stable.
  moveForward();
  //stopping();
 }*/
 else{
  moveForward();
 }
}//End of movement

  //RFID
  //wait until a new card is read
void RFIDreading(){
  if(!reader.PICC_IsNewCardPresent()){
    return;
  }
     
  if(!reader.PICC_ReadCardSerial()){
    return;
  }
  //Serial.println("RFIDpass");
  
  for(short i = 0; i<4; i++){
    readCardID[i] = reader.uid.uidByte[i];
  }

  #ifdef RFID_DEBUG
  Serial.print("Read card ");
  #endif
  writeToScreen(readCardID);
  
  if(readCardID[0] == cardID[0] && readCardID[1] == cardID[1] && 
        readCardID[2] == cardID[2] && readCardID[3] == cardID[3]){
      
      #ifdef RFID_DEBUG
       Serial.println("&Destination card");
       Serial.println("&Stop");
       Serial.println("&");
       #endif
       
       stopping();
       //delay(5000);
       //turnBack();
       //turnLeft();
       //turnRight();
       //stopping();
       //delay(5000);
       controlID = true;
       //control = true;
       //return; //to prevent the reader from calling the halt function. 
                  //This prevents entering new card statement.
  }
  else{
      #ifdef RFID_DEBUG
       Serial.println("Invalid card");
       Serial.println();
       #endif  
  }

  reader.PICC_HaltA();
}//End of RFIDreading

void convertDigital() {
  
  int sum =0; 
    for(short i=0; i<5; i++){
      sensorValue[i] = analogRead(sensorPins[i]);
      sum+=sensorValue[i];
      
    }
    int avg = (sum) / 5;
    int threshold = ( avg *6 ) / 5;

    #ifdef SENSOR_DEBUG
        Serial.write(" avg :");
        Serial.print(avg);
        Serial.write(" threshold :");
        Serial.print(threshold);
        Serial.write("\n");
    #endif
    for(short i = 0; i < 5; i++){
        digitalValue[i] = sensorValue[i] >= threshold || sensorValue[i] > 250;

        #ifdef SENSOR_DEBUG
        Serial.print(sensorPins[i]);
        Serial.write(" : Analaog : ");
        Serial.print(sensorValue[i]);
        Serial.write(" : Digital : ");
        Serial.print(digitalValue[i]);
        Serial.write("\n");
        #endif
    }
}//End of convert digital

void moveForward(){
  
  digitalWrite(RM1, HIGH); // For right motor, moving forward is on
  digitalWrite(RM2, LOW); // For right motor, moving backward is off
  analogWrite(enR, PUSHING_POWER); //  Right motor speed 

  digitalWrite(LM1, HIGH); //For left motor, moving forward is on
  digitalWrite(LM2, LOW);  //For left motor, moving backward is of
  analogWrite(enL, PUSHING_POWER);  //Right motor, motor speed 
  
  delay(PUSHING_DELAY);
   
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW); 
  analogWrite(enR, FORWARD_POWER);  

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW);  
  analogWrite(enL, FORWARD_POWER); 
       
  #ifdef FUNC_DEBUG
  Serial.write("F\n");
  #endif    
}//End of moveForward

void moveRight(int power){
  
  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, PUSHING_POWER);
  
  delay(PUSHING_DELAY);
  
  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, power);   
            
  #ifdef FUNC_DEBUG
  Serial.write("R\n");
  Serial.print(power);
  Serial.write("\n");
  #endif    
}//End of moveRight

void moveLeft(int power){
  
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, PUSHING_POWER);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL, 0);

  delay(PUSHING_DELAY);

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, power);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL, 0);  
                
  #ifdef FUNC_DEBUG
  Serial.write("L\n");
  Serial.print(power);
  Serial.write("\n");
  #endif 
}//End of moveLeft

void stopping(){
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, LOW);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL, LOW); 
      
  #ifdef FUNC_DEBUG
  Serial.write("S\n");
  #endif 
}//End of stopping

void turnLeft(){
  turn(6, true);
  
  #ifdef FUNC_DEBUG
  Serial.write("TL\n");
  #endif
}//End of turn LEFT

void turnRight(){
  turn(6, false);
  
  #ifdef FUNC_DEBUG
  Serial.write("TR\n");
  #endif
}//End of turn RIGHT

void turnBack(){
  turn(10, true);
 
  #ifdef FUNC_DEBUG
  Serial.write("TB\n");
  #endif 
}//end of turn BACK
void turn(short count, bool left){
  for(short i = 0; i<count; i++){
    if(left == true){
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, TURNING_POWER);

  digitalWrite(LM1, LOW);
  digitalWrite(LM2, HIGH);
  digitalWrite(enL,TURNING_POWER );
  }
  else{
  digitalWrite(RM1, LOW);
  digitalWrite(RM2, HIGH);
  digitalWrite(enR, TURNING_POWER);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL,TURNING_POWER ); 
  }
 delay(TURNING_DELAY);
 stopping();
 delay(100); 
  
  }
}//End of turn

//for RFID reader
void writeToScreen(byte writeCardID[4]){
    Serial.write("\n#\n");
    for(int counter = 0; counter<4; counter++){
      Serial.print(writeCardID[counter]);
      Serial.print(" ");
    }
    Serial.write("\n");
}//end of writeToScreen

int positionCalculation(){
  
  int postn = 0;
    if(digitalValue[0]==1){
    postn+=1;
  }
  if(digitalValue[1]==1){
    postn+=2;
  }
  if(digitalValue[2]==1){
    postn+=4;
  }
  if(digitalValue[3]==1){
    postn+=8;
  }
  if(digitalValue[4]==1){
    postn+=16;
  }
  return postn;
}//end of poaitionCalculation

//Split sent card ID into four distinct part of it, and store it into cardID variable
void storeCardID (String IDStr) {
   for(short i=0; i < 4; i++){
 
     String subNumbers;
     byte IDByte;
     short index = IDStr.indexOf(' ');
     subNumbers = IDStr.substring(0,index);
     IDByte = convertToByte(subNumbers);
     //Serial.println(IDByte);
      
     IDStr = IDStr.substring(index+1);
    
    cardID[i] = IDByte; 
   }
}//end of storetCardID

byte convertToByte (String str){
  int cnvInt = str.toInt();
  byte cnvByte = (byte)cnvInt;
  return cnvByte;
}//end of convertToByte
