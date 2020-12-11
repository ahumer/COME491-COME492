/*
 * RGB LEd Usage
 */

int redPin = 12;
int greenPin = 11;
int bluePin = 10;
String myColor;
String msg="What color?";


void setup() {
  // put your setup code here, to run once:

  Serial.begin(9600); //turn on serial port

  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println(msg);

  while(Serial.available()==0)
  {
    
  }

  myColor=Serial.readString();
  

  if(myColor=="R")
  {
    digitalWrite(redPin,LOW);
    digitalWrite(greenPin,HIGH);
    digitalWrite(bluePin,HIGH);
    Serial.println(myColor);
    
  }

  if(myColor=="G")
  {
    digitalWrite(redPin,HIGH);
    digitalWrite(greenPin,LOW);
    digitalWrite(bluePin,HIGH);
    Serial.println(myColor);
  }

  if(myColor=="B")
  {
    digitalWrite(redPin,HIGH);
    digitalWrite(greenPin,HIGH);
    digitalWrite(bluePin,LOW);
    Serial.println(myColor);
  }

//Off the led
  if(myColor=="O")
  {
    digitalWrite(redPin,HIGH);
    digitalWrite(greenPin,HIGH);
    digitalWrite(bluePin,HIGH);
    Serial.println(myColor);
  }

}
