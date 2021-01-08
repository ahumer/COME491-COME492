//bluetooth module
#include <SoftwareSerial.h>
SoftwareSerial BTSerial(15, 16);   // RX | TX

//object detection
int yellowLED = 13;
int redLED = 12;
int greenLED = 11;
int obstaclePin = 14;
int hasObstacle = HIGH;
String objInf;
String clrInf;
String mtnInf;
String configData;
char configArray[3];

//color detection
int redPin = 8;
int greenPin = 9;
int bluePin = 10;

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
  pinMode(yellowLED, OUTPUT);
  pinMode(greenLED, OUTPUT);
  pinMode(redLED, OUTPUT);
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
    digitalWrite(greenLED,LOW);
    digitalWrite(redLED,LOW);
    digitalWrite(yellowLED,LOW);
    
    if(preState==1)
      Serial.println("OFF_STATE");
  }
  //OFF STATE
/***************************************/
/***************************************/
  //ON STATE
  if(state==1){
    
    if(preState==0){
      Serial.println("ON_STATE");
      digitalWrite(greenLED,LOW);
      digitalWrite(redLED,LOW);
      digitalWrite(yellowLED,HIGH);
    }

   Initialization();

    if(start==1)
     startLoop();
      
 }
 //ON STATE
    
 delay(350);
}//End of loop
/****************************************************/

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
/******************************************************/
void Initialization(){
   if(BTSerial.available()){
      message = BTSerial.readString();
      Serial.print("message from central: ");
      Serial.println(message);
    }

    //If start message is came from computer.
    if(message=="200"){
      //Communicating with robot arm.
      short counter=0;
      Serial.write('#');
      serialWriting("200");
      while(Serial.available()==0 && counter<5){
        delay(1000);
        counter++;
      }
      message = serialReading();

      //Establishing communication
      if(message == "202"){
        serialBTWriting(message);
        Serial.println("Waiting for configuration data.");
      

      while(BTSerial.available()==0 && counter<8){
        delay(1000);
        counter++;
      }
     //The config data is identified by @ character at the beginning of it.
      if(BTSerial.read()=='@'){
          message=BTSerial.readString();
          configData=message;
          configData.toCharArray(configArray,4);
          Serial.print("Configuration :");
          Serial.println(configData); 
          Serial.println(configArray[0]);
          Serial.println(configArray[1]);
          Serial.println(configArray[2]);     
          Serial.println("START");
          digitalWrite(greenLED,HIGH);
          digitalWrite(redLED,LOW);
          digitalWrite(yellowLED,LOW);
          serialBTWriting("206");
          start=1;
          message="";
        }
        else{
          serialBTWriting("207");
          start=0;
          digitalWrite(redLED,HIGH);
          digitalWrite(yellowLED,LOW);
          digitalWrite(greenLED,LOW);
          Serial.println("Couldn't get configuration data.");
          message="";
        }

      }
      //Inability to communicate 
      else{
        serialBTWriting("205");
        start=0;
        digitalWrite(redLED,HIGH);
        digitalWrite(yellowLED,LOW);
        digitalWrite(greenLED,LOW);
        Serial.println("Fail to start.");
        message="";
      }
    }

    //If stop message is came from computer.
    if(message=="201") {
      start=0;
      Serial.println("STOP");
      digitalWrite(redLED,HIGH);
      digitalWrite(yellowLED,LOW);
      digitalWrite(greenLED,LOW);
      message="";
    }
}
/*****************************************************/
void startLoop(){

  message = objectDetection(); 
     
    if(message=="203"){
      serialBTWriting(message);
      colorDetection();
      while(Serial.available()==0){};
      message = serialReading();
      if(message=="204"){
       serialBTWriting(message);
       Serial.println(message);
       digitalWrite(redPin,HIGH);
       digitalWrite(greenPin,HIGH);
       digitalWrite(bluePin,HIGH);
       message="";
      }      
    }       
}
/****************************************************/
String objectDetection(){
  String messageIn="000";
  hasObstacle = digitalRead(obstaclePin);
  
  if (hasObstacle == LOW){
    digitalWrite(yellowLED, HIGH);
    objInf = "212";
  }
  else{
    digitalWrite(yellowLED,LOW);
    objInf = "211"; 
  }
  
  if(objInf=="211"){
  serialBTWriting(objInf);
  }
    if(objInf=="212"){
      Serial.write('#');
      serialWriting(objInf);
      serialBTWriting(objInf);
      while(messageIn!="203"){
      messageIn = serialReading();
      } 
      Serial.println(messageIn);     
  }
  
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
  delay(1000);
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

  clrInf = "224";//Color is not detected.
  mtnInf = "224";
  
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
  serialWriting(decodeConfigData(clrInf));
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
//If Serial is available, then read, and send incoming data.
//If Serial is not available, then send, "111" string.
String serialReading(){
  String messageIn;
  char messageArray[3]="111";
  if(Serial.available()){
    while(Serial.read()!='#'){}
        Serial.readBytes(messageArray,3);            
  }
  messageIn = String(messageArray);
  Serial.println(messageIn);//For controlling of the working of above line.
  messageIn.remove(3);
  return messageIn;
}

String decodeConfigData (String clr){
  
  String motion="224";
  char r = configArray[0];
  char g = configArray[1];
  char b = configArray[2];

  if(clr == "221"){
    switch (r){
    case '1' : motion = "251";break;
    case '2' : motion = "252";break;
    case '3' : motion = "253";break;
    default : motion = "224";break;
    
    }
  }
    if(clr == "222"){
    switch (g){
    case '1' : motion = "251";break;
    case '2' : motion = "252";break;
    case '3' : motion = "253";break;
    default : motion = "224"; break;
    }
  }
    if(clr == "223"){
    switch (b){
    case '1' : motion = "251";break;
    case '2' : motion = "252";break;
    case '3' : motion = "253";break;
    default : motion = "224"; break;
    }
  }
  Serial.println(motion);
  return motion;
}
