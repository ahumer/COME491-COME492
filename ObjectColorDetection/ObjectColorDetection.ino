
//object detection
int LED = 13;
int obstaclePin = 14;
int hasObstacle = HIGH;
String objectInfo="250";//I couldn't figure out if this number is necesary or not.
String colorInfo="255"; //I couldn't figure out if this number is necesary or not.
String message="";

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

  Serial.println("OFF_STATE");
}

void loop() {
  //Button on/off switch
    if(state==0){
      if(digitalRead(buttonPin)==LOW){
        state=1;
        preState=0;
      }
      preState=0;
    }
    else{
       if(digitalRead(buttonPin)==LOW){
          state=0;
          preState=1;
       }
       preState=1;
    }

    //off state
    if(state==0){
      digitalWrite(redPin,HIGH);
      digitalWrite(greenPin,HIGH);
      digitalWrite(bluePin,HIGH);
      digitalWrite(SensorLed,LOW);
      digitalWrite(LED,LOW);
      
      if(preState==1)
         Serial.println("OFF_STATE");
    }

    //on state
    if(state==1){
      
        if(preState==0)
           Serial.println("ON_STATE");
           
      //object detection
      hasObstacle = digitalRead(obstaclePin);
    
      if (hasObstacle == LOW){
        digitalWrite(LED, HIGH);
        objectInfo = "251";
      }
      else{
        digitalWrite(LED,LOW);
        objectInfo = "250"; 
      }

        if(Serial.available()>0){
          message = Serial.readString(); 
            if(message=="204"){
              Serial.println("***************************");
              Serial.print("Object Info Message:  ");
              serialWriting(objectInfo);
              Serial.println("***************************");
              delay(5000);
            }
          }
      
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

      Serial.print(" R ");
      Serial.print(pulseWidth);
      Serial.print(" , ");
      
      //Start by reading green component of the color
      //S2 and S3 should be set LOW
      
      digitalWrite(S2,HIGH);
      digitalWrite(S3,HIGH);
      
      pulseWidth = pulseIn(outPin,LOW);
      
      //Remaping the value of the frequency to the RGB Model of 0 to 255
      pulseWidth = map(pulseWidth, 13,87,255,0);
      GCS=pulseWidth;

      Serial.print(" G ");
      Serial.print(pulseWidth);
      Serial.print(" , ");
      
      
      
      //Start by reading blue component of the color
      //S2 and S3 should be set LOW
      
      digitalWrite(S2,LOW);
      digitalWrite(S3,HIGH);
      
      pulseWidth = pulseIn(outPin,LOW);
      
      //Remaping the value of the frequency to the RGB Model of 0 to 255
      pulseWidth = map(pulseWidth, 10,72,255,0);
      BCS=pulseWidth;

      Serial.print(" B ");
      Serial.print(pulseWidth);
      Serial.println("");

      colorInfo="255";
      if(RCS>BCS && RCS>GCS){
      digitalWrite(redPin,LOW);
      digitalWrite(greenPin,HIGH);
      digitalWrite(bluePin,HIGH);
      Serial.println("RedLed");
      colorInfo=252;
      }
      
      if(GCS>RCS && GCS>BCS){
      digitalWrite(redPin,HIGH);
      digitalWrite(greenPin,LOW);
      digitalWrite(bluePin,HIGH);
      Serial.println("GreenLed");
      colorInfo=253;
      }
      
      if(BCS>RCS && BCS>GCS){
      digitalWrite(redPin,HIGH);
      digitalWrite(greenPin,HIGH);
      digitalWrite(bluePin,LOW);
      Serial.println("BlueLed");
      colorInfo=254;
      }

      Serial.print("Color Info Message:  ");
      serialWriting(colorInfo);

      Serial.println("-----------------------");
    }
          
  delay(250);
  }

  void serialWriting(String message){
    for(short i=0; i<3;i++){
      Serial.write(message.charAt(i));
    }
    Serial.write("\n");
  }
