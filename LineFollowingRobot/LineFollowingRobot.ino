//Two infrared sensors
#define LS 2
#define RS 3
//For L298N Motor Driver
#define LM1 6 //IN4
#define LM2 7 //IN3
#define RM2 8 //IN2
#define RM1 9 //IN1
#define enR 10 //ENA
#define enL 5 //ENB
void setup()
{
  Serial.begin(9600);
pinMode(LS, INPUT);
pinMode(RS, INPUT);
pinMode(LM2, OUTPUT);
pinMode(LM1, OUTPUT);
pinMode(RM2, OUTPUT);
pinMode(RM1, OUTPUT);
pinMode(enR, OUTPUT); //Left motor enable
pinMode(enL, OUTPUT); //Right motor enable
}
void loop()
{
if(!(digitalRead(LS)) && !(digitalRead(RS))) // Move Forward on line when both sensors see white
{
  Serial.println("hereF");
  analogWrite(enR,80); 
  analogWrite(enL,110); 
  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
}
if(!(digitalRead(LS)) && digitalRead(RS)) // turn right by stoping right motor when right sensor see black
{
  Serial.println("hereR");
  analogWrite(enR,0);
  analogWrite(enL,100);
  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(RM1, LOW);
  digitalWrite(RM2, LOW);
}
if(digitalRead(LS) && !(digitalRead(RS)))
{// Turn left by stoping left motor when left sensor see black
  Serial.println("hereL");
  analogWrite(enR,80);
  analogWrite(enL,0);
  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(LM1, LOW);
  digitalWrite(LM2, LOW);

}

if(digitalRead(LS) && digitalRead(RS))
{// stop when both sensor see black
  Serial.println("hereS");
  analogWrite(enR,0);
  analogWrite(enL,0);
  digitalWrite(LM2, LOW);
  digitalWrite(LM1, LOW);
  digitalWrite(RM2, LOW);
  digitalWrite(RM1, LOW);
}
}
