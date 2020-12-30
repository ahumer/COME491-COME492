
//object detection
int LED = 13;
int obstaclePin = 14;
int hasObstacle = HIGH;

//color detection
int redPin = 9;
int greenPin = 10;
int bluePin = 11;

int outPin = 7; //Color Sensor OUT to Arduino pin 4
int S2 = 6; //Color sensor pin S2 to Arduino pin 7
int S3 = 5; //Color sensor pin S3 to Arduino pin 8
int SensorLed = 4;

int buttonPin = 2;
int state = 0;

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

  Serial.begin(115200); //turn on serial port

}

void loop() {

//object detection
  hasObstacle = digitalRead(obstaclePin);
  
    if (hasObstacle == LOW)
    {
      digitalWrite(LED, HIGH);
    }
    else
    {
      digitalWrite(LED,LOW);
    }


//color detection
  if(state==0)
  {
    Serial.println("here1");
    if(digitalRead(buttonPin)==LOW)
    {
      state=1;
    }
  }
  else
  {
    Serial.println("here2");
    if(digitalRead(buttonPin)==LOW)
    state=0;
  }

  if(state==0)
  {
    digitalWrite(redPin,HIGH);
    digitalWrite(greenPin,HIGH);
    digitalWrite(bluePin,HIGH);
    digitalWrite(SensorLed,LOW);
  }

  if(state==1)
  {
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
      Serial.print(" , ");
      Serial.println("");
      
      if(RCS>BCS && RCS>GCS)
      {
      digitalWrite(redPin,LOW);
      digitalWrite(greenPin,HIGH);
      digitalWrite(bluePin,HIGH);
      Serial.println("RedLed");
      }
      
      if(GCS>RCS && GCS>BCS)
      {
      digitalWrite(redPin,HIGH);
      digitalWrite(greenPin,LOW);
      digitalWrite(bluePin,HIGH);
      Serial.println("GreenLed");
      }
      
      if(BCS>RCS && BCS>GCS)
      {
      digitalWrite(redPin,HIGH);
      digitalWrite(greenPin,HIGH);
      digitalWrite(bluePin,LOW);
      Serial.println("BlueLed");
      }
  }
      
 delay(250);
}
