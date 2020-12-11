/*
 * Controlling led via BlueTooth by using a mobile app. coded with MIT App Inventor.
 */
#define LED 13
char sendedData = 0;
 
void setup() {
  Serial.begin(9600);
  pinMode(LED,OUTPUT);
}

void loop() {
  while(Serial.available()==0)
  {
  }
  sendedData = Serial.read();
  Serial.println(sendedData);

  if(sendedData=='1')
    digitalWrite(LED,HIGH);
  else if(sendedData=='0')
    digitalWrite(LED,LOW);
 
}
