//bluetooth module
#include <SoftwareSerial.h>
SoftwareSerial BTSerial(15, 16);   // RX | TX

//object detection
int LED = 13;
int obstaclePin = 14;
int hasObstacle = HIGH;
String objInf;
String clrInf;

//color detection
int redPin = 9;
int greenPin = 10;
int bluePin = 11;

int outPin = 7; //Color Sensor OUT to Arduino pin 4
int S2 = 6; //Color sensor pin S2 to Arduino pin 7
int S3 = 5; //Color sensor pin S3 to Arduino pin 8
int SensorLed = 4;

int buttonPin = 2;
short state = 0;
short preState=0;
short start = 2; 
String message="";

int RCS; //Red Color Strength
int GCS; //Green Color Strength
int BCS; //Blue Color Strength

int pulseWidth=0;

void setup() {
  //object detection
  pinMode(LED, OUTPUT);
  pinMode(obstaclePin, INPUT);

  //color detection
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);

  pinMode(S2, OUTPUT);
  pinMode(S3, OUTPUT);
  pinMode(outPin, INPUT);
  pinMode(SensorLed,OUTPUT);

  pinMode(buttonPin,INPUT_PULLUP);

  Serial.begin(9600); //turn on serial port
  BTSerial.begin(9600);

  Serial.println("OFF_STATE");
}

void loop() {
  /************************************/
  //ON/OFF switch
  //Set "state" and "preState" variables.
  ButtonSwitch();
/***************************************/
  //OFF STATE
  if(state==0){
    digitalWrite(redPin,HIGH);
    digitalWrite(greenPin,HIGH);
    digitalWrite(bluePin,HIGH);
    digitalWrite(SensorLed,LOW);
    digitalWrite(LED,LOW);
    
    if(preState==1)
      Serial.println("OFF_STATE");
  }
  //OFF STATE
/***************************************/
/***************************************/
  //ON STATE
  if(state==1){
    
    if(preState==0)
      Serial.println("ON_STATE");


    if(BTSerial.available()){
      message = BTSerial.readString();
      Serial.print("message: ");
      Serial.println(message);
    }
  
    if(message=="200"){
      start=1;
      Serial.println("START");
      message="";
    }
    
    if(message=="201") {
      start=0;
      Serial.println("STOP");
      message="";
    }

    if(start==1)
     startLoop();
      
 }
 //ON STATE
    
 delay(250);
}//End of loop
/***************************************/

//ON/OFF switch
//Set "state" and "preState" variables.
void ButtonSwitch(){

  if(state==0){
    if(digitalRead(buttonPin)==LOW){
      state=1;
      preState=0;
    }
    preState=0;
  }
  else if(state==1){
    if(digitalRead(buttonPin)==LOW){
      state=0;
      preState=1;
    }
    preState=1;
  }
}

void startLoop(){

  message = objectDetection(); 
     
    if(message=="202"){
      serialBTWriting(message);
      colorDetection();
      while(Serial.available()==0){};
      message = serialReading();
      if(message=="203"){
       serialBTWriting(message);
       Serial.println(message);
       message="";
      }      
    }       
}

String objectDetection(){
  String messageIn="000";
  hasObstacle = digitalRead(obstaclePin);
  
  if (hasObstacle == LOW){
    digitalWrite(LED, HIGH);
    objInf = "212";
  }
  else{
    digitalWrite(LED,LOW);
    objInf = "211"; 
  }
  
  //Serial.println("***************************");
  //Serial.print("Object Info Message:  ");
  if(objInf=="211"){
  serialBTWriting(objInf);
  }
    if(objInf=="212"){
      Serial.write('#');
      serialWriting(objInf);
      serialBTWriting(objInf);
      while(messageIn!="202"){
      messageIn = serialReading();
      } 
      Serial.println(messageIn);     
  }
  //Serial.println("***************************");
  //delay(5000);
  
  return messageIn;
}
/***************************************/
void colorDetection(){
  //color detection
  //Start by reading red component of the color
  //S2 and S3 should be set LOW
  digitalWrite(SensorLed,HIGH);
  digitalWrite(S2,LOW);
  digitalWrite(S3,LOW);
  
  pulseWidth = pulseIn(outPin,LOW);
  
  //Remaping the value of the frequency to the RGB Model of 0 to 255
  pulseWidth = map(pulseWidth,13 ,67,255,0);
  RCS=pulseWidth;
  
  //Serial.print(" R ");
  //Serial.print(pulseWidth);
  //Serial.print(" , ");
  
  //Start by reading green component of the color
  //S2 and S3 should be set HIGH
  
  digitalWrite(S2,HIGH);
  digitalWrite(S3,HIGH);
  
  pulseWidth = pulseIn(outPin,LOW);
  
  //Remaping the value of the frequency to the RGB Model of 0 to 255
  pulseWidth = map(pulseWidth, 13,87,255,0);
  GCS=pulseWidth;
  
  //Serial.print(" G ");
  //Serial.print(pulseWidth);
  //Serial.print(" , ");
  
  
  
  //Start by reading blue component of the color
  //S2 and S3 should be set LOW, HIGH respectively
  
  digitalWrite(S2,LOW);
  digitalWrite(S3,HIGH);
  
  pulseWidth = pulseIn(outPin,LOW);
  
  //Remaping the value of the frequency to the RGB Model of 0 to 255
  pulseWidth = map(pulseWidth, 10,72,255,0);
  BCS=pulseWidth;
  
  //Serial.print(" B ");
  //Serial.print(pulseWidth);
  //Serial.println("");

  clrInf="224";//Color is not detected.
  
  if(RCS>BCS && RCS>GCS){
  digitalWrite(redPin,LOW);
  digitalWrite(greenPin,HIGH);
  digitalWrite(bluePin,HIGH);
  //Serial.println("RedLed");
  clrInf = "221";
  }
  
  if(GCS>RCS && GCS>BCS){
  digitalWrite(redPin,HIGH);
  digitalWrite(greenPin,LOW);
  digitalWrite(bluePin,HIGH);
  //Serial.println("GreenLed");
  clrInf = "222";
  }
  
  if(BCS>RCS && BCS>GCS){
  digitalWrite(redPin,HIGH);
  digitalWrite(greenPin,HIGH);
  digitalWrite(bluePin,LOW);
  //Serial.println("BlueLed");
  clrInf = "223";
  }
  
  //Serial.print("Color Info Message:  ");
  Serial.write('#');
  serialWriting(clrInf);
  serialBTWriting(clrInf);
  
  //Serial.println("-----------------------"); 
  digitalWrite(SensorLed,LOW);
}
/***************************************/
void serialWriting(String message){
  for(short i=0; i<3;i++){
    Serial.write(message.charAt(i));
  }
  Serial.write("\n");
}
/***************************************/
void serialBTWriting(String message){
  for(short i=0; i<3;i++){
    BTSerial.write(message.charAt(i));
  }
  BTSerial.write("\n");
}
/***************************************/
String serialReading(){
  String messageIn;
  char messageArray[3]="111";
  if(Serial.available()){
    while(Serial.read()!='#'){}
        Serial.readBytes(messageArray,3);            
  }
  messageIn = String(messageArray);
  messageIn.remove(3,2);
  return messageIn;
}